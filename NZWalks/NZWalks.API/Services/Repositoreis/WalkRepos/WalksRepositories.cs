using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain.Walks;
using NZWalks.API.Services.Interfaces.Iwalks;

namespace NZWalks.API.Services.Repositoreis.WalkRepos
{
    public class WalksRepositories : IWalksRepositories
    {
        private readonly NZWalksDbContext dbContext;

        public WalksRepositories(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid Id)
        {
            var existingWalks = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);

            if (existingWalks == null)
            {
                return null;
            }

            dbContext.Walks.Remove(existingWalks);
            await dbContext.SaveChangesAsync();
            return existingWalks;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null)
        {
            //return await dbContext.Walks.
            //    Include(d => d.Difficulty).
            //    Include(r => r.Region).
            //    ToListAsync();

            var walks = dbContext.Walks.
                Include(d => d.Difficulty).
                Include(r => r.Region).AsQueryable();

            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }

            return await walks.ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Walks.
                Include(x => x.Difficulty).
                Include(x => x.Region).
                FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Walk?> UpdateAsync(Guid Id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalksImgUrl = walk.WalksImgUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingWalk;
        }
    }
}
