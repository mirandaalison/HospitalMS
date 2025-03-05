using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace HospitalMS.Controllers
{
    public class EspecialidadesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<EspecialidadesCLS> ListarEspecialidades()
        {
            EspecialidadesDAL obj = new EspecialidadesDAL();
            var resultado = obj.ListarEspecialidades();

            foreach (var especialidad in resultado)
            {
                Console.WriteLine($"id: {especialidad.id}, nombre: {especialidad.nombre}");
            }

            return resultado;
        }

        public List<EspecialidadesCLS> FiltrarEspecialidades(EspecialidadesCLS objEspecialidad)
        {
            EspecialidadesDAL obj = new EspecialidadesDAL();
            return obj.FiltrarEspecialidades(objEspecialidad);
        }

        public int GuardarEspecialidades(EspecialidadesCLS objEspecialidad)
        {
            EspecialidadesDAL obj = new EspecialidadesDAL();
            return obj.GuardarEspecialidades(objEspecialidad);
        }

        public EspecialidadesCLS RecuperarEspecialidades(int id)
        {
            EspecialidadesDAL obj = new EspecialidadesDAL();
            return obj.RecuperarEspecialidades(id);
        }

        public int GuardarCambiosEspecialidades(EspecialidadesCLS objEspecialidad)
        {
            EspecialidadesDAL obj = new EspecialidadesDAL();
            return obj.GuardarCambiosEspecialidades(objEspecialidad);
        }

        public int Eliminar(int id)
        {
            EspecialidadesDAL objDAL = new EspecialidadesDAL();
            return objDAL.EliminarEspecialidades(id);
        }
    }
}
