using Microsoft.EntityFrameworkCore;
using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;

namespace SuperAppAPI.Repositories
{
    public class SQLSubscribedPlansRepository : ISubscribedPlansRepostiory
    {
        private readonly SuperAppDbContext superAppDbContext;

        public SQLSubscribedPlansRepository(SuperAppDbContext superAppDbContext) 
        {
            this.superAppDbContext = superAppDbContext;
        }

        public async Task<SubscribedPlans> GetSubscribedPlansAsync(Guid UserId)
        {

            var plans = await superAppDbContext.SubscribedPlans
            .FirstOrDefaultAsync(x => x.UserId == UserId);
            

            

            return plans;
        }
    }
}
