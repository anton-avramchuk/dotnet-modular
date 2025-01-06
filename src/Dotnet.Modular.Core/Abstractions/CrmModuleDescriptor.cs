using Dotnet.Modular.Core.Extensions.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Dotnet.Modular.Core.Abstractions;

public class CrmModuleDescriptor : ICrmModuleDescriptor
{
    public Type Type { get; }

   


    public IModule Instance { get; }


    public CrmModuleDescriptor(
        Type type,
        IModule instance)
    {

        if (!type.GetTypeInfo().IsAssignableFrom(instance.GetType()))
        {
            throw new ArgumentException($"Given module instance ({instance.GetType().AssemblyQualifiedName}) is not an instance of given module type: {type.AssemblyQualifiedName}");
        }

        Type = type;
        Instance = instance;

    }


    public override string ToString()
    {
        return $"[CrmModuleDescriptor {Type.FullName}]";
    }
}