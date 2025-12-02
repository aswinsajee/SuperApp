using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;
using SuperAppAPI.Repositories;

namespace SuperAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubUsersController : ControllerBase
    {
        private readonly SuperAppDbContext dbContext;
        private readonly ISubUserRepository subUserRepository;
        private readonly IMapper mapper;

        public SubUsersController(SuperAppDbContext dbContext, ISubUserRepository subUserRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.subUserRepository = subUserRepository;
            this.mapper = mapper;
        }

        [HttpPost]

        public async Task<IActionResult> CreateSubUsers([FromBody] SubUserRequestDTO subUserRequestDTO) 
        {
            var subUsersDomain = await subUserRepository.CreateSubUsersAsync(subUserRequestDTO);

            var subUsersDto = mapper.Map<List<SubUserRequestDTO>>(subUsersDomain);

            return Ok(subUsersDto);
        }

        [HttpGet]
        [Route("{UserId:Guid}")]
        public async Task<IActionResult> GetAllUsers([FromRoute] Guid UserId)
        {
            var subUserDomain = await subUserRepository.GetAllSubUsersAsync(UserId);
            if (subUserDomain.Count == 0) 
            {
                return NotFound("The User list is empty. Please add users.");
            }
            var subUserDto = mapper.Map<List<SubUserResponseDTO>>(subUserDomain);
            return Ok(subUserDto);
        }

        [HttpPut("{SubUserId}")]
        public async Task<IActionResult> EditName(Guid SubUserId, [FromBody] UpdateSubUserDTO model)
        {
            if (model == null || string.IsNullOrWhiteSpace(model.UserName))
                return BadRequest("Invalid data");

            var subUserDomainModel = new UpdateSubUserDomain
            {
                UserName = model.UserName
            };

            var updatedSubUser = await subUserRepository.UpdateSubUserAsync(SubUserId, subUserDomainModel);

            if (updatedSubUser == null)
                return NotFound("SubUser not found");

            // return success
            return Ok(updatedSubUser);
        }

        [HttpGet("test-error")]
        public IActionResult TestError()
        {
            throw new Exception("This is a test exception");
        }

    }
}
