using System;
using Fatura.Domain.Entities;
using MediatR;

namespace Fatura.Application.CQRS.Queries.User.GetAllRole
{
	public class GetAllRoleQueryRequest : IRequest<List<AppRole>>
	{
	
	}
}

