namespace Dotnet.Modular.Modules.Domain.Common
{
    public interface ILastUpdatedTrackedEntity
    {
        public DateTime? LastUpdatedAt { get; set; }
    }
}
