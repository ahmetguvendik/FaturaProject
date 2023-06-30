using System;
using Fatura.Application.Repositories;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;

namespace Fatura.Persistance.Repositories
{
	public class BillWriteRepository : WriteRepository<Bill>, IBillWriteRepository
	{
        public BillWriteRepository(BillDbContext context) : base(context)
        {

        }
    }
}

