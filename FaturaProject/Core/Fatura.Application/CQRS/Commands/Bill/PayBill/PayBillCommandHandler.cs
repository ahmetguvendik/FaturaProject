using System;
using Fatura.Application.Repositories;
using MediatR;

namespace Fatura.Application.CQRS.Commands.Bill.PayBill
{
	public class PayBillCommandHandler : IRequestHandler<PayBillCommandRequest,PayBillCommandResponse>
	{
        private readonly IBillWriteRepository _writeRepository;
        private readonly IBillReadRepository _readRepository;
            
		public PayBillCommandHandler(IBillWriteRepository writeRepository,IBillReadRepository readRepository)
		{
            _writeRepository = writeRepository;
            _readRepository = readRepository;
		}

        public async Task<PayBillCommandResponse> Handle(PayBillCommandRequest request, CancellationToken cancellationToken)
        {
            if(request.CardDateTıme != null && request.CardNumaber != null && request.CVC != null)
            {
                //Domain.Entities.Bill bill = new Domain.Entities.Bill();
                var bill = await _readRepository.GetByBillId(request.Id);
                bill.IsPay = true;
                await _writeRepository.SaveAsync();
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

