using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class MedicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
