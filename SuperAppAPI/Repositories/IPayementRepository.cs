using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;

namespace SuperAppAPI.Repositories
{
    public interface IPayementRepository 
    {
        Task<List<PayementMethods>> GetAllPayementMethodsAsync();

        Task<bool> CreatePaymentAsync(PayementRequestDto requestDto);


    }
}
