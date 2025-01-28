namespace Dotnet.Modular.Modules.Data;

public class DataSeedOptions
{
    public DataSeedContributorList Contributors { get; }

    public DataSeedOptions()
    {
        Contributors = new DataSeedContributorList();
    }
}
