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

            // Depuración: inspeccionar las propiedades de cada tratamiento
            foreach (var tratamiento in resultado)
            {
                Console.WriteLine($"Id: {tratamiento.Id}, PacienteId: {tratamiento.PacienteId}, Descripcion: {tratamiento.Descripcion}");
            }

            return resultado;
        }

        public int GuardarTratamientos(TratamientosCLS objTratamiento)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.GuardarTratamientos(objTratamiento);
        }

        public TratamientosCLS RecuperarTratamientos(int id)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.RecuperarTratamientos(id);
        }

        public int GuardarCambiosTratamientos(TratamientosCLS objTratamiento)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.GuardarCambiosTratamientos(objTratamiento);
        }

        public int EliminarTratamientos(int id)
        {
            TratamientosDAL objDAL = new TratamientosDAL();
            return objDAL.EliminarTratamientos(id);
        }
    }
}
