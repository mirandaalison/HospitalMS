using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                                PacientesCLS Pacientes = new PacientesCLS
                                {
                                    Id = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    FechaNacimiento = dr.GetDateTime(3),
                                    Telefono = dr.GetString(4),
                                    Email = dr.GetString(5),
                                    Direccion = dr.GetString(6)
                                };

                                lista.Add(Pacientes);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
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

                        cmd.Parameters.AddWithValue("@Nombre", (object)obj.Nombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Apellido", (object)obj.Apellido ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", (object)obj.FechaNacimiento ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Telefono", (object)obj.Telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", (object)obj.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Direccion", (object)obj.Direccion ?? DBNull.Value);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PacientesCLS Pacientes = new PacientesCLS
                                {
                                    Id = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    FechaNacimiento = dr.GetDateTime(3),
                                    Telefono = dr.GetString(4),
                                    Email = dr.GetString(5),
                                    Direccion = dr.GetString(6)
                                };
                                lista.Add(Pacientes);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lista = null;
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
                    using (SqlCommand cmd = new SqlCommand("insert into Pacientes(Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion) values (@Nombre, @Apellido, @FechaNacimiento, @Telefono, @Email, @Direccion);", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido",obj.Apellido);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                        cmd.Parameters.AddWithValue("@Email", obj.Email);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public PacientesCLS RecuperarPacientes(int Id)
        {
            PacientesCLS oPacientesCLS = new PacientesCLS();

            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id as Id, Nombre as Nombre, Apellido as Apellido, FechaNacimiento as FechaNacimiento, Telefono as Telefono, Email as Email, Direccion as Direccion  FROM Pacientes WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", Id);
                        SqlDataReader dr = cmd.ExecuteReader();

                        if (dr.Read())
                        {
                            oPacientesCLS.Id = dr.IsDBNull(dr.GetOrdinal("Id")) ? 0 : dr.GetInt32(dr.GetOrdinal("Id"));
                            oPacientesCLS.Nombre = dr.IsDBNull(dr.GetOrdinal("Nombre")) ? string.Empty : dr.GetString(dr.GetOrdinal("Nombre"));
                            oPacientesCLS.Apellido = dr.IsDBNull(dr.GetOrdinal("Apellido")) ? string.Empty : dr.GetString(dr.GetOrdinal("Apellido"));
                            oPacientesCLS.FechaNacimiento = dr.IsDBNull(dr.GetOrdinal("FechaNacimiento")) ? DateTime.MinValue : dr.GetDateTime(dr.GetOrdinal("FechaNacimiento"));
                            oPacientesCLS.Telefono = dr.IsDBNull(dr.GetOrdinal("Telefono")) ? string.Empty : dr.GetString(dr.GetOrdinal("Telefono"));
                            oPacientesCLS.Email = dr.IsDBNull(dr.GetOrdinal("Email")) ? string.Empty : dr.GetString(dr.GetOrdinal("Email"));
                            oPacientesCLS.Direccion = dr.IsDBNull(dr.GetOrdinal("Direccion")) ? string.Empty : dr.GetString(dr.GetOrdinal("Direccion"));
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
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
                        cmd.CommandType = System.Data.CommandType.Text;

                        cmd.Parameters.AddWithValue("@Id", obj.Id); 
                        cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                        cmd.Parameters.AddWithValue("@Apellido", obj.Apellido);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", obj.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);
                        cmd.Parameters.AddWithValue("@Email", obj.Email);
                        cmd.Parameters.AddWithValue("@Direccion", obj.Direccion);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }



        public int EliminarPacientes(int Id)
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
                        cmd.Parameters.AddWithValue("@Id", Id);

                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }
    }
}

   

