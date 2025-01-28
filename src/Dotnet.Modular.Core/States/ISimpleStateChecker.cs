using Dotnet.Modular.Core.Abstractions.DependencyInjection;
using Dotnet.Modular.Core.Extensions.Collections;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Dotnet.Modular.Core.States
{
    public interface ISimpleStateChecker<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        Task<bool> IsEnabledAsync(SimpleStateCheckerContext<TState> context);
    }


    public interface ISimpleStateCheckerManager<TState>
         where TState : IHasSimpleStateCheckers<TState>
    {
        Task<bool> IsEnabledAsync(TState state);

        Task<SimpleStateCheckerResult<TState>> IsEnabledAsync(TState[] states);
    }

    public class SimpleStateCheckerResult<TState> : Dictionary<TState, bool>
        where TState : IHasSimpleStateCheckers<TState>
    {
        public SimpleStateCheckerResult()
        {

        }

        public SimpleStateCheckerResult(IEnumerable<TState> states, bool initValue = true)
        {
            foreach (var state in states)
            {
                Add(state, initValue);
            }
        }
    }

    public class SimpleStateCheckerManager<TState> : ISimpleStateCheckerManager<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        protected IServiceProvider ServiceProvider { get; }

        protected CrmSimpleStateCheckerOptions<TState> Options { get; }

        public SimpleStateCheckerManager(IServiceProvider serviceProvider, IOptions<CrmSimpleStateCheckerOptions<TState>> options)
        {
            ServiceProvider = serviceProvider;
            Options = options.Value;
        }

        public virtual async Task<bool> IsEnabledAsync(TState state)
        {
            return await InternalIsEnabledAsync(state, true);
        }

        public virtual async Task<SimpleStateCheckerResult<TState>> IsEnabledAsync(TState[] states)
        {
            var result = new SimpleStateCheckerResult<TState>(states);

            using (var scope = ServiceProvider.CreateScope())
            {
                var batchStateCheckers = states.SelectMany(x => x.StateCheckers)
                    .Where(x => x is ISimpleBatchStateChecker<TState>)
                    .Cast<ISimpleBatchStateChecker<TState>>()
                    .GroupBy(x => x)
                    .Select(x => x.Key);

                foreach (var stateChecker in batchStateCheckers)
                {
                    var context = new SimpleBatchStateCheckerContext<TState>(
                        scope.ServiceProvider.GetRequiredService<ICachedServiceProvider>(),
                        states.Where(x => x.StateCheckers.Contains(stateChecker)).ToArray());

                    foreach (var x in await stateChecker.IsEnabledAsync(context))
                    {
                        result[x.Key] = x.Value;
                    }

                    if (result.Values.All(x => !x))
                    {
                        return result;
                    }
                }

                foreach (ISimpleBatchStateChecker<TState> globalStateChecker in Options.GlobalStateCheckers
                    .Where(x => typeof(ISimpleBatchStateChecker<TState>).IsAssignableFrom(x))
                    .Select(x => ServiceProvider.GetRequiredService(x)))
                {
                    var context = new SimpleBatchStateCheckerContext<TState>(
                        scope.ServiceProvider.GetRequiredService<ICachedServiceProvider>(),
                        states.Where(x => result.Any(y => y.Key.Equals(x) && y.Value)).ToArray());

                    foreach (var x in await globalStateChecker.IsEnabledAsync(context))
                    {
                        result[x.Key] = x.Value;
                    }
                }

                foreach (var state in states)
                {
                    if (result[state])
                    {
                        result[state] = await InternalIsEnabledAsync(state, false);
                    }
                }

                return result;
            }
        }

        protected virtual async Task<bool> InternalIsEnabledAsync(TState state, bool useBatchChecker)
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var context = new SimpleStateCheckerContext<TState>(scope.ServiceProvider.GetRequiredService<ICachedServiceProvider>(), state);

                foreach (var provider in state.StateCheckers.WhereIf(!useBatchChecker, x => x is not ISimpleBatchStateChecker<TState>))
                {
                    if (!await provider.IsEnabledAsync(context))
                    {
                        return false;
                    }
                }

                foreach (ISimpleStateChecker<TState> provider in Options.GlobalStateCheckers
                    .WhereIf(!useBatchChecker, x => !typeof(ISimpleBatchStateChecker<TState>).IsAssignableFrom(x))
                    .Select(x => ServiceProvider.GetRequiredService(x)))
                {
                    if (!await provider.IsEnabledAsync(context))
                    {
                        return false;
                    }
                }

                return true;
            }
        }
    }


    public class CrmSimpleStateCheckerOptions<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        public ITypeList<ISimpleStateChecker<TState>> GlobalStateCheckers { get; }

        public CrmSimpleStateCheckerOptions()
        {
            GlobalStateCheckers = new TypeList<ISimpleStateChecker<TState>>();
        }
    }


    /// <summary>
    /// A shortcut for <see cref="TypeList{TBaseType}"/> to use object as base type.
    /// </summary>
    public class TypeList : TypeList<object>, ITypeList
    {
    }

    /// <summary>
    /// Extends <see cref="List{Type}"/> to add restriction a specific base type.
    /// </summary>
    /// <typeparam name="TBaseType">Base Type of <see cref="Type"/>s in this list</typeparam>
    public class TypeList<TBaseType> : ITypeList<TBaseType>
    {
        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The count.</value>
        public int Count => _typeList.Count;

        /// <summary>
        /// Gets a value indicating whether this instance is read only.
        /// </summary>
        /// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
        public bool IsReadOnly => false;

        /// <summary>
        /// Gets or sets the <see cref="Type"/> at the specified index.
        /// </summary>
        /// <param name="index">Index.</param>
        public Type this[int index]
        {
            get { return _typeList[index]; }
            set
            {
                CheckType(value);
                _typeList[index] = value;
            }
        }

        private readonly List<Type> _typeList;

        /// <summary>
        /// Creates a new <see cref="TypeList{T}"/> object.
        /// </summary>
        public TypeList()
        {
            _typeList = new List<Type>();
        }

        /// <inheritdoc/>
        public void Add<T>() where T : TBaseType
        {
            _typeList.Add(typeof(T));
        }

        public bool TryAdd<T>() where T : TBaseType
        {
            if (Contains<T>())
            {
                return false;
            }

            Add<T>();
            return true;
        }

        /// <inheritdoc/>
        public void Add(Type item)
        {
            CheckType(item);
            _typeList.Add(item);
        }

        /// <inheritdoc/>
        public void Insert(int index, Type item)
        {
            CheckType(item);
            _typeList.Insert(index, item);
        }

        /// <inheritdoc/>
        public int IndexOf(Type item)
        {
            return _typeList.IndexOf(item);
        }

        /// <inheritdoc/>
        public bool Contains<T>() where T : TBaseType
        {
            return Contains(typeof(T));
        }

        /// <inheritdoc/>
        public bool Contains(Type item)
        {
            return _typeList.Contains(item);
        }

        /// <inheritdoc/>
        public void Remove<T>() where T : TBaseType
        {
            _typeList.Remove(typeof(T));
        }

        /// <inheritdoc/>
        public bool Remove(Type item)
        {
            return _typeList.Remove(item);
        }

        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            _typeList.RemoveAt(index);
        }

        /// <inheritdoc/>
        public void Clear()
        {
            _typeList.Clear();
        }

        /// <inheritdoc/>
        public void CopyTo(Type[] array, int arrayIndex)
        {
            _typeList.CopyTo(array, arrayIndex);
        }

        /// <inheritdoc/>
        public IEnumerator<Type> GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _typeList.GetEnumerator();
        }

        private static void CheckType(Type item)
        {
            if (!typeof(TBaseType).GetTypeInfo().IsAssignableFrom(item))
            {
                throw new ArgumentException($"Given type ({item.AssemblyQualifiedName}) should be instance of {typeof(TBaseType).AssemblyQualifiedName} ", nameof(item));
            }
        }
    }


    /// <summary>
    /// A shortcut for <see cref="ITypeList{TBaseType}"/> to use object as base type.
    /// </summary>
    public interface ITypeList : ITypeList<object>
    {

    }

    /// <summary>
    /// Extends <see cref="IList{Type}"/> to add restriction a specific base type.
    /// </summary>
    /// <typeparam name="TBaseType">Base Type of <see cref="Type"/>s in this list</typeparam>
    public interface ITypeList<in TBaseType> : IList<Type>
    {
        /// <summary>
        /// Adds a type to list.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        void Add<T>() where T : TBaseType;

        /// <summary>
        /// Adds a type to list if it's not already in the list.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        bool TryAdd<T>() where T : TBaseType;

        /// <summary>
        /// Checks if a type exists in the list.
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <returns></returns>
        bool Contains<T>() where T : TBaseType;

        /// <summary>
        /// Removes a type from list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void Remove<T>() where T : TBaseType;
    }


    public interface ISimpleBatchStateChecker<TState> : ISimpleStateChecker<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        Task<SimpleStateCheckerResult<TState>> IsEnabledAsync(SimpleBatchStateCheckerContext<TState> context);
    }


    public class SimpleBatchStateCheckerContext<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        public IServiceProvider ServiceProvider { get; }

        public TState[] States { get; }

        public SimpleBatchStateCheckerContext(IServiceProvider serviceProvider, TState[] states)
        {
            ServiceProvider = serviceProvider;
            States = states;
        }
    }


    public abstract class SimpleBatchStateCheckerBase<TState> : ISimpleBatchStateChecker<TState>
    where TState : IHasSimpleStateCheckers<TState>
    {
        public async Task<bool> IsEnabledAsync(SimpleStateCheckerContext<TState> context)
        {
            return (await IsEnabledAsync(new SimpleBatchStateCheckerContext<TState>(context.ServiceProvider, new[] { context.State }))).Values.All(x => x);
        }

        public abstract Task<SimpleStateCheckerResult<TState>> IsEnabledAsync(SimpleBatchStateCheckerContext<TState> context);
    }

}
