using System;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Fatura.Application.CQRS.Commands.User.LoginUser
{
	public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest,LoginUserCommandResponse>
	{
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        public LoginUserCommandHandler(UserManager<AppUser> userManager,RoleManager<AppRole> roleManager,SignInManager<AppUser> signInManager)
		{
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
		}

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.FindByNameAsync(request.UserName);
            var response = await _signInManager.PasswordSignInAsync(request.UserName,request.Password,false,false);
            if (response.Succeeded)
            {
                var role = await _userManager.GetRolesAsync(appUser);
                if (role.Contains("Member"))
                {
                    return new LoginUserCommandResponse()
                    {
                        Id = appUser.Id,
                        UserName = request.UserName,
                        Password = request.Password,
                        Role = "Member"
                    };
                }

                else if (role.Contains("Admin"))
                {
                    return new LoginUserCommandResponse()
                    {
                        Id = appUser.Id,
                        UserName = request.UserName,
                        Password = request.Password,
                        Role = "Admin"
                    };
                }
            }

            return new LoginUserCommandResponse()
            {
                Id = appUser.Id,
                UserName = request.UserName,
                Password = request.Password,
                Role = ""
            };
        }
    }
}

