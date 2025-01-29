using System;

namespace Crm.Core.Exceptions
{
    public class DoubleDisposedException : Exception
    {
        public DoubleDisposedException() : base("Object disposed more once")
        {
            
        }
    }
}
