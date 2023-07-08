using System;
using MediatR;

namespace Fatura.Application.CQRS.Queries.User.GetUser
{
	public class GetUserQueryRequest : IRequest<GetUserQueryResponse>
	{
		public GetUserQueryRequest()
		{
		}
	}
}

