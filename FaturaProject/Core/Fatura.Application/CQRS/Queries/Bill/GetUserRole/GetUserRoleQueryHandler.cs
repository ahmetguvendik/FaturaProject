using System;
using Fatura.Application.Repositories;
using Fatura.Application.ViewModel;
using MediatR;

namespace Fatura.Application.CQRS.Queries.Bill.GetUserRole
{
	public class GetUserRoleQueryHandler : IRequestHandler<GetUserRoleQueryRequest, IQueryable<UserRoleViewModel>>
	{
        private readonly IBillReadRepository _billReadRepository;
		public GetUserRoleQueryHandler(IBillReadRepository billReadRepository)
		{
            _billReadRepository = billReadRepository;
		}

        public async Task<IQueryable<UserRoleViewModel>> Handle(GetUserRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var response = _billReadRepository.GetUserRole();
            return response;
        }
    }
}

