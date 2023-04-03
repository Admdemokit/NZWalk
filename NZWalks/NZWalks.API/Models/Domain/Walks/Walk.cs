using NZWalks.API.Models.Domain.Difficultys;
using NZWalks.API.Models.Domain.Regions;

namespace NZWalks.API.Models.Domain.Walks
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalksImgUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //Navigation property
        public Difficulty Difficulty { get; set; }
        public Region Region { get; set; }

    }
}
