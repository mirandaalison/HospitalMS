using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class TratamientosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
