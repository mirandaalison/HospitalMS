using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaEntidad
{
    public class MedicosCLS
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int especialidadId { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }

    }
}