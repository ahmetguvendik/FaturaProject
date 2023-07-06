using System;
using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Fatura.Application
{
	public static class ServiceRegistration
    {
        public static void AddMediatorService(this IServiceCollection services)
        {
           services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistration).GetTypeInfo().Assembly));
        }
    }
}

