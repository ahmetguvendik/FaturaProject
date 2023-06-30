using System;
using Fatura.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Persistance.Contexts
{
	public class BillDbContext : IdentityDbContext<AppUser,AppRole,string>
	{
		public BillDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Bill> Bills { get; set; }	
	}
}

