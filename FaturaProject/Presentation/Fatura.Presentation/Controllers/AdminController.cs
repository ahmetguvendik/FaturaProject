using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fatura.Application.CQRS.Commands.Bill.CreateBill;
using Fatura.Application.CQRS.Queries.Bill.GetUserRole;
using Fatura.Application.CQRS.Queries.User.GetAllRole;
using Fatura.Application.CQRS.Queries.User.GetAllUser;
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
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> GetUser(GetAllUserQueryRequest model)
        {
            var users = await _mediator.Send(model);
            return View(users);
        }

        public async Task<IActionResult> GetRole(GetAllRoleQueryRequest model)
        {
            var roles = await _mediator.Send(model);
            return View(roles);
        }

        public  async Task<IActionResult> GetUserRole(GetUserRoleQueryRequest model)
        {
            var userRole = await _mediator.Send(model);
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

