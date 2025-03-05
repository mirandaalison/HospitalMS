using System;
namespace CapaEntidad
{
    public class FacturacionCLS
    {
        public int id { get; set; }
        public int pacienteId { get; set; }
        public decimal monto { get; set; }
        public string metodoPago { get; set; }
        public DateTime fechaPago { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
    }
}