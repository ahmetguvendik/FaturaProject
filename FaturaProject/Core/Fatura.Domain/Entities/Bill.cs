using System;
namespace Fatura.Domain.Entities
{
	public class Bill
	{
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public AppUser User { get; set; }
        public string UserId { get; set; }
        public bool IsPay { get; set; }
    }
}

