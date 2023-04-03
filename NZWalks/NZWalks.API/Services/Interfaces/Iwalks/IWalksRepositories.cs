using NZWalks.API.Models.Domain.Walks;

namespace NZWalks.API.Services.Interfaces.Iwalks
{
    public interface IWalksRepositories
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null);
        Task<Walk?> GetByIdAsync(Guid Id);
        Task<Walk?> UpdateAsync(Guid Id, Walk walk);
        Task<Walk?> DeleteAsync(Guid Id);
    }
}
