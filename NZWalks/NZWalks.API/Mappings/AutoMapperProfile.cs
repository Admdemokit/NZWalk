using AutoMapper;
using NZWalks.API.Models.Domain.Difficultys;
using NZWalks.API.Models.Domain.Regions;
using NZWalks.API.Models.Domain.Walks;
using NZWalks.API.Models.DTO.DTODifficulty;
using NZWalks.API.Models.DTO.DTORegion;
using NZWalks.API.Models.DTO.DTOWalk;

namespace NZWalks.API.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk, WalksDTO>().ReverseMap();
            CreateMap<Difficulty, DifficultyDTO>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();
        }
    }
}
