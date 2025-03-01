
USE HospitalDB;
GO



CREATE PROCEDURE AgregarPacientes
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @FechaNacimiento DATE,
    @Telefono NVARCHAR(15),
    @Email NVARCHAR(100),
    @Direccion NVARCHAR(255)
AS
BEGIN
    INSERT INTO Pacientes (Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion)
    VALUES (@Nombre, @Apellido, @FechaNacimiento, @Telefono, @Email, @Direccion);
END;
GO





CREATE PROCEDURE EliminarPacientes
    @Id INT
AS
BEGIN
    DELETE FROM Pacientes WHERE Id = @Id;
END;
GO




CREATE PROCEDURE ListarPacientes
AS
BEGIN
    SELECT * FROM Pacientes;
END;
GO




CREATE PROCEDURE FiltrarPacientes
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Pacientes WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO




CREATE PROCEDURE RecuperarPacientes
    @Id INT
AS
BEGIN
    SELECT * FROM Pacientes WHERE Id = @Id;
END;
GO









CREATE PROCEDURE AgregarMedicos
    @Nombre NVARCHAR(100),
    @Apellido NVARCHAR(100),
    @EspecialidadId INT,
    @Telefono NVARCHAR(15),
    @Email NVARCHAR(100)
AS
BEGIN
    INSERT INTO Medicos (Nombre, Apellido, EspecialidadId, Telefono, Email)
    VALUES (@Nombre, @Apellido, @EspecialidadId, @Telefono, @Email);
END;
GO




CREATE PROCEDURE EliminarMedicos
    @Id INT
AS
BEGIN
    DELETE FROM Medicos WHERE Id = @Id;
END;
GO




CREATE PROCEDURE ListarMedicos
AS
BEGIN
    SELECT * FROM Medicos;
END;
GO




CREATE PROCEDURE FiltrarMedicos
    @EspecialidadId INT
AS
BEGIN
    SELECT * FROM Medicos WHERE EspecialidadId = @EspecialidadId;
END;
GO



CREATE PROCEDURE RecuperarMedicos
    @Id INT
AS
BEGIN
    SELECT * FROM Medicos WHERE Id = @Id;
END;
GO









CREATE PROCEDURE AgregarEspecialidades
    @Nombre NVARCHAR(100)
AS
BEGIN
    INSERT INTO Especialidades (Nombre)
    VALUES (@Nombre);
END;
GO



CREATE PROCEDURE EliminarEspecialidades
    @Id INT
AS
BEGIN
    DELETE FROM Especialidades WHERE Id = @Id;
END;
GO



CREATE PROCEDURE ListarEspecialidades
AS
BEGIN
    SELECT * FROM Especialidades;
END;
GO



CREATE PROCEDURE FiltrarEspecialidades
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT * FROM Especialidades WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO



CREATE PROCEDURE RecuperarEspecialidades
    @Id INT
AS
BEGIN
    SELECT * FROM Especialidades WHERE Id = @Id;
END;
GO






CREATE PROCEDURE AgregarCitas
    @PacienteId INT,
    @MedicoId INT,
    @FechaHora DATETIME,
    @Estado NVARCHAR(20)
AS
BEGIN
    INSERT INTO Citas (PacienteId, MedicoId, FechaHora, Estado)
    VALUES (@PacienteId, @MedicoId, @FechaHora, @Estado);
END;
GO





CREATE PROCEDURE EliminarCitas
    @Id INT
AS
BEGIN
    DELETE FROM Citas WHERE Id = @Id;
END;
GO



CREATE PROCEDURE ListarCitas
AS
BEGIN
    SELECT * FROM Citas;
END;
GO



CREATE PROCEDURE FiltrarCitas
    @PacienteId INT
AS
BEGIN
    SELECT * FROM Citas WHERE PacienteId = @PacienteId;
END;
GO



CREATE PROCEDURE RecuperarCitas
    @Id INT
AS
BEGIN
    SELECT * FROM Citas WHERE Id = @Id;
END;
GO





CREATE PROCEDURE AgregarTratamientos
    @PacienteId INT,
    @Descripcion NVARCHAR(255),
    @Fecha DATE,
    @Costo DECIMAL(10,2)
AS
BEGIN
    INSERT INTO Tratamientos (PacienteId, Descripcion, Fecha, Costo)
    VALUES (@PacienteId, @Descripcion, @Fecha, @Costo);
END;
GO



CREATE PROCEDURE EliminarTratamientos
    @Id INT
AS
BEGIN
    DELETE FROM Tratamientos WHERE Id = @Id;
END;
GO



CREATE PROCEDURE ListarTratamientos
AS
BEGIN
    SELECT * FROM Tratamientos;
END;
GO



CREATE PROCEDURE FiltrarTratamientos
    @PacienteId INT
AS
BEGIN
    SELECT * FROM Tratamientos WHERE PacienteId = @PacienteId;
END;
GO



CREATE PROCEDURE RecuperarTratamientos
    @Id INT
AS
BEGIN
    SELECT * FROM Tratamientos WHERE Id = @Id;
END;
GO





CREATE PROCEDURE AgregarFacturacion
    @PacienteId INT,
    @Monto DECIMAL(10,2),
    @MetodoPago NVARCHAR(50),
    @FechaPago DATE
AS
BEGIN
    INSERT INTO Facturacion (PacienteId, Monto, MetodoPago, FechaPago)
    VALUES (@PacienteId, @Monto, @MetodoPago, @FechaPago);
END;
GO



CREATE PROCEDURE EliminarFacturacion
    @Id INT
AS
BEGIN
    DELETE FROM Facturacion WHERE Id = @Id;
END;
GO



CREATE PROCEDURE ListarFacturacion
AS
BEGIN
    SELECT * FROM Facturacion;
END;
GO



CREATE PROCEDURE FiltrarFacturacion
    @PacienteId INT
AS
BEGIN
    SELECT * FROM Facturacion WHERE PacienteId = @PacienteId;
END;
GO




CREATE PROCEDURE RecuperarFacturacion
    @Id INT
AS
BEGIN
    SELECT * FROM Facturacion WHERE Id = @Id;
END;
GO
