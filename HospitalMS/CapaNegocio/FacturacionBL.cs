﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
namespace CapaNegocio
{
    public class FacturacionBL
    {
        public List<FacturacionCLS> ListarFacturas()
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ListarFacturas();
        }
        public List<FacturacionCLS> FiltrarFacturas(FacturacionCLS objFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.FiltrarFacturas(objFacturacion);
        }
        public int GuardarFactura(FacturacionCLS objFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.GuardarFactura(objFacturacion);
        }
        public List<PacientesCLS> ListarPacientesDropdown()
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ListarPacientesDropdown();
        }
        public List<FacturacionCLS> ObtenerTotalTratamientosPorPaciente()
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.ObtenerTotalTratamientosPorPaciente();
        }
        public FacturacionCLS RecuperarFactura(int id)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.RecuperarFactura(id);
        }
        public int GuardarCambiosFactura(FacturacionCLS objFacturacion)
        {
            FacturacionDAL obj = new FacturacionDAL();
            return obj.GuardarCambiosFactura(objFacturacion);
        }
    }
}