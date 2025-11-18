using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperAppAPI.Data;
using SuperAppAPI.Models.DTO;
using SuperAppAPI.Repositories;

namespace SuperAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly SuperAppDbContext dbContext;
        private readonly IPlatformRepository platformRepository;
        private readonly IMapper mapper;

        public PlatformController(SuperAppDbContext dbContext,IPlatformRepository platformRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.platformRepository = platformRepository;
            this.mapper = mapper;
        }

        //GET https://localhost:portnumber/api/Platform/GetALL

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var platformDomain = await platformRepository.GetAllPlatformsAsync();

            var platformDto = mapper.Map<List<PlatformDTO>>(platformDomain); 

            return Ok(platformDto);

        }
        [HttpGet]
        [Route("{PlatformId:Guid}")]
       
        public async Task<IActionResult> GetPlatformById([FromRoute] Guid PlatformId)
        {
            var platformDomain = await platformRepository.GetPlatformByIdsAsync(PlatformId);

            if (platformDomain == null) 
            {
                return NotFound("No platform found");
            }

            var platformDto = mapper.Map<PlatformDTO>(platformDomain);
            return Ok(platformDto);
        }

        
    }
}
