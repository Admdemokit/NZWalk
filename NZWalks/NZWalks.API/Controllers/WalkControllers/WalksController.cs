using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Models.Domain.Walks;
using NZWalks.API.Models.DTO.DTOWalk;
using NZWalks.API.Services.Interfaces.Iwalks;

namespace NZWalks.API.Controllers.WalkControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalksRepositories walksRepositories;

        public WalksController(IMapper mapper, IWalksRepositories walksRepositories)
        {
            this.mapper = mapper;
            this.walksRepositories = walksRepositories;
        }

        // Create Walks
        // POST :/api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {

            // Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walksRepositories.CreateAsync(walkDomainModel);


            // Map Domain Model to DTO
            var walkDTO = mapper.Map<WalksDTO>(walkDomainModel);
            return Ok(walkDTO);
        }

        // GET All Walks
        // GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isascending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 1000)
        {
            var walkDomainModel = await walksRepositories.GetAllAsync(filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize);

            // Map Domain Model To DTO
            var walkDTO = mapper.Map<List<WalksDTO>>(walkDomainModel);

            return Ok(walkDTO);
        }

        // GET WALK BY ID
        // GET htpps://api/walks/{id}
        [HttpGet]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var walkDomainModel = await walksRepositories.GetByIdAsync(Id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //Map Domain Model to DTO
            var walkDTO = mapper.Map<WalksDTO>(walkDomainModel);
            return Ok(walkDTO);
        }

        // Update Walk BY Id
        // PUT :/api/walks/{id}
        [HttpPut]
        [Route("{Id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid Id, UpdateWalkRequestDto updateWalkRequestDto)
        {

            // MAP DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);
            walkDomainModel = await walksRepositories.UpdateAsync(Id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var walksDTO = mapper.Map<WalksDTO>(walkDomainModel);
            return Ok(walksDTO);
        }

        //DELET Walk BY Id
        // Delete : /api/walks/{id}
        [HttpDelete]
        [Route("{Id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var deletedWalkDomainModel = await walksRepositories.DeleteAsync(Id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            // Map Domain Model to DTO
            var deleteWalkDTO = mapper.Map<WalksDTO>(deletedWalkDomainModel);
            return Ok(deleteWalkDTO);
        }
    }
}
