﻿namespace Dotnet.Modular.Core.Abstractions;

public interface IModuleManager
{

    

    void InitializeModules(ApplicationInitializationContext context);

   
    void ShutdownModules(ApplicationShutdownContext context);

}
