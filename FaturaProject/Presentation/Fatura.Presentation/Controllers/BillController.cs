using Fatura.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Fatura.Presentation.Controllers
{
    public class BillController : Controller
    {
        private readonly IBillReadRepository _readRepository;
        public BillController(IBillReadRepository readRepository)
        {
            _readRepository = readRepository;
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
    }
}

