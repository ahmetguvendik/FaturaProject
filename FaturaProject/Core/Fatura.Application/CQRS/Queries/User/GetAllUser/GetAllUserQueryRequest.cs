using System;
using Fatura.Domain.Entities;
using MediatR;

namespace Fatura.Application.CQRS.Queries.User.GetAllUser
{
	public class GetAllUserQueryRequest : IRequest<List<AppUser>>
	{
		
	}
}

