using Fatura.Application.CQRS.Commands.Bill.PayBill;
using Fatura.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fatura.Presentation.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillReadRepository _readRepository;
        private readonly IMediator _mediator;
        public BillController(IBillReadRepository readRepository,IMediator mediator)
        {
            _readRepository = readRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult ShowBill()
        {
            var id = HttpContext.Session.GetString("Userid");
            var bill = _readRepository.GetById(id);
           
            if(bill == null)
            {
                return RedirectToAction("SignIn", "User");
            }
            return View(bill);
        }

        public IActionResult Pay()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Pay(PayBillCommandRequest model)
        {
            var response = await _mediator.Send(model);
            if(response.IsPay == true)
            {

                return RedirectToAction("ShowBill", "Bill");
                
            }

            return View(response);
        }
    }
}

