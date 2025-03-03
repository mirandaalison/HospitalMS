using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class PacientesDAL : CadenaDAL
    {
        public List<PacientesCLS> ListarPacientes()
        {
            List<PacientesCLS> lista = new List<PacientesCLS>();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarPacientes", cn))
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
                                paciente.fechaNacimiento = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                paciente.telefono = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                paciente.email = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                paciente.direccion = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);

                                lista.Add(paciente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarPacientes: " + ex.Message);
                    throw; 
                }
            }
            return lista;
        }

        public List<PacientesCLS> FiltrarPacientes(PacientesCLS obj)
        {
            List<PacientesCLS> lista = new List<PacientesCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarPacientes", cn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", string.IsNullOrEmpty(obj.nombre) ? DBNull.Value : (object)obj.nombre);
                        cmd.Parameters.AddWithValue("@Apellido", string.IsNullOrEmpty(obj.apellido) ? DBNull.Value : (object)obj.apellido);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.fechaNacimiento == DateTime.MinValue ? DBNull.Value : (object)obj.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@Telefono", string.IsNullOrEmpty(obj.telefono) ? DBNull.Value : (object)obj.telefono);
                        cmd.Parameters.AddWithValue("@Email", string.IsNullOrEmpty(obj.email) ? DBNull.Value : (object)obj.email);
                        cmd.Parameters.AddWithValue("@Direccion", string.IsNullOrEmpty(obj.direccion) ? DBNull.Value : (object)obj.direccion);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PacientesCLS paciente = new PacientesCLS();

                                paciente.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                paciente.nombre = dr.IsDBNull(1) ? string.Empty : dr.GetString(1);
                                paciente.apellido = dr.IsDBNull(2) ? string.Empty : dr.GetString(2);
                                paciente.fechaNacimiento = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                paciente.telefono = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                paciente.email = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                paciente.direccion = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);

                                lista.Add(paciente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en FiltrarPacientes: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public int GuardarPacientes(PacientesCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Pacientes(Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion) VALUES (@Nombre, @Apellido, @FechaNacimiento, @Telefono, @Email, @Direccion);", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Nombre", obj.nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Apellido", obj.apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@Telefono", obj.telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Email", obj.email ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Direccion", obj.direccion ?? string.Empty);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarPacientes: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public PacientesCLS RecuperarPacientes(int id)
        {
            PacientesCLS oPacientesCLS = new PacientesCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id as id, Nombre as nombre, Apellido as apellido, FechaNacimiento as fechaNacimiento, Telefono as telefono, Email as email, Direccion as direccion FROM Pacientes WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oPacientesCLS.id = dr.IsDBNull(dr.GetOrdinal("id")) ? 0 : dr.GetInt32(dr.GetOrdinal("id"));
                                oPacientesCLS.nombre = dr.IsDBNull(dr.GetOrdinal("nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("nombre"));
                                oPacientesCLS.apellido = dr.IsDBNull(dr.GetOrdinal("apellido")) ? string.Empty : dr.GetString(dr.GetOrdinal("apellido"));
                                oPacientesCLS.fechaNacimiento = dr.IsDBNull(dr.GetOrdinal("fechaNacimiento")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("fechaNacimiento"));
                                oPacientesCLS.telefono = dr.IsDBNull(dr.GetOrdinal("telefono")) ? string.Empty : dr.GetString(dr.GetOrdinal("telefono"));
                                oPacientesCLS.email = dr.IsDBNull(dr.GetOrdinal("email")) ? string.Empty : dr.GetString(dr.GetOrdinal("email"));
                                oPacientesCLS.direccion = dr.IsDBNull(dr.GetOrdinal("direccion")) ? string.Empty : dr.GetString(dr.GetOrdinal("direccion"));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en RecuperarPacientes: " + ex.Message);
                    throw;
                }
            }

            return oPacientesCLS;
        }

        public int GuardarCambiosPacientes(PacientesCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Pacientes SET Nombre = @Nombre, Apellido = @Apellido, FechaNacimiento = @FechaNacimiento, Telefono = @Telefono, Email = @Email, Direccion = @Direccion WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", obj.id);
                        cmd.Parameters.AddWithValue("@Nombre", obj.nombre ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Apellido", obj.apellido ?? string.Empty);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.fechaNacimiento);
                        cmd.Parameters.AddWithValue("@Telefono", obj.telefono ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Email", obj.email ?? string.Empty);
                        cmd.Parameters.AddWithValue("@Direccion", obj.direccion ?? string.Empty);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCambiosPacientes: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public int EliminarPacientes(int id)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Pacientes WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en EliminarPacientes: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }
    }
}