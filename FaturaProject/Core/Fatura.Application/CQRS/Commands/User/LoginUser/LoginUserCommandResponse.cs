using System;
namespace Fatura.Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandResponse
	{
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}

