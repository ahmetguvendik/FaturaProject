using System;
using Fatura.Application.ViewModel;
using MediatR;

namespace Fatura.Application.CQRS.Queries.Bill.GetUserRole
{
	public class GetUserRoleQueryRequest : IRequest<IQueryable<UserRoleViewModel>>
	{
		
	}
}

