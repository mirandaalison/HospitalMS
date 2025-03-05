using System;

namespace CapaEntidad
{
    public class CitasCLS
    {
        public int id { get; set; }
        public int pacienteId { get; set; }
        public int medicoId { get; set; }
        public DateTime fechaHora { get; set; }
        public string estado { get; set; }
        public string nombrePaciente { get; set; }
        public string apellidoPaciente { get; set; }
        public string nombreMedico { get; set; }
        public string apellidoMedico { get; set; }
        public string especialidad { get; set; }
    }
}