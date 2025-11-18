using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperAppAPI.Models.DTO;
using SuperAppAPI.Repositories;

namespace SuperAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayementController : ControllerBase
    {
        private readonly IPayementRepository payementRepository;
        private readonly IMapper mapper;

        public PayementController(IPayementRepository payementRepository,IMapper mapper)
        {
            this.payementRepository = payementRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayementMethods()
        {
            var payemntDomain = await payementRepository.GetAllPayementMethodsAsync();

            var payemtDto = mapper.Map<List<PayementDto>>(payemntDomain);
            return Ok(payemtDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PayementRequestDto dto)
        {
            var result = await payementRepository.CreatePaymentAsync(dto);

            if (!result)
                return BadRequest("Payment failed");

            return Ok("Payment created and subscription updated successfully");
        }
    }
}
