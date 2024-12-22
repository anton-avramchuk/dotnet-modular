using Microsoft.Extensions.Logging;

namespace Dotnet.Modular.Core.Logging;

public interface IExceptionWithSelfLogging
{
    void Log(ILogger logger);
}
