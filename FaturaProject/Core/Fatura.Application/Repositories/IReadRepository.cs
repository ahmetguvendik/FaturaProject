using System;
using Fatura.Application.ViewModel;
using Fatura.Domain.Entities;

namespace Fatura.Application.Repositories
{
	public interface IReadRepository<T> : IRepository<T> where T : Bill
    {
		IQueryable GetAll();
        List<BillUserViewModel> GetById(string id);
        IQueryable<UserRoleViewModel> GetUserRole();
        Task<T> GetByBillId(string id);

    }
}

