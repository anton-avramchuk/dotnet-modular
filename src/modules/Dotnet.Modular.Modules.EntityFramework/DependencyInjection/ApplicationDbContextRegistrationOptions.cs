using Microsoft.Extensions.DependencyInjection;

namespace Dotnet.Modular.Modules.EntityFramework.DependencyInjection;

public class ApplicationDbContextRegistrationOptions : ApplicationCommonDbContextRegistrationOptions, IApplicationCommonDbContextRegistrationOptionsBuilder
{


    public ApplicationDbContextRegistrationOptions(Type originalDbContextType, IServiceCollection services) : base(originalDbContextType, services)
    {
    }



}