namespace Dotnet.Modular.Modules.Navigation;

public interface IMenuProvider
{
    Task ConfigureMenuAsync(MenuConfigurationContext context);
}
