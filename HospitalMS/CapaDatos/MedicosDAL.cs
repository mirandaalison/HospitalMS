using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;

namespace CapaDatos
{
    public class MedicosDAL : CadenaDAL
    {
        // Listar todos los médicos
        public List<MedicosCLS> ListarMedicos()
        {
            List<MedicosCLS> lista = new List<MedicosCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarMedicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MedicosCLS medico = new MedicosCLS();

                                medico.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                medico.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                medico.apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                medico.especialidadId = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                medico.telefono = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                medico.email = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);

                                lista.Add(medico);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarMedicos: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }


        public List<MedicosCLS> FiltrarMedicos(MedicosCLS obj)
        {
            List<MedicosCLS> lista = new List<MedicosCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarMedicos", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(obj.nombre) ? DBNull.Value : (object)obj.nombre);
                        cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrEmpty(obj.apellido) ? DBNull.Value : (object)obj.apellido);
                        cmd.Parameters.AddWithValue("@EspecialidadId", obj.especialidadId == 0 ? DBNull.Value : (object)obj.especialidadId);
                        cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(obj.telefono) ? DBNull.Value : (object)obj.telefono);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(obj.email) ? DBNull.Value : (object)obj.email);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MedicosCLS medico = new MedicosCLS();

                                medico.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                medico.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                medico.apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                medico.especialidadId = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                medico.telefono = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                medico.email = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);

                                lista.Add(medico);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en FiltrarMedicos: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }


        public int GuardarMedicos(MedicosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Medicos (Nombre, Apellido, EspecialidadId, Identificacion, Telefono, Email) VALUES (@Nombre, @Apellido, @EspecialidadId, @Identificacion, @Telefono, @Email);", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Nombre", obj.nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Apellido", obj.apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@EspecialidadId", obj.especialidadId);
                        cmd.Parameters.AddWithValue("@Telefono", obj.telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Email", obj.email ?? string.Empty);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarMedicos: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public MedicosCLS RecuperarMedicos(int id)
        {
            MedicosCLS medico = new MedicosCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Apellido, EspecialidadId, Identificacion, Telefono, Email FROM Medicos WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                medico.id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id"));
                                medico.nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("Nombre"));
                                medico.apellido = dr.IsDBNull(dr.GetOrdinal("Apellido")) ? string.Empty : dr.GetString(dr.GetOrdinal("Apellido"));
                                medico.especialidadId = dr.IsDBNull(dr.GetOrdinal("EspecialidadId")) ? 0 : dr.GetInt32(dr.GetOrdinal("EspecialidadId"));
                                medico.telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr.GetString(dr.GetOrdinal("Telefono"));
                                medico.email = dr.IsDBNull(dr.GetOrdinal("Email")) ? string.Empty : dr.GetString(dr.GetOrdinal("Email"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en RecuperarMedicos: " + ex.Message);
                    throw;
                }
            }
            return medico;
        }

        public int GuardarCambiosMedicos(MedicosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Medicos SET Nombre = @Nombre, Apellido = @Apellido, EspecialidadId = @EspecialidadId, Identificacion = @Identificacion, Telefono = @Telefono, Email = @Email WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", obj.id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Apellido", obj.apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@EspecialidadId", obj.especialidadId);
                        cmd.Parameters.AddWithValue("@Telefono", obj.telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Email", obj.email ?? string.Empty);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCambiosMedicos: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public int EliminarMedicos(int id)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Medicos WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en EliminarMedicos: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }
    }
}
