using System;
using Fatura.Application.Repositories;
using Fatura.Domain.Entities;
using Fatura.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Fatura.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : Bill
    {
        private readonly BillDbContext _context;
        public WriteRepository(BillDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task AddAsync(T model)
        {
           await Table.AddAsync(model);
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityState = Table.Remove(model);
            return entityState.State == EntityState.Deleted;
        }

        public async Task RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
            
        }

        public Task UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }
    }
}

