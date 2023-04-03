using NZWalks.API.Models.Domain.Regions;

namespace NZWalks.API.Services.Interfaces.IRegions
{
    public interface IRegionRepositories
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsycn(Guid Id);
        Task<Region> CreateAsycn(Region region);
        Task<Region?> UpdateAsycn(Guid Id, Region region);
        Task<Region?> DeleteAsycn(Guid Id);
    }
}
