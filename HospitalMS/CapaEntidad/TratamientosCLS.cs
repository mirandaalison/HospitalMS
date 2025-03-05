using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class TratamientosCLS
    {
        public int id { get; set; } 
        public int pacienteId { get; set; } 
        public string descripcion { get; set; } 
        public DateTime fecha { get; set; } 
        public decimal costo { get; set; } 
    }
}
