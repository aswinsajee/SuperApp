using Microsoft.EntityFrameworkCore;
using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;

namespace SuperAppAPI.Repositories
{
    public class SQLPlatformRepository : IPlatformRepository
    {
        private readonly SuperAppDbContext superAppDbContext;

        public SQLPlatformRepository(SuperAppDbContext superAppDbContext) 
        {
            this.superAppDbContext = superAppDbContext;
        }
        public async Task<List<OTTDomain>> GetAllPlatformsAsync()
        {
           return await superAppDbContext.OTTPlatforms.ToListAsync();
        }

        public async Task<OTTDomain> GetPlatformByIdsAsync(Guid PlatformId)
        {
            var platform = await superAppDbContext.OTTPlatforms.FirstOrDefaultAsync(x => x.Id == PlatformId);

            if (platform == null) 
            {
                throw new Exception("No PlatformFound");

            }
            return platform;
        }
    }
}
