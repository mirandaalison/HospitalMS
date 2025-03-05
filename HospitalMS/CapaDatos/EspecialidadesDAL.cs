using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class EspecialidadesDAL : CadenaDAL
    {
        public List<EspecialidadesCLS> ListarEspecialidades()
        {
            List<EspecialidadesCLS> lista = new List<EspecialidadesCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarEspecialidades", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EspecialidadesCLS especialidad = new EspecialidadesCLS();
                                especialidad.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                especialidad.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);

                                lista.Add(especialidad);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarEspecialidades: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public List<EspecialidadesCLS> FiltrarEspecialidades(EspecialidadesCLS obj)
        {
            List<EspecialidadesCLS> lista = new List<EspecialidadesCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarEspecialidades", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(obj.nombre) ? DBNull.Value : (object)obj.nombre);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                EspecialidadesCLS especialidad = new EspecialidadesCLS();
                                especialidad.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                especialidad.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);

                                lista.Add(especialidad);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en FiltrarEspecialidades: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public int GuardarEspecialidades(EspecialidadesCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Especialidades(Nombre) VALUES (@Nombre);", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Nombre", obj.nombre ?? string.Empty);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarEspecialidades: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public EspecialidadesCLS RecuperarEspecialidades(int id)
        {
            EspecialidadesCLS objEspecialidad = new EspecialidadesCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id as id, Nombre as nombre FROM Especialidades WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                objEspecialidad.id = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : dr.GetInt32(dr.GetOrdinal("id"));
                                objEspecialidad.nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("nombre"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en RecuperarEspecialidades: " + ex.Message);
                    throw;
                }
            }

            return objEspecialidad;
        }

        public int GuardarCambiosEspecialidades(EspecialidadesCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Especialidades SET Nombre = @Nombre WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", obj.id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.nombre ?? string.Empty);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCambiosEspecialidades: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public int EliminarEspecialidades(int id)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Especialidades WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en EliminarEspecialidades: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }
    }
}
