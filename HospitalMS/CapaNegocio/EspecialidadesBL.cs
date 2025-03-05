using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class EspecialidadesBL
    {
        public List<EspecialidadesCLS> ListarEspecialidades()
        {
            EspecialidadesDAL obj = new EspecialidadesDAL();
            return obj.ListarEspecialidades();
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
