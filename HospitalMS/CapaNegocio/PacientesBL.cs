using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class PacientesBL
    {
        public List<PacientesCLS> ListarPacientes()
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.ListarPacientes();
        }

        public List<PacientesCLS> FiltrarPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.FiltrarPacientes(objPacientes);
        }

        public int GuardarPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.GuardarPacientes(objPacientes);
        }

        public PacientesCLS RecuperarPacientes(int id)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.RecuperarPacientes(id);
        }

        public int GuardarCambiosPacientes(PacientesCLS objPacientes)
        {
            PacientesDAL obj = new PacientesDAL();
            return obj.GuardarCambiosPacientes(objPacientes);
        }

        public int Eliminar(int id)
        {
            PacientesDAL objDAL = new PacientesDAL();
            return objDAL.Eliminar(id);
        }
    }
}