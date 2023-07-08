using System;
using MediatR;

namespace Fatura.Application.CQRS.Commands.Bill.PayBill
{
	public class PayBillCommandRequest : IRequest<PayBillCommandResponse>
	{
		public string CardNumaber { get; set; }
		public string CardDateTıme { get; set; }
		public string CVC { get; set; }
	}
}

