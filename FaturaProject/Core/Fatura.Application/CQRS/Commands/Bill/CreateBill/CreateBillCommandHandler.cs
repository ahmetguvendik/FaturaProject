using System;
using Fatura.Application.Repositories;
using MediatR;

namespace Fatura.Application.CQRS.Commands.Bill.CreateBill
{
	public class CreateBillCommandHandler :IRequestHandler<CreateBillCommandRequest,CreateBillCommandResponse>
	{
        private readonly IBillWriteRepository _writeRepository;
		public CreateBillCommandHandler(IBillWriteRepository writeRepository)
		{
            _writeRepository = writeRepository;
		}

        public async Task<CreateBillCommandResponse> Handle(CreateBillCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Bill bill = new Domain.Entities.Bill();
            bill.Id = Guid.NewGuid().ToString();    
            bill.Name = request.BillName;
            bill.Price = request.BillPrice;
            bill.UserId = request.UserId;
            bill.IsPay = false;
            await _writeRepository.AddAsync(bill);
            await _writeRepository.SaveAsync();
            return new CreateBillCommandResponse()
            {
                BillName = request.BillName,
                BillPrice = request.BillPrice,
                UserId = request.UserId
            };
        }
    }
}

