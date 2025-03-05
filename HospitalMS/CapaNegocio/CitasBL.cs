using System.Collections.Generic;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class CitasBL
    {
        public List<CitasCLS> ListarCitas()
        {
            CitasDAL obj = new CitasDAL();
            return obj.ListarCitas();
        }

        public List<CitasCLS> FiltrarCitas(CitasCLS objCitas)
        {
            CitasDAL obj = new CitasDAL();
            return obj.FiltrarCitas(objCitas);
        }

        public int GuardarCitas(CitasCLS objCitas)
        {
            CitasDAL obj = new CitasDAL();
            return obj.GuardarCitas(objCitas);
        }

        public CitasCLS RecuperarCitas(int id)
        {
            CitasDAL obj = new CitasDAL();
            return obj.RecuperarCitas(id);
        }

        public int GuardarCambiosCitas(CitasCLS objCitas)
        {
            CitasDAL obj = new CitasDAL();
            return obj.GuardarCambiosCitas(objCitas);
        }

        public int EliminarCitas(int id)
        {
            CitasDAL obj = new CitasDAL();
            return obj.EliminarCitas(id);
        }

        public List<PacientesCLS> ListarPacientesCombo()
        {
            CitasDAL obj = new CitasDAL();
            return obj.ListarPacientesCombo();
        }

        public List<MedicosCLS> ListarMedicosCombo()
        {
            CitasDAL obj = new CitasDAL();
            return obj.ListarMedicosCombo();
        }
    }
}