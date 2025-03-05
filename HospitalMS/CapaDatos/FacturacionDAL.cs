using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class FacturacionDAL : CadenaDAL
    {
        public List<FacturacionCLS> ListarFacturas()
        {
            List<FacturacionCLS> lista = new List<FacturacionCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.uspListarFacturacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                FacturacionCLS factura = new FacturacionCLS();

                                factura.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                factura.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                factura.monto = dr.IsDBNull(2) ? 0 : dr.GetDecimal(2);
                                factura.metodoPago = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
                                factura.fechaPago = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4);

                                if (dr.FieldCount > 5)
                                {
                                    factura.nombrePaciente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                    factura.apellidoPaciente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                                }

                                lista.Add(factura);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarFacturas: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public List<FacturacionCLS> FiltrarFacturas(FacturacionCLS obj)
        {
            List<FacturacionCLS> lista = new List<FacturacionCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.uspFiltrarFacturacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId == 0 ? DBNull.Value : (object)obj.pacienteId);
                        cmd.Parameters.AddWithValue("@MetodoPago", string.IsNullOrEmpty(obj.metodoPago) ? DBNull.Value : (object)obj.metodoPago);
                        cmd.Parameters.AddWithValue("@FechaPago", obj.fechaPago == DateTime.MinValue ? DBNull.Value : (object)obj.fechaPago);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                FacturacionCLS factura = new FacturacionCLS();

                                factura.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                factura.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                factura.monto = dr.IsDBNull(2) ? 0 : dr.GetDecimal(2);
                                factura.metodoPago = dr.IsDBNull(3) ? string.Empty : dr.GetString(3);
                                factura.fechaPago = dr.IsDBNull(4) ? DateTime.MinValue : dr.GetDateTime(4);

                                if (dr.FieldCount > 5)
                                {
                                    factura.nombrePaciente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                    factura.apellidoPaciente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                                }

                                lista.Add(factura);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en FiltrarFacturas: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public int GuardarFactura(FacturacionCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.uspAgregarFacturacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        cmd.Parameters.AddWithValue("@Monto", obj.monto);
                        cmd.Parameters.AddWithValue("@MetodoPago", obj.metodoPago ?? string.Empty);
                        cmd.Parameters.AddWithValue("@FechaPago", obj.fechaPago);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarFactura: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public List<PacientesCLS> ListarPacientesDropdown()
        {
            List<PacientesCLS> lista = new List<PacientesCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.uspListarPacientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PacientesCLS paciente = new PacientesCLS();

                                paciente.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                paciente.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                paciente.apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);

                                lista.Add(paciente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarPacientesDropdown: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public List<FacturacionCLS> ObtenerTotalTratamientosPorPaciente()
        {
            List<FacturacionCLS> lista = new List<FacturacionCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();

                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT p.Id, p.Nombre, p.Apellido, ISNULL(SUM(t.Costo), 0) as TotalCosto " +
                        "FROM Pacientes p " +
                        "LEFT JOIN Tratamientos t ON p.Id = t.PacienteId " +
                        "GROUP BY p.Id, p.Nombre, p.Apellido " +
                        "ORDER BY p.Apellido, p.Nombre", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                FacturacionCLS factura = new FacturacionCLS();

                                factura.pacienteId = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                factura.nombrePaciente = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                factura.apellidoPaciente = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                factura.monto = dr.IsDBNull(3) ? 0 : dr.GetDecimal(3);

                                lista.Add(factura);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ObtenerTotalTratamientosPorPaciente: " + ex.Message);
                    throw;
                }
            }

            return lista;
        }

        public FacturacionCLS RecuperarFactura(int id)
        {
            FacturacionCLS oFacturacionCLS = new FacturacionCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.uspRecuperarFacturacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oFacturacionCLS.id = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : dr.GetInt32(dr.GetOrdinal("id"));
                                oFacturacionCLS.pacienteId = dr.IsDBNull(dr.GetOrdinal("pacienteId")) ? 0 : dr.GetInt32(dr.GetOrdinal("pacienteId"));
                                oFacturacionCLS.monto = dr.IsDBNull(dr.GetOrdinal("monto")) ? 0 : dr.GetDecimal(dr.GetOrdinal("monto"));
                                oFacturacionCLS.metodoPago = dr.IsDBNull(dr.GetOrdinal("metodoPago")) ? string.Empty : dr.GetString(dr.GetOrdinal("metodoPago"));
                                oFacturacionCLS.fechaPago = dr.IsDBNull(dr.GetOrdinal("fechaPago")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("fechaPago"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en RecuperarFactura: " + ex.Message);
                    throw;
                }
            }

            return oFacturacionCLS;
        }

        public int GuardarCambiosFactura(FacturacionCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.uspAgregarFacturacion", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", obj.id);
                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        cmd.Parameters.AddWithValue("@Monto", obj.monto);
                        cmd.Parameters.AddWithValue("@MetodoPago", obj.metodoPago ?? string.Empty);
                        cmd.Parameters.AddWithValue("@FechaPago", obj.fechaPago);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCambiosFactura: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }
    }
}