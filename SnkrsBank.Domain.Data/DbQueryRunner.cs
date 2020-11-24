namespace SnkrsBank.Domain.Data
{
    using Microsoft.EntityFrameworkCore;
    using SnkrsBank.Domain.Common;
    using System;

    public class DbQueryRunner : IDbQueryRunner
    {
        public DbQueryRunner(SnkrsBankDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public SnkrsBankDbContext Context { get; set; }

        public void RunQuery(string query, params object[] parameters)
        {
            this.Context.Database.ExecuteSqlRaw(query, parameters);
        }

        public void Dispose()
        {
            this.Context?.Dispose();
        }
    }
}
