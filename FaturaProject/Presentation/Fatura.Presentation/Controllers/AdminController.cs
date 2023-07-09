using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fatura.Application.CQRS.Commands.Bill.CreateBill;
using Fatura.Application.Repositories;
using Fatura.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fatura.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IBillReadRepository _readRepository;
        private readonly IMediator _mediator;
        public AdminController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IBillReadRepository readRepository, IMediator mediator)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _readRepository = readRepository;
            _mediator = mediator;
        }

        public IActionResult GetUser()
        {
            var users =  _userManager.Users.ToList();
            
            return View(users);
        }

        public IActionResult GetRole()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }

        public  IActionResult GetUserRole()
        {
            var userRole =  _readRepository.GetUserRole();
            return View(userRole);
        }

        public IActionResult CreateBill()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(CreateBillCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return View(response);

        }

    }
}

