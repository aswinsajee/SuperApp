using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperAppAPI.Models.DTO;
using SuperAppAPI.Repositories;

namespace SuperAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IPlansRepository plans;

        public PlansController(IMapper mapper, IPlansRepository plans)
        {
            this.mapper = mapper;
            this.plans = plans;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPlans()
        {
            var plansDomain = await plans.GetAllPlansAsync();

            var plansDto = mapper.Map<List<PlansDto>>(plansDomain);

            return Ok(plansDto);
        }
        [HttpGet]
        [Route("{PlansDomainId:Guid}")]

        public async Task<IActionResult> GetPlansByID([FromRoute] Guid PlansDomainId)
        {
            var selectedPlanDomain = await plans.GetPlanByIdAsync(PlansDomainId);

            var selectedPlanDto = mapper.Map<PlansDto>(selectedPlanDomain);

            return Ok(selectedPlanDto);
        }
    }
}
