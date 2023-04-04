using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain.Difficultys;
using NZWalks.API.Models.Domain.Regions;
using NZWalks.API.Models.Domain.Walks;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> options) : base(options)
        {
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id=Guid.NewGuid(),
                    Name="Easy"
                },
                new Difficulty()
                {
                    Id=Guid.NewGuid(),
                    Name="Medium"
                },
                new Difficulty()
                {
                    Id=Guid.NewGuid(),
                    Name="Hard"
                }
            };

            // Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //seed data for Regions
            var regions = new List<Region>
            {
                new Region
                {
                   Id=Guid.NewGuid(),
                   Name="Japan",
                   Code="JPN",
                   RegionImgUrl="https://images.pexels.com/photos/1440476/pexels-photo-1440476.jpeg"
                },
                new Region
                {
                   Id=Guid.NewGuid(),
                   Name="West Java",
                   Code="WJAV",
                   RegionImgUrl="https://images.pexels.com/photos/2916337/pexels-photo-2916337.jpeg"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImgUrl = null
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImgUrl = null
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImgUrl = "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImgUrl = "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1"
                },
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
