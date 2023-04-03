using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain.Regions;
using NZWalks.API.Services.Interfaces.IRegions;

namespace NZWalks.API.Services.Repositoreis.RegionRepos
{
    public class RegionRepositories : IRegionRepositories
    {
        private readonly NZWalksDbContext dbContext;

        public RegionRepositories(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsycn(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsycn(Guid Id)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingRegion == null)
            {
                return null;
            }

            dbContext.Regions.Remove(existingRegion);
            await dbContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsycn(Guid Id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Region?> UpdateAsycn(Guid Id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImgUrl = region.RegionImgUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}
