using System;
using MediatR;

namespace Fatura.Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandRequest : IRequest<LoginUserCommandResponse>
	{
		public string Id { get; set; }
		public string UserName { get; set; }	
		public string Password { get; set; }
	}
}

