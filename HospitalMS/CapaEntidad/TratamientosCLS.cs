using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TratamientosCLS
    {
        public int Id { get; set; } // Id_Tratamiento
        public int PacienteId { get; set; } // Id_Paciente
        public string Descripcion { get; set; } // Descripcion DEL TRATAMIENTO
        public DateTime Fecha { get; set; } // Fecha
        public decimal Costo { get; set; } // Costo

    }
}
