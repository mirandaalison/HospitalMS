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
            var resultado = obj.ListarPacientes();

            foreach (var paciente in resultado)
            {
                Console.WriteLine($"id: {paciente.id}, nombre: {paciente.nombre}");
            }

            return resultado;
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

        public PacientesCLS RecuperarPacientes(int id)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.RecuperarPacientes(id);
        }

        public int GuardarCambiosPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.GuardarCambiosPacientes(objPacientes);
        }

        public int Eliminar(int id)
        {
            PacientesDAL objDAL = new PacientesDAL();
            return objDAL.Eliminar(id);
        }
    }
}