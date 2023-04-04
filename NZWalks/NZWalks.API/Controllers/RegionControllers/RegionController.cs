using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain.Regions;
using NZWalks.API.Models.DTO.DTORegion;
using NZWalks.API.Services.Interfaces.IRegions;

namespace NZWalks.API.Controllers.RegionControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : Controller
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepositories regionRepositories;
        private readonly IMapper mapper;

        public RegionController(NZWalksDbContext dbContext, IRegionRepositories regionRepositories, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepositories = regionRepositories;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get Data From Database Domail Model
            var regionDomain = await regionRepositories.GetAllAsync();

            //Map Domain model to DTO
            //var regionDto = new List<RegionDTO>();
            //foreach (var region in regionDomain)
            //{
            //    regionDto.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImgUrl = region.RegionImgUrl
            //    });
            //}

            var regionDTO = mapper.Map<List<Region>>(regionDomain);

            //Return DTO
            return Ok(regionDTO);
        }

        // GET SINGLE REGION BY ID
        // https://localhost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            //Get RegionById Domain Models from Database
            var regionsDomain = await regionRepositories.GetByIdAsycn(Id);
            if (regionsDomain == null)
            {
                return NotFound();
            }

            //Map Domain Models to DTO
            //var regionDto = new RegionDTO
            //{
            //    Id = regionsDomain.Id,
            //    Code = regionsDomain.Code,
            //    Name = regionsDomain.Name,
            //    RegionImgUrl = regionsDomain.RegionImgUrl
            //};
            //Return DTO Back To Client

            var regionDTO = mapper.Map<RegionDTO>(regionsDomain);

            return Ok(regionsDomain);
        }
        //POST TO DATABASE
        // https://localhost:portnumber/api/regions/{id}
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            //Map DTO to Domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = addRegionRequestDto.Code,
            //    Name = addRegionRequestDto.Name,
            //    RegionImgUrl = addRegionRequestDto.RegionImgUrl
            //};

            var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

            //USe Domain Model To Create Region
            regionDomainModel = await regionRepositories.CreateAsycn(regionDomainModel);

            //Map Domain Model back To DTO
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImgUrl = regionDomainModel.RegionImgUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            // Return untuk menampilkan hasil data yg sudah disimpan di database
            return CreatedAtAction(nameof(GetById), new { Id = regionDomainModel.Id }, regionDTO);
        }

        //UPDATE TO DATABASE
        //PUT to database
        // https://localhots:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{Id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // Map DTO To Domain Model
            //var regionDomainModel = new Region
            //{
            //    Code = updateRegionRequestDto.Code,
            //    Name = updateRegionRequestDto.Name,
            //    RegionImgUrl = updateRegionRequestDto.RegionImgUrl
            //};


            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepositories.UpdateAsycn(Id, regionDomainModel);

            //Cek If region Exist
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            // Domain Model To DTO
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImgUrl = regionDomainModel.RegionImgUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }

        // DELETE Region
        // Delete https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var regionDomainModel = await regionRepositories.DeleteAsycn(Id);
            //Cek If Exist Data on Database
            if (regionDomainModel == null)
            {
                return NotFound();
            }

            //Return Delete Region
            // Map Domain Model to DTO
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImgUrl = regionDomainModel.RegionImgUrl
            //};

            var regionDTO = mapper.Map<RegionDTO>(regionDomainModel);

            return Ok(regionDTO);
        }
    }
}
