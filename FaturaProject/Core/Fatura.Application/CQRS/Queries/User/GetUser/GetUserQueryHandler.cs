using System;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Application.CQRS.Queries.User.GetUser
{
	public class GetUserQueryHandler : IRequestHandler<GetUserQueryRequest,GetUserQueryResponse>
	{
        private readonly UserManager<AppUser> _userManager;
		public GetUserQueryHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<GetUserQueryResponse> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManager.Users.ToListAsync();
            return new GetUserQueryResponse()
            {
                Users = users
            };
        }
    }
}

