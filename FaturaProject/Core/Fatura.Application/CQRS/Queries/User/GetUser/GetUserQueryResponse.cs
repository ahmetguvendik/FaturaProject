using System;
using Fatura.Domain.Entities;

namespace Fatura.Application.CQRS.Queries.User.GetUser
{
	public class GetUserQueryResponse
	{
		public object Users { get; set; }	
	}
}

