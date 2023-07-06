using System;
using Fatura.Application.ViewModel;
using Fatura.Domain.Entities;

namespace Fatura.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : Bill
    {
		List<BillUserViewModel> GetAll();
        List<BillUserViewModel> GetById(string id);
	}
}

