using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
