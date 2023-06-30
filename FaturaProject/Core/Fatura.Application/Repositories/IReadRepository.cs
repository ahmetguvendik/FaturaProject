using System;
using Fatura.Domain.Entities;

namespace Fatura.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : Bill
    {
		IQueryable GetAll();
		Task<T> GetById(string id);
	}
}

