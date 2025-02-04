using Microsoft.AspNetCore.Identity;

namespace Dotnet.Modular.Modules.Identity.Exceptions;

public class IdentityException : Exception
{
    public override string Message { get; }

    public IdentityException(IdentityResult result)
    {
        Message = string.Join("\n", result.Errors.Select(x => x.Description));
    }
}