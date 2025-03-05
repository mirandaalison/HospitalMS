using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using CapaEntidad;

namespace CapaDatos
{
    public class CitasDAL : CadenaDAL
    {
        public List<CitasCLS> ListarCitas()
        {
            List<CitasCLS> lista = new List<CitasCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT c.Id, c.PacienteId, c.MedicoId, c.FechaHora, c.Estado, p.Nombre AS NombrePaciente, p.Apellido AS ApellidoPaciente, m.Nombre AS NombreMedico, m.Apellido AS ApellidoMedico, e.Nombre AS Especialidad FROM Citas c INNER JOIN Pacientes p ON c.PacienteId = p.Id INNER JOIN Medicos m ON c.MedicoId = m.Id INNER JOIN Especialidades e ON m.EspecialidadId = e.Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CitasCLS cita = new CitasCLS();
                                cita.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                cita.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                cita.medicoId = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
                                cita.fechaHora = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                cita.estado = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                cita.nombrePaciente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                cita.apellidoPaciente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                                cita.nombreMedico = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
                                cita.apellidoMedico = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
                                cita.especialidad = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);
                                lista.Add(cita);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarCitas: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public List<CitasCLS> FiltrarCitas(CitasCLS obj)
        {
            List<CitasCLS> lista = new List<CitasCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    string consulta = "SELECT c.Id, c.PacienteId, c.MedicoId, c.FechaHora, c.Estado, p.Nombre AS NombrePaciente, p.Apellido AS ApellidoPaciente, m.Nombre AS NombreMedico, m.Apellido AS ApellidoMedico, e.Nombre AS Especialidad FROM Citas c INNER JOIN Pacientes p ON c.PacienteId = p.Id INNER JOIN Medicos m ON c.MedicoId = m.Id INNER JOIN Especialidades e ON m.EspecialidadId = e.Id WHERE 1=1 ";

                    if (obj.pacienteId > 0)
                        consulta += "AND c.PacienteId = @PacienteId ";
                    if (obj.medicoId > 0)
                        consulta += "AND c.MedicoId = @MedicoId ";
                    if (!string.IsNullOrEmpty(obj.estado))
                        consulta += "AND c.Estado LIKE '%' + @Estado + '%' ";
                    if (obj.fechaHora != DateTime.MinValue)
                        consulta += "AND CONVERT(DATE, c.FechaHora) = CONVERT(DATE, @FechaHora) ";

                    using (SqlCommand cmd = new SqlCommand(consulta, cn))
                    {
                        cmd.CommandType = CommandType.Text;

                        if (obj.pacienteId > 0)
                            cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        if (obj.medicoId > 0)
                            cmd.Parameters.AddWithValue("@MedicoId", obj.medicoId);
                        if (!string.IsNullOrEmpty(obj.estado))
                            cmd.Parameters.AddWithValue("@Estado", obj.estado);
                        if (obj.fechaHora != DateTime.MinValue)
                            cmd.Parameters.AddWithValue("@FechaHora", obj.fechaHora);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                CitasCLS cita = new CitasCLS();
                                cita.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                cita.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                cita.medicoId = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
                                cita.fechaHora = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                cita.estado = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                cita.nombrePaciente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                cita.apellidoPaciente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                                cita.nombreMedico = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
                                cita.apellidoMedico = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
                                cita.especialidad = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);
                                lista.Add(cita);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en FiltrarCitas: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public int GuardarCitas(CitasCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Citas(PacienteId, MedicoId, FechaHora, Estado) VALUES (@PacienteId, @MedicoId, @FechaHora, @Estado);", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        cmd.Parameters.AddWithValue("@MedicoId", obj.medicoId);
                        cmd.Parameters.AddWithValue("@FechaHora", obj.fechaHora);
                        cmd.Parameters.AddWithValue("@Estado", obj.estado ?? "Pendiente");
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCitas: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public CitasCLS RecuperarCitas(int id)
        {
            CitasCLS oCitasCLS = new CitasCLS();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT c.Id, c.PacienteId, c.MedicoId, c.FechaHora, c.Estado, p.Nombre AS NombrePaciente, p.Apellido AS ApellidoPaciente, m.Nombre AS NombreMedico, m.Apellido AS ApellidoMedico, e.Nombre AS Especialidad FROM Citas c INNER JOIN Pacientes p ON c.PacienteId = p.Id INNER JOIN Medicos m ON c.MedicoId = m.Id INNER JOIN Especialidades e ON m.EspecialidadId = e.Id WHERE c.Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                oCitasCLS.id = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                oCitasCLS.pacienteId = dr.IsDBNull(1) ? 0 : dr.GetInt32(1);
                                oCitasCLS.medicoId = dr.IsDBNull(2) ? 0 : dr.GetInt32(2);
                                oCitasCLS.fechaHora = dr.IsDBNull(3) ? DateTime.MinValue : dr.GetDateTime(3);
                                oCitasCLS.estado = dr.IsDBNull(4) ? string.Empty : dr.GetString(4);
                                oCitasCLS.nombrePaciente = dr.IsDBNull(5) ? string.Empty : dr.GetString(5);
                                oCitasCLS.apellidoPaciente = dr.IsDBNull(6) ? string.Empty : dr.GetString(6);
                                oCitasCLS.nombreMedico = dr.IsDBNull(7) ? string.Empty : dr.GetString(7);
                                oCitasCLS.apellidoMedico = dr.IsDBNull(8) ? string.Empty : dr.GetString(8);
                                oCitasCLS.especialidad = dr.IsDBNull(9) ? string.Empty : dr.GetString(9);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en RecuperarCitas: " + ex.Message);
                    throw;
                }
            }
            return oCitasCLS;
        }

        public int GuardarCambiosCitas(CitasCLS obj)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Citas SET PacienteId = @PacienteId, MedicoId = @MedicoId, FechaHora = @FechaHora, Estado = @Estado WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", obj.id);
                        cmd.Parameters.AddWithValue("@PacienteId", obj.pacienteId);
                        cmd.Parameters.AddWithValue("@MedicoId", obj.medicoId);
                        cmd.Parameters.AddWithValue("@FechaHora", obj.fechaHora);
                        cmd.Parameters.AddWithValue("@Estado", obj.estado ?? string.Empty);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en GuardarCambiosCitas: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public int EliminarCitas(int id)
        {
            int rpta = 0;
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Citas WHERE Id = @Id", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id", id);
                        rpta = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en EliminarCitas: " + ex.Message);
                    rpta = 0;
                    throw;
                }
            }
            return rpta;
        }

        public List<PacientesCLS> ListarPacientesCombo()
        {
            List<PacientesCLS> lista = new List<PacientesCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre + ' ' + Apellido AS NombreCompleto FROM Pacientes ORDER BY Apellido", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                PacientesCLS paciente = new PacientesCLS();
                                paciente.id = dr.GetInt32(0);
                                paciente.nombre = dr.GetString(1);
                                lista.Add(paciente);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarPacientesCombo: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }

        public List<MedicosCLS> ListarMedicosCombo()
        {
            List<MedicosCLS> lista = new List<MedicosCLS>();
            using (SqlConnection cn = new SqlConnection(cadena))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT m.Id, m.Nombre + ' ' + m.Apellido + ' (' + e.Nombre + ')' AS NombreCompleto FROM Medicos m INNER JOIN Especialidades e ON m.EspecialidadId = e.Id ORDER BY m.Apellido", cn))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                MedicosCLS medico = new MedicosCLS();
                                medico.id = dr.GetInt32(0);
                                medico.nombre = dr.GetString(1);
                                lista.Add(medico);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error en ListarMedicosCombo: " + ex.Message);
                    throw;
                }
            }
            return lista;
        }
    }
}