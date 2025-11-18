using Microsoft.EntityFrameworkCore;
using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;

namespace SuperAppAPI.Repositories
{
    public class SQLPlansRepository : IPlansRepository
    {
        private readonly SuperAppDbContext superAppDbContext;

        public SQLPlansRepository(SuperAppDbContext superAppDbContext) 
        {
            this.superAppDbContext = superAppDbContext;
        }

        public async Task<List<PlansDomain>> GetAllPlansAsync()
        {
            return await superAppDbContext.Plans.ToListAsync();
        }

        public async Task<PlansDomain> GetPlanByIdAsync(Guid PlansDomainId)
        {
            var plan = await superAppDbContext.Plans
                .FirstOrDefaultAsync(x => x.PlansDomainId == PlansDomainId);

            if (plan == null)
            {
                throw new Exception("Plan not found");
            }

            return plan;
        }

    }
}
