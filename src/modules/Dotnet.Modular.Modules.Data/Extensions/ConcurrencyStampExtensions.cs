using Dotnet.Modular.Core.Extensions.Common;
using Dotnet.Modular.Modules.Data.Abstractions.Entities;

namespace Dotnet.Modular.Modules.Data.Extensions;

public static class ConcurrencyStampExtensions
{
    public static void SetConcurrencyStampIfNotNull(this IHasConcurrencyStamp entity, string? concurrencyStamp)
    {
        if (!concurrencyStamp.IsNullOrEmpty())
        {
            entity.ConcurrencyStamp = concurrencyStamp!;
        }
    }
}
