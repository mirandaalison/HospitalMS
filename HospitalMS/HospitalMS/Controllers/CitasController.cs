using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
