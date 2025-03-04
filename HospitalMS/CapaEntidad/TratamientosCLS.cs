using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TratamientosCLS
    {
        public int id { get; set; } // Id_Tratamiento
        public int pacienteId { get; set; } // Id_Paciente
        public string descripcion { get; set; } // Descripcion
        public DateTime fecha { get; set; } // Fecha
        public decimal costo { get; set; } // Costo

        // Relación con Paciente
        /*public PacientesCLS Paciente
        {
            get; set;
        }*/
    }
}
