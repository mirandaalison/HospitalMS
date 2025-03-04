using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class TratamientosDAL : CadenaDAL
    {
        // Listar todos los tratamientos
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
                                tratamiento.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                tratamiento.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                tratamiento.descripcion = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                tratamiento.fecha = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                tratamiento.costo = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
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

        // Guardar un nuevo tratamiento
        public int GuardarTratamientos(TratamientosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    // Se asume que se utiliza un procedimiento almacenado para guardar
                    using (SqlCommand cmd = new SqlCommand("uspGuardarTratamiento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.descripcion ?? string.Empty);
                        // En caso de que la fecha no sea válida, se envía DBNull.Value
                        cmd.Parameters.AddWithValue("@Fecha", obj.fecha == DateTime.MinValue ? DBNull.Value : (object)obj.fecha);
                        cmd.Parameters.AddWithValue("@Costo", obj.costo);

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

        // Filtrar tratamientos según criterios
        public List<TratamientosCLS> FiltrarTratamientos(TratamientosCLS obj)
        {
            List<TratamientosCLS> lista = new List<TratamientosCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTratamientos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Se envía DBNull.Value para los parámetros sin información relevante
                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId == 0 ? DBNull.Value : (object)obj.pacienteId);
                        cmd.Parameters.AddWithValue("@Descripcion", string.IsNullOrEmpty(obj.descripcion) ? DBNull.Value : (object)obj.descripcion);
                        cmd.Parameters.AddWithValue("@Fecha", obj.fecha == DateTime.MinValue ? DBNull.Value : (object)obj.fecha);
                        // Se asume que un costo igual a 0 se interpreta como "no especificado"
                        cmd.Parameters.AddWithValue("@Costo", obj.costo == 0 ? DBNull.Value : (object)obj.costo);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                TratamientosCLS tratamiento = new TratamientosCLS();
                                tratamiento.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                tratamiento.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                tratamiento.descripcion = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                tratamiento.fecha = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                tratamiento.costo = dr.IsDBNull(4) ? 0 : dr.GetDecimal(4);
                                lista.Add(tratamiento);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en FiltrarTratamientos: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        // Recuperar un tratamiento por su ID
        public TratamientosCLS RecuperarTratamientos(int id)
        {
            TratamientosCLS tratamiento = new TratamientosCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspRecuperarTratamiento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                tratamiento.id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id"));
                                tratamiento.pacienteId = dr.IsDBNull(dr.GetOrdinal("PacienteId")) ? 0 : dr.GetInt32(dr.GetOrdinal("PacienteId"));
                                tratamiento.descripcion = dr.IsDBNull(dr.GetOrdinal("Descripcion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Descripcion"));
                                tratamiento.fecha = dr.IsDBNull(dr.GetOrdinal("Fecha")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("Fecha"));
                                tratamiento.costo = dr.IsDBNull(dr.GetOrdinal("Costo")) ? 0 : dr.GetDecimal(dr.GetOrdinal("Costo"));
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

        // Guardar cambios en un tratamiento existente
        public int GuardarCambiosTratamientos(TratamientosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspActualizarTratamiento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", obj.id);
                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.descripcion ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Fecha", obj.fecha == DateTime.MinValue ? DBNull.Value : (object)obj.fecha);
                        cmd.Parameters.AddWithValue("@Costo", obj.costo);

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

        // Eliminar un tratamiento por su ID
        public int EliminarTratamientos(int id)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspEliminarTratamiento", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
