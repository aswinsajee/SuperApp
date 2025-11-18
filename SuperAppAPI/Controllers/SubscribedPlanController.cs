using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;
using SuperAppAPI.Repositories;

namespace SuperAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribedPlanController : ControllerBase
    {
        private readonly ISubscribedPlansRepostiory subscribedPlansRepostiory;
        private readonly IMapper mapper;

        public SubscribedPlanController(ISubscribedPlansRepostiory subscribedPlansRepostiory,IMapper mapper)
        {
            this.subscribedPlansRepostiory = subscribedPlansRepostiory;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("{UserId:Guid}")]

        public async Task<IActionResult> GetSubscribedPlanByID([FromRoute] Guid UserId) 
        {
            var subscribedPlanDomain = await subscribedPlansRepostiory.GetSubscribedPlansAsync(UserId);
            if (subscribedPlanDomain == null) 
            {
                return NotFound("User has not subscribed to any plan or the subscription has expired.");
            }

            var subscribedPlanDto = mapper.Map<SubscribedPlanDto>(subscribedPlanDomain);
            return Ok(subscribedPlanDto);
        }
    }
}
