using System;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fatura.Application.CQRS.Commands.User.CreateUser
{
	public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest,CreateUserCommandResponse>
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<AppRole> _roleManager;
		public CreateUserCommandHandler(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
		{
			_userManager = userManager;
			_roleManager = roleManager;
		}

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
			var appUser = new AppUser();
			appUser.TCNo = request.TcNo;
            appUser.Id = Guid.NewGuid().ToString();
			appUser.Email = request.Email;
			appUser.UserName = request.UserName;

            var users = await _userManager.Users.SingleOrDefaultAsync(x => x.TCNo == request.TcNo);
			if(users == null)
			{
                var response = await _userManager.CreateAsync(appUser, request.Password);
                if (response.Succeeded)
                {
                    var role = await _roleManager.FindByNameAsync("Member");
                    if (role == null)
                    {
                        var appRole = new AppRole()
                        {
                            Id = Guid.NewGuid().ToString(),
                            Name = "Member"
                        };
                        await _roleManager.CreateAsync(appRole);
                    }

                    await _userManager.AddToRoleAsync(appUser, "Member");
                }
            }
            
			return new CreateUserCommandResponse()
			{
				TcNo = request.TcNo,
				Email = request.Email,
				Password = request.Password,
				UserName = request.UserName
			};

		}
    }
}

