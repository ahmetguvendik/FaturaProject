using System;
namespace Fatura.Application.CQRS.Commands.Bill.CreateBill
{
	public class CreateBillCommandResponse
	{
        public string BillName { get; set; }
        public int BillPrice { get; set; }
        public string UserId { get; set; }
    }
}

