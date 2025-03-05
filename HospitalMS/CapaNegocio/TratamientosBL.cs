using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class TratamientosBL
    {
        public List<TratamientosCLS> ListarTratamientos()
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.ListarTratamientos();
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

        public int Eliminar(int id)
        {
            TratamientosDAL obj = new TratamientosDAL();
            return obj.Eliminar(id);
        }
    }
}
