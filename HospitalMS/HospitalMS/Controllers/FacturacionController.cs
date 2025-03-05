using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class FacturacionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public List<FacturacionCLS> ListarFacturas()
        {
            FacturacionDAL obj = new FacturacionDAL();
            var resultado = obj.ListarFacturas();

            foreach (var factura in resultado)
            {
                Console.WriteLine($"id: {factura.id}, pacienteId: {factura.pacienteId}, monto: {factura.monto}");
            }
            return resultado;
        }
        public List<FacturacionCLS> FiltrarFacturas(FacturacionCLS objFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.FiltrarFacturas(objFacturacion);
        }
        public int GuardarFactura(FacturacionCLS objFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.GuardarFactura(objFacturacion);
        }
        public List<PacientesCLS> ListarPacientesDropdown()
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ListarPacientesDropdown();
        }
        public List<FacturacionCLS> ObtenerTotalTratamientosPorPaciente()
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ObtenerTotalTratamientosPorPaciente();
        }
        public FacturacionCLS RecuperarFactura(int id)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.RecuperarFactura(id);
        }
        public int GuardarCambiosFactura(FacturacionCLS objFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.GuardarCambiosFactura(objFacturacion);
        }
    }
}

