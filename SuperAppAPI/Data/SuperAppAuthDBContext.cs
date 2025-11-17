using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SuperAppAPI.Data
{
    public class SuperAppAuthDBContext :IdentityDbContext
    {
        public SuperAppAuthDBContext(DbContextOptions<SuperAppAuthDBContext> options) : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = "4efcc711-effa-4848-b3ec-08eed3e9112f";
            var writerRoleId = "f940795a-2b02-43e8-a104-886fcecb26f2";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()

                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()

                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
