namespace Dotnet.Modular.Modules.EntityFramework;

public class DataContextOptions
{

    public void Configure(Action<DataContextConfigurationContext> action)
    {
        DefaultConfigureAction = action;
    }

    public void Configure<TDbContext>(Action<ApplicationDbContextConfigurationContext<TDbContext>> action)
        where TDbContext : DataContext<TDbContext>
    {

        ConfigureActions[typeof(TDbContext)] = action;
    }

    internal Action<DataContextConfigurationContext> DefaultConfigureAction { get; set; }

    internal Dictionary<Type, object> ConfigureActions { get; } = new();

    internal Dictionary<Type, Type> DbContextReplacements { get; } = new();


    internal Type GetReplacedTypeOrSelf(Type dbContextType)
    {
        var replacementType = dbContextType;
        while (true)
        {
            if (DbContextReplacements.TryGetValue(replacementType, out var foundType))
            {
                if (foundType == dbContextType)
                {
                    throw new Exception(
                        "Circular DbContext replacement found for " +
                        dbContextType.AssemblyQualifiedName
                    );
                }

                replacementType = foundType;
            }
            else
            {
                return replacementType;
            }
        }
    }
}