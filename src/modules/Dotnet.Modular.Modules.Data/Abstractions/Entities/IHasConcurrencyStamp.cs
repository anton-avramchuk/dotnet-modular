namespace Dotnet.Modular.Modules.Data.Abstractions.Entities;

public interface IHasConcurrencyStamp
{
    string ConcurrencyStamp { get; set; }
}
