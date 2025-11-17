using SuperAppAPI.Models.Domain;


namespace SuperAppAPI.Repositories
{
    public interface ISubscribedPlansRepostiory
    {
        Task<SubscribedPlans>GetSubscribedPlansAsync(Guid UserId);
    }
}
