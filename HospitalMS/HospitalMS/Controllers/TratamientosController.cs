using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class TratamientosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TratamientosCLS> ListarTratamientos()
        {
            TratamientosDAL obj = new TratamientosDAL();
            var resultado = obj.ListarTratamientos();

            // Depuración: inspeccionar las propiedades
            foreach (var tratamiento in resultado)
            {
                Console.WriteLine($"id: {tratamiento.id}, pacienteId: {tratamiento.pacienteId}, descripcion: {tratamiento.descripcion}");
            }

            return resultado;
        }

        // Se asume la existencia de un método similar para filtrar tratamientos,
        // siguiendo el patrón de la clase de Pacientes.
        public List<TratamientosCLS> FiltrarTratamientos(TratamientosCLS objTratamientos)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.FiltrarTratamientos(objTratamientos);
        }

        public int GuardarTratamientos(TratamientosCLS objTratamientos)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.GuardarTratamientos(objTratamientos);
        }

        public TratamientosCLS RecuperarTratamientos(int id)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.RecuperarTratamientos(id);
        }

        public int GuardarCambiosTratamientos(TratamientosCLS objTratamientos)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.GuardarCambiosTratamientos(objTratamientos);
        }

        public int Eliminar(int id)
        {
            TratamientosDAL objDAL = new TratamientosDAL();
            return objDAL.Eliminar(id);
        }
    }
}
