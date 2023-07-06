using System;
using Fatura.Domain.Entities;

namespace Fatura.Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandResponse
	{
        public int TcNo { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }   
}

