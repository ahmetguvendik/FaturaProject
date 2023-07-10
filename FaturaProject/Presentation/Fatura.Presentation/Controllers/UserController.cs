using Fatura.Application.CQRS.Commands.User.CreateUser;
using Fatura.Application.CQRS.Commands.User.LoginUser;
using Fatura.Application.Services;
using Fatura.Application.ViewModel;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fatura.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailService _emailService;
        public UserController(IMediator mediator, SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,IEmailService emailService)
        {
            _mediator = mediator;
            _userManager = userManager;
            _emailService = emailService;
            _signinManager = signInManager;
        }
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginUserCommandRequest model)
        {
            LoginUserCommandResponse response = await _mediator.Send(model);
            HttpContext.Session.SetString("Userid", response.Id);
            if (response.Role == "Member")
            {
              
                return RedirectToAction("ShowBill", "Bill");
            }
            else if(response.Role == "Admin")
            {

                return RedirectToAction("GetUser", "Admin");
            } 

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUserCommandRequest model)
        {
            CreateUserCommandResponse response = await _mediator.Send(model);
            return View(response);
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult ResetPasswordForEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPasswordForEmail(ResetPassword request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var link = Url.Action(nameof(ResetPassword), "User", new
                {
                    token,
                    email = user.Email
                },
                Request.Scheme
                );

                await _emailService.SendEmailAsync(request.Email, link);
            }
            return View();
        }

        public IActionResult ResetPassword(string token, string email)
        {
            var model = new ResetPassword { Token = token, Email = email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPassword request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null)
            {
                var resetResult = await _userManager.ResetPasswordAsync(user, request.Token, request.Password);
                if (resetResult.Succeeded)
                {
                    return RedirectToAction("SignIn", "User");
                }

            }
            return View();
        }



        public async Task<IActionResult> SignOut()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }

    }
}

