using SuperAppAPI.Models.Domain;

namespace SuperAppAPI.Repositories
{
    public interface IPlansRepository
    {
        Task<List<PlansDomain>> GetAllPlansAsync();
        Task<PlansDomain> GetPlanByIdAsync(Guid PlansDomainId);
    }
}
