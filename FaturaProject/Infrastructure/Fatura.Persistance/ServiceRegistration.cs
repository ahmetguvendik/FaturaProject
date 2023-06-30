using System;
using Fatura.Application.Repositories;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;
using Fatura.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fatura.Persistance
{
	public static class ServiceRegistration
	{
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<BillDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=FaturaDb;"));
            collection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BillDbContext>();
            collection.AddScoped<IBillReadRepository,BillReadRepository>();
            collection.AddScoped<IBillWriteRepository, BillWriteRepository>();
        }

    }
}

