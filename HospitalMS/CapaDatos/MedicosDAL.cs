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

                                medico.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                medico.Nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                medico.Apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                medico.EspecialidadId = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                medico.Identificacion = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                medico.Telefono = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                medico.Email = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);

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

        // Filtrar médicos según criterios de búsqueda
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

                        cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(obj.Nombre) ? DBNull.Value : (object)obj.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrEmpty(obj.Apellido) ? DBNull.Value : (object)obj.Apellido);
                        cmd.Parameters.AddWithValue("@EspecialidadId", obj.EspecialidadId == 0 ? DBNull.Value : (object)obj.EspecialidadId);
                        cmd.Parameters.AddWithValue("@Identificacion", string.IsNullOrEmpty(obj.Identificacion) ? DBNull.Value : (object)obj.Identificacion);
                        cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(obj.Telefono) ? DBNull.Value : (object)obj.Telefono);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(obj.Email) ? DBNull.Value : (object)obj.Email);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MedicosCLS medico = new MedicosCLS();

                                medico.Id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                medico.Nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                medico.Apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                medico.EspecialidadId = dr.IsDBNull(3) ? 0 : dr.GetInt32(3);
                                medico.Identificacion = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                medico.Telefono = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                medico.Email = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);

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

        // Guardar un nuevo médico
        public int GuardarMedicos(MedicosCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    // Se usa comando tipo Text; alternativamente, se puede llamar a un procedimiento almacenado
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Medicos (Nombre, Apellido, EspecialidadId, Identificacion, Telefono, Email) VALUES (@Nombre, @Apellido, @EspecialidadId, @Identificacion, @Telefono, @Email);", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Apellido", obj.Apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@EspecialidadId", obj.EspecialidadId);
                        cmd.Parameters.AddWithValue("@Identificacion", obj.Identificacion ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Telefono", obj.Telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Email", obj.Email ?? string.Empty);

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

        // Recuperar un médico por su ID
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
                                medico.Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id"));
                                medico.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("Nombre"));
                                medico.Apellido = dr.IsDBNull(dr.GetOrdinal("Apellido")) ? string.Empty : dr.GetString(dr.GetOrdinal("Apellido"));
                                medico.EspecialidadId = dr.IsDBNull(dr.GetOrdinal("EspecialidadId")) ? 0 : dr.GetInt32(dr.GetOrdinal("EspecialidadId"));
                                medico.Identificacion = dr.IsDBNull(dr.GetOrdinal("Identificacion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Identificacion"));
                                medico.Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr.GetString(dr.GetOrdinal("Telefono"));
                                medico.Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? string.Empty : dr.GetString(dr.GetOrdinal("Email"));
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

        // Guardar cambios de un médico existente
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

                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Apellido", obj.Apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@EspecialidadId", obj.EspecialidadId);
                        cmd.Parameters.AddWithValue("@Identificacion", obj.Identificacion ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Telefono", obj.Telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Email", obj.Email ?? string.Empty);

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

        // Eliminar un médico por su ID
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
