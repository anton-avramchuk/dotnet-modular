using System;

namespace Dotnet.Modular.Core.Exceptions
{
    public class DoubleDisposedException : Exception
    {
        public DoubleDisposedException() : base("Object disposed more once")
        {

        }
    }
}
