using System;
using Fatura.Application.Repositories;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : Bill
    {
        private readonly BillDbContext _context;
        public ReadRepository(BillDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable GetAll()
        {
            return Table;
        }

        public async Task<T> GetById(string id)
        {
            return await Table.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}

