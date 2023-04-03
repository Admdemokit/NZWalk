using NZWalks.API.Models.DTO.DTODifficulty;
using NZWalks.API.Models.DTO.DTORegion;

namespace NZWalks.API.Models.DTO.DTOWalk
{
    public class WalksDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalksImgUrl { get; set; }


        public RegionDTO Region { get; set; }
        public DifficultyDTO Difficulty { get; set; }
    }
}
