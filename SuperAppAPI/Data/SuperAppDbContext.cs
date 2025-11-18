using Microsoft.EntityFrameworkCore;
using SuperAppAPI.Models.Domain;

namespace SuperAppAPI.Data
{
    public class SuperAppDbContext : DbContext
    {
        public SuperAppDbContext(DbContextOptions<SuperAppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<OTTDomain> OTTPlatforms { get; set; }
        public DbSet<PayementMethods> PayementMethods { get; set; }
        public DbSet<Payements> Payements { get; set; } 
        public DbSet<PlansDomain> Plans {  get; set; }

        public DbSet<SubscribedPlans> SubscribedPlans { get; set; }

        public DbSet<SubUsers> SubUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
