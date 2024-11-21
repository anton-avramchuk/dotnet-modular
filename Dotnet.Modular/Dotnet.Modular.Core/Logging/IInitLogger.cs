using Microsoft.Extensions.Logging;

namespace Dotnet.Modular.Core.Logging;

public interface IInitLogger<out T> : ILogger<T>
{
    public List<InitLogEntry> Entries { get; }
}
