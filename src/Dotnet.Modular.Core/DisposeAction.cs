﻿using Crm.Core.Exceptions;
using System;

namespace Dotnet.Modular.Core;

/// <summary>
/// This class can be used to provide an action when
/// Dispose method is called.
/// </summary>
public class DisposeAction : IDisposable
{
    private readonly Action _action;
    private bool _disposed;

    /// <summary>
    /// Creates a new <see cref="DisposeAction"/> object.
    /// </summary>
    /// <param name="action">Action to be executed when this object is disposed.</param>
    public DisposeAction(Action action)
    {
        _action = action;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            _action();
        }
        else
        {
            throw new DoubleDisposedException();
        }

    }
}

/// <summary>
/// This class can be used to provide an action when
/// Dispose method is called.
/// <typeparam name="T">The type of the parameter of the action.</typeparam>
/// </summary>
public class DisposeAction<T> : IDisposable
{
    private readonly Action<T> _action;

    private bool _disposed;

    private readonly T? _parameter;

    /// <summary>
    /// Creates a new <see cref="DisposeAction"/> object.
    /// </summary>
    /// <param name="action">Action to be executed when this object is disposed.</param>
    /// <param name="parameter">The parameter of the action.</param>
    public DisposeAction(Action<T> action, T parameter)
    {
        _action = action;
        _parameter = parameter;
    }

    public void Dispose()
    {
        if (!_disposed)
        {
            _disposed = true;
            if (_parameter != null)
            {
                _action(_parameter);
            }
        }
        else
        {
            throw new DoubleDisposedException();
        }

    }
}
