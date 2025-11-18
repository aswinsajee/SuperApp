using SuperAppAPI.Models.Domain;

namespace SuperAppAPI.Repositories
{
    public interface IPlatformRepository
    {
        Task<List<OTTDomain>> GetAllPlatformsAsync();
        Task<OTTDomain> GetPlatformByIdsAsync(Guid PlatformId);
       
    }
}
