using System;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Fatura.Application.CQRS.Queries.User.GetAllUser
{
	public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, List<AppUser>>
	{
        private readonly UserManager<AppUser> _userManager;
		public GetAllUserQueryHandler(UserManager<AppUser> userManager)
		{
            _userManager = userManager;
		}

        public async Task<List<AppUser>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.ToList();
            return users;
        }
    }
}

