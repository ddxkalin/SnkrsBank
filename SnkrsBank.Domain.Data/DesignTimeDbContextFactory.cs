namespace SnkrsBank.Domain.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    using System.IO;
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SnkrsBankDbContext>
    {
        public SnkrsBankDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var builder = new DbContextOptionsBuilder<SnkrsBankDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);

            // Stop client query evaluation
            //builder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new SnkrsBankDbContext(builder.Options);
        }
    }
}