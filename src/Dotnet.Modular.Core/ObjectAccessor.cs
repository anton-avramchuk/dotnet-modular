﻿
namespace Dotnet.Modular.Core
{
    public class ObjectAccessor<T> : IObjectAccessor<T>
    {
        public T? Value { get; set; }

        public ObjectAccessor()
        {

        }

        public ObjectAccessor(T? obj)
        {
            Value = obj;
        }
    }
}
