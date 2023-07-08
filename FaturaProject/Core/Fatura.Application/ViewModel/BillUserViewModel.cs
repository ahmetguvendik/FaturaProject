using System;
namespace Fatura.Application.ViewModel
{
	public class BillUserViewModel
	{
		public string Id { get; set; }	
		public string Name { get; set; }
		public double Price { get; set; }
		public string UserName { get; set; }
		public bool IsPay { get; set; }	
	}
}

