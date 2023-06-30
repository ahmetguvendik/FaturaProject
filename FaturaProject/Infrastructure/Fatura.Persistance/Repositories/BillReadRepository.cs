using System;
using System.Reflection.Metadata;
using Fatura.Application.Repositories;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;

namespace Fatura.Persistance.Repositories
{
	public class BillReadRepository : ReadRepository<Bill>, IBillReadRepository
    {
        public BillReadRepository(BillDbContext context) : base(context)
        {

        }
    }
}

