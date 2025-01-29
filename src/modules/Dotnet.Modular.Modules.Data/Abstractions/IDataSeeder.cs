namespace Dotnet.Modular.Modules.Data.Abstractions;

public interface IDataSeeder
{
    Task SeedAsync(DataSeedContext context);
}
