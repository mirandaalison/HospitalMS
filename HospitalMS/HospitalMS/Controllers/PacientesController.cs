using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;


namespace HospitalMS.Controllers
{
    public class PacientesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<PacientesCLS> ListarPacientes()
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.ListarPacientes();
        }

        public List<PacientesCLS> FiltrarPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.FiltrarPacientes(objPacientes);
        }
        public int GuardarPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.GuardarPacientes(objPacientes);
        }

        public PacientesCLS RecuperarPacientes(int Id)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.RecuperarPacientes(Id);
        }

        public int GuardarCambiosPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.GuardarCambiosPacientes(objPacientes);
        }

        public int EliminarPacientes(int Id)
        {
            PacientesDAL objDAL = new PacientesDAL();
            return objDAL.EliminarPacientes(Id);
        }
    }
}
