using System;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Fatura.Application.CQRS.Queries.User.GetAllRole
{ 
	public class GetAllRoleQueryHandler : IRequestHandler<GetAllRoleQueryRequest,List<AppRole>>
	{
        private readonly RoleManager<AppRole> _roleManager;
		public GetAllRoleQueryHandler(RoleManager<AppRole> roleManager)
		{
            _roleManager = roleManager;
		}

        public async Task<List<AppRole>> Handle(GetAllRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = _roleManager.Roles.ToList();
            return roles;
        }
    }
}

