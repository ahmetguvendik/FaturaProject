using System;
using Microsoft.AspNetCore.Identity;

namespace Fatura.Domain.Entities
{
	public class AppUser : IdentityUser<string>
    {
		public int TCNo { get; set; }
        public List<Bill> Bill { get; set; }
        public int BillId { get; set; }
    }
}

