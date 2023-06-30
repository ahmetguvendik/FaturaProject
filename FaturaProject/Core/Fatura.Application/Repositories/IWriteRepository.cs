using System;
using Fatura.Domain.Entities;

namespace Fatura.Application.Repositories
{
	public interface IWriteRepository<T> : IRepository<T> where T: Bill
	{
		Task AddAsync(T model);
		Task RemoveAsync(string id);
		Task UpdateAsync(T model);
		Task SaveAsync();
	}
}

