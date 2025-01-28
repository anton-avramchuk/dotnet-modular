namespace Dotnet.Modular.Modules.Data.Abstractions;

public interface IDataSeedContributor
{
    Task SeedAsync(DataSeedContext context);
}
