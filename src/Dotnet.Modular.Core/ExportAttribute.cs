using System;

namespace Dotnet.Modular.Core
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class ExportAttribute : Attribute
    {
        public ExportAttribute(ExportType type, params Type[] types)
        {
            Type = type;
            Types = types;
        }
        public ExportType Type { get;  }
        public Type[] Types { get; }
    }

    public enum ExportType
    {
        Scope,
        Trancient,
        Single
    }
}
