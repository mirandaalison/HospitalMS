using CapaDatos;
using CapaEntidad;
using CapaNegocio;
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
            FacturacionBL obj = new FacturacionBL();
            var resultado = obj.ListarFacturas();
            foreach (var factura in resultado)
            {
                Console.WriteLine($"id: {factura.id}, pacienteId: {factura.pacienteId}, monto: {factura.monto}");
            }
            return resultado;
        }
        public List<FacturacionCLS> FiltrarFacturas(FacturacionCLS objFacturacion)
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.FiltrarFacturas(objFacturacion);
        }
        public int GuardarFactura(FacturacionCLS objFacturacion)
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.GuardarFactura(objFacturacion);
        }
        public List<PacientesCLS> ListarPacientesDropdown()
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.ListarPacientesDropdown();
        }
        public List<FacturacionCLS> ObtenerTotalTratamientosPorPaciente()
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.ObtenerTotalTratamientosPorPaciente();
        }
        public FacturacionCLS RecuperarFactura(int id)
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.RecuperarFactura(id);
        }
        public int GuardarCambiosFactura(FacturacionCLS objFacturacion)
        {
            FacturacionBL obj = new FacturacionBL();
            return obj.GuardarCambiosFactura(objFacturacion);
        }
    }
}