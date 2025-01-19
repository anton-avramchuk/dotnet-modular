﻿using Dotnet.Modular.Core;
using Dotnet.Modular.Core.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.Core.Services
{
    [Export(ExportType.Trancient, typeof(ICrmLazyServiceProvider))]
    public class CrmLazyServiceProvider : CachedServiceProviderBase, ICrmLazyServiceProvider
    {
        public CrmLazyServiceProvider(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public virtual T LazyGetRequiredService<T>()
        {
            return (T)LazyGetRequiredService(typeof(T));
        }

        public virtual object LazyGetRequiredService(Type serviceType)
        {
            return this.GetRequiredService(serviceType);
        }

        public virtual T? LazyGetService<T>()
        {
            return (T?)LazyGetService(typeof(T));
        }

        public virtual object? LazyGetService(Type serviceType)
        {
            return GetService(serviceType);
        }

        public virtual T LazyGetService<T>(T defaultValue)
        {
            return GetService(defaultValue);
        }

        public virtual object LazyGetService(Type serviceType, object defaultValue)
        {
            return GetService(serviceType, defaultValue);
        }

        public virtual T LazyGetService<T>(Func<IServiceProvider, object> factory)
        {
            return GetService<T>(factory);
        }

        public virtual object LazyGetService(Type serviceType, Func<IServiceProvider, object> factory)
        {
            return GetService(serviceType, factory);
        }
    }
}
