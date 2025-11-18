using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;

namespace SuperAppAPI.Repositories
{
    public interface ISubUserRepository
    {
        Task<List<SubUsers>> CreateSubUsersAsync(SubUserRequestDTO subUserRequestDTO);

        Task<List<SubUsers>> GetAllSubUsersAsync(Guid UserId);

        Task<SubUsers?> UpdateSubUserAsync(Guid SubUserId, UpdateSubUserDomain model);
    }
}
