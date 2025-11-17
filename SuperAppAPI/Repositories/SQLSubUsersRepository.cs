using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using SuperAppAPI.Data;
using SuperAppAPI.Models.Domain;
using SuperAppAPI.Models.DTO;

namespace SuperAppAPI.Repositories
{
    public class SQLSubUsersRepository : ISubUserRepository
    {
        private readonly SuperAppDbContext superAppDbContext;
        private readonly SuperAppAuthDBContext superAppAuthDBContext;

        public SQLSubUsersRepository(SuperAppDbContext superAppDbContext, SuperAppAuthDBContext superAppAuthDBContext) 
        {
            this.superAppDbContext = superAppDbContext;
            this.superAppAuthDBContext = superAppAuthDBContext;
        }

        public async Task<List<SubUsers>> CreateSubUsersAsync(SubUserRequestDTO subUserRequestDTO)
        {
            using var transaction = await superAppDbContext.Database.BeginTransactionAsync();

            try
            {
                var  isValidUser = await superAppDbContext.SubscribedPlans.FirstOrDefaultAsync(x => x.UserId == subUserRequestDTO.UserId);

                if (isValidUser == null) 
                {
                    throw new Exception("User Is not subscribed any plan");
                }
                var subUsers = new List<SubUsers>
                {
                    new SubUsers
                    {
                         UserId = subUserRequestDTO.UserId,
                         SubscribedPlansId = subUserRequestDTO.SubscribedPlansId,
                         UserName = subUserRequestDTO.UserName
                    }
                };

                await superAppDbContext.SubUsers.AddRangeAsync(subUsers);
                await superAppDbContext.SaveChangesAsync();
                await transaction.CommitAsync();
                return subUsers;

            }
            catch (Exception ex) 
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<SubUsers>> GetAllSubUsersAsync(Guid UserId)
        {
            try
            {
                var subUsers = await superAppDbContext.SubUsers
                    .FromSqlRaw("EXEC GetAllSubUsersByUserId @UserId = {0}", UserId)
                    .ToListAsync();

                if (subUsers == null || !subUsers.Any())
                {
                    throw new Exception("The User list is empty. Please add users.");
                }

                return subUsers;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching sub users.", ex);
            }
        }

        public async Task<SubUsers?> UpdateSubUserAsync(Guid SubUserId, UpdateSubUserDomain model)
        {
            var existingSubUser = await superAppDbContext.SubUsers.FirstOrDefaultAsync(x=>x.SubUserId == SubUserId);

            if (existingSubUser == null)
            {
                return null;
            }

            existingSubUser.UserName = model.UserName;

            await superAppDbContext.SaveChangesAsync();
            return existingSubUser;
        }
    }
}
