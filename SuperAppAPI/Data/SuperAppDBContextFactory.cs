using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SuperAppAPI.Data
{
    public class SuperAppDbContextFactory : IDesignTimeDbContextFactory<SuperAppDbContext>
    {
        public SuperAppDbContext CreateDbContext(string[] args)
        {
            // Load configuration from appsettings.json
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Make sure path is correct
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Build options
            var optionsBuilder = new DbContextOptionsBuilder<SuperAppDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SuperAppConnectionString"));

            return new SuperAppDbContext(optionsBuilder.Options);
        }
    }
}
