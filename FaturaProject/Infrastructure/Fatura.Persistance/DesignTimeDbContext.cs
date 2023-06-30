using System;
using Fatura.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Fatura.Persistance
{
	public class DesignTimeDbContext : IDesignTimeDbContextFactory<BillDbContext>
    {
		public DesignTimeDbContext()
		{
		}

        public BillDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BillDbContext> dbContextOptions = new();
            dbContextOptions.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=FaturaDb;");
            return new(dbContextOptions.Options);
        }
    }
}

