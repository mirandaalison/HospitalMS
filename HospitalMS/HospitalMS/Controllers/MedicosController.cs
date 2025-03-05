using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class MedicosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<MedicosCLS> ListarMedicos()
        {
            MedicosDAL obj = new MedicosDAL();
            var resultado = obj.ListarMedicos();

            foreach (var medico in resultado)
            {
                Console.WriteLine($"Id: {medico.id}, Nombre: {medico.nombre}");
            }

            return resultado;
        }

        public List<MedicosCLS> FiltrarMedicos(MedicosCLS objMedicos)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.FiltrarMedicos(objMedicos);
        }

        public int GuardarMedicos(MedicosCLS objMedicos)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.GuardarMedicos(objMedicos);
        }

        public MedicosCLS RecuperarMedicos(int id)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.RecuperarMedicos(id);
        }

        public int GuardarCambiosMedicos(MedicosCLS objMedicos)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.GuardarCambiosMedicos(objMedicos);
        }

        public int EliminarMedicos(int id)
        {
            MedicosDAL objDAL = new MedicosDAL();
            return objDAL.EliminarMedicos(id);
        }
    }
}
