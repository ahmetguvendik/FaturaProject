using System;
using Microsoft.AspNetCore.Identity;

namespace Fatura.Domain.Entities
{
	public class AppRole : IdentityRole<string>
    {
		public AppRole()
		{
		}
	}
}

