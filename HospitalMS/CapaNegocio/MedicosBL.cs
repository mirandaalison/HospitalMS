using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    public class MedicosBL
    {
        public List<MedicosCLS> ListarMedicos()
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.ListarMedicos();
        }
        public List<MedicosCLS> FiltrarMedicos(MedicosCLS objMedicos)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.FiltrarMedicos(objMedicos);
        }
        public int GuardarMedicos(MedicosCLS objMedicos)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.GuardarMedicos(objMedicos);
        }
        public MedicosCLS RecuperarMedicos(int id)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.RecuperarMedicos(id);
        }
        public int GuardarCambiosMedicos(MedicosCLS objMedicos)
        {
            MedicosDAL obj = new MedicosDAL();
            return obj.GuardarCambiosMedicos(objMedicos);
        }
        public int EliminarMedicos(int id)
        {
            MedicosDAL objDAL = new MedicosDAL();
            return objDAL.EliminarMedicos(id);
        }
    }
}