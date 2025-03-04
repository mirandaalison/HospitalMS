using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class TratamientosDAL : CadenaDAL
    {
        public List<TratamientosCLS> ListarTratamientos()
        {
            List<TratamientosCLS> lista = new List<TratamientosCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarTratamientos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                TratamientosCLS tratamiento = new TratamientosCLS();

                                tratamiento.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                tratamiento.PacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                tratamiento.Descripcion = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                tratamiento.Fecha = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                tratamiento.Costo = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);

                                lista.Add(tratamiento);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarTratamientos: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public int GuardarTratamientos(TratamientosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Tratamientos (PacienteId, Descripcion, Fecha, Costo) VALUES (@PacienteId, @Descripcion, @Fecha, @Costo)", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@PacienteId", obj.PacienteId);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                        cmd.Parameters.AddWithValue("@Costo", obj.Costo);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarTratamientos: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public TratamientosCLS RecuperarTratamientos(int id)
        {
            TratamientosCLS tratamiento = new TratamientosCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id, PacienteId, Descripcion, Fecha, Costo FROM Tratamientos WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tratamiento.Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id"));
                                tratamiento.PacienteId = dr.IsDBNull(dr.GetOrdinal("PacienteId")) ? 0 : dr.GetInt32(dr.GetOrdinal("PacienteId"));
                                tratamiento.Descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion"));
                                tratamiento.Fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("Fecha"));
                                tratamiento.Costo = dr.IsDBNull(dr.GetOrdinal("Costo")) ? 0 : dr.GetDecimal(dr.GetOrdinal("Costo"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en RecuperarTratamientos: " + ex.Message);
                    throw;
                }
            }

            return tratamiento;
        }

        public int GuardarCambiosTratamientos(TratamientosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Tratamientos SET PacienteId = @PacienteId, Descripcion = @Descripcion, Fecha = @Fecha, Costo = @Costo WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@PacienteId", obj.PacienteId);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);
                        cmd.Parameters.AddWithValue("@Costo", obj.Costo);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCambiosTratamientos: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public int EliminarTratamientos(int id)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Tratamientos WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en EliminarTratamientos: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }
    }
}
