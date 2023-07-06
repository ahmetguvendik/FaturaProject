using System;
using MediatR;

namespace Fatura.Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandRequest : IRequest<CreateUserCommandResponse>
	{
		public int TcNo { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		
	}
}

