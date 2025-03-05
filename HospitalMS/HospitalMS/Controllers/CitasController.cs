using CapaEntidad;
using CapaNegocio;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HospitalMS.Controllers
{
    public class CitasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<CitasCLS> ListarCitas()
        {
            CitasBL obj = new CitasBL();
            return obj.ListarCitas();
        }

        public List<CitasCLS> FiltrarCitas(CitasCLS objCitas)
        {
            CitasBL obj = new CitasBL();
            return obj.FiltrarCitas(objCitas);
        }

        public int GuardarCitas(CitasCLS objCitas)
        {
            CitasBL obj = new CitasBL();
            return obj.GuardarCitas(objCitas);
        }

        public CitasCLS RecuperarCitas(int id)
        {
            CitasBL obj = new CitasBL();
            return obj.RecuperarCitas(id);
        }

        public int GuardarCambiosCitas(CitasCLS objCitas)
        {
            CitasBL obj = new CitasBL();
            return obj.GuardarCambiosCitas(objCitas);
        }

        public int EliminarCitas(int id)
        {
            CitasBL obj = new CitasBL();
            return obj.EliminarCitas(id);
        }

        public List<PacientesCLS> ListarPacientesCombo()
        {
            CitasBL obj = new CitasBL();
            return obj.ListarPacientesCombo();
        }

        public List<MedicosCLS> ListarMedicosCombo()
        {
            CitasBL obj = new CitasBL();
            return obj.ListarMedicosCombo();
        }
    }
}