using Fatura.Application.CQRS.Commands.User.CreateUser;
using Fatura.Application.CQRS.Commands.User.LoginUser;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fatura.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly SignInManager<AppUser> _userManager;
        public UserController(IMediator mediator, SignInManager<AppUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
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
               
                return View(response);
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

       public async Task<IActionResult> SignOut()
        {
            await _userManager.SignOutAsync();
            return RedirectToAction("SignIn", "User");
        }

    }
}

