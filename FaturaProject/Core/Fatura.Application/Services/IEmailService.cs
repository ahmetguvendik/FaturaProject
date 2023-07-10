using System;
namespace Fatura.Application.Services
{
	public interface IEmailService
	{
        public Task SendEmailAsync(string emailAdress, string body);
    }
}

