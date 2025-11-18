using Microsoft.EntityFrameworkCore;
using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;

namespace SuperAppAPI.Repositories
{
    public class SQLPayementRepository : IPayementRepository
    {
        private readonly SuperAppDbContext superAppDbContext;

        public SQLPayementRepository(SuperAppDbContext superAppDbContext)
        {
            this.superAppDbContext = superAppDbContext;
        }

        public async Task<bool> CreatePaymentAsync(PayementRequestDto requestDto)
        {
            using var transaction = await superAppDbContext.Database.BeginTransactionAsync();

            try
            {
                var plan = await superAppDbContext.Plans.FirstOrDefaultAsync(x => x.PlansDomainId == requestDto.PlansDomainId);
                if (plan == null) 
                {
                    throw new Exception("plan Not found");
                }

                var payement = new Payements
                {
                    PayementMethodsId = requestDto.PayementMethodsId,
                    PlansDomainId = requestDto.PlansDomainId,
                    Cost = plan.Cost,
                    PaymentDate = DateTime.UtcNow,
                    Remarks = requestDto.Remarks,
                    UserId = requestDto.UserId,
                    
                };

                await superAppDbContext.Payements.AddAsync(payement);
                await superAppDbContext.SaveChangesAsync();

                // 3️⃣ Update Subscription status
                var subscription = await superAppDbContext.SubscribedPlans
                    .FirstOrDefaultAsync(s => s.UserId == requestDto.UserId && s.PlansDomainId == requestDto.PlansDomainId);

                if (subscription != null)
                {
                    subscription.Status = "Active"; // or "Purchased"
                    superAppDbContext.SubscribedPlans.Update(subscription);
                }
                else
                {
                    var startDate = DateTime.UtcNow;
                    // or create if not exists
                    superAppDbContext.SubscribedPlans.Add(new SubscribedPlans
                    {
                        UserId = requestDto.UserId,
                        PlansDomainId = requestDto.PlansDomainId,
                        Cost = plan.Cost,
                        Status = "Active",
                        StartDate = DateTime.UtcNow,
                        PlanName = plan.PlanName,
                        Validity= plan.Validity,
                        EndDate = startDate.AddDays(plan.Validity)
                    });
                }

                await superAppDbContext.SaveChangesAsync();

                // ✅ Commit
                await transaction.CommitAsync();
                return true;

            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

        }

        public async Task<List<PayementMethods>> GetAllPayementMethodsAsync()
        {
            return await superAppDbContext.PayementMethods.ToListAsync();
        }
    }
}
