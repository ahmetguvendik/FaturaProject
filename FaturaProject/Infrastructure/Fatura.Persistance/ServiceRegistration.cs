using System;
using Fatura.Application.Repositories;
using Fatura.Application.Services;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;
using Fatura.Persistance.Repositories;
using Fatura.Persistance.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Fatura.Persistance
{
	public static class ServiceRegistration
	{
        public static void AddPersistanceService(this IServiceCollection collection)
        {
            collection.AddDbContext<BillDbContext>(opt => opt.UseNpgsql("User ID=postgres;Password=123456;Host=localhost;Port=5432;Database=FaturaDb;"));
            collection.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<BillDbContext>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);
            collection.AddScoped<IBillReadRepository,BillReadRepository>();
            collection.AddScoped<IBillWriteRepository, BillWriteRepository>();
            collection.AddScoped<IEmailService, EmailService>();
        }

    }
}

