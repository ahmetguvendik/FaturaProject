using System;
using MediatR;

namespace Fatura.Application.CQRS.Commands.Bill.PayBill
{
	public class PayBillCommandHandler : IRequestHandler<PayBillCommandRequest,PayBillCommandResponse>
	{
		public PayBillCommandHandler()
		{

		}

        public async Task<PayBillCommandResponse> Handle(PayBillCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.CardDateTıme != null && request.CardNumaber != null && request.CVC != null)
            {
                return new PayBillCommandResponse()
                {
                    IsPay = true
                };
            }

            else
            {
                return new PayBillCommandResponse()
                {
                    IsPay = false
                };
            }
        }
    }
}

