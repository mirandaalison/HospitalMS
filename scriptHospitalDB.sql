USE [master]
GO
/****** Object:  Database [HospitalDB]    Script Date: 04/03/2025 11:28:42 p. m. ******/
CREATE DATABASE [HospitalDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HospitalDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HospitalDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HospitalDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\HospitalDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HospitalDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HospitalDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HospitalDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HospitalDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HospitalDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HospitalDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HospitalDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HospitalDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HospitalDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HospitalDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HospitalDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HospitalDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HospitalDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HospitalDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HospitalDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HospitalDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HospitalDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HospitalDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HospitalDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HospitalDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HospitalDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HospitalDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HospitalDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HospitalDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HospitalDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HospitalDB] SET  MULTI_USER 
GO
ALTER DATABASE [HospitalDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HospitalDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HospitalDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HospitalDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HospitalDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HospitalDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [HospitalDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [HospitalDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HospitalDB]
GO
/****** Object:  Table [dbo].[Citas]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Citas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PacienteId] [int] NULL,
	[MedicoId] [int] NULL,
	[FechaHora] [datetime] NOT NULL,
	[Estado] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Especialidades]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Especialidades](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facturacion]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facturacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PacienteId] [int] NULL,
	[Monto] [decimal](10, 2) NOT NULL,
	[MetodoPago] [nvarchar](50) NOT NULL,
	[FechaPago] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Medicos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Medicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[EspecialidadId] [int] NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pacientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[Telefono] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Direccion] [nvarchar](255) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamientos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tratamientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PacienteId] [int] NULL,
	[Descripcion] [nvarchar](255) NOT NULL,
	[Fecha] [date] NOT NULL,
	[Costo] [decimal](10, 2) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([MedicoId])
REFERENCES [dbo].[Medicos] ([Id])
GO
ALTER TABLE [dbo].[Citas]  WITH CHECK ADD FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Pacientes] ([Id])
GO
ALTER TABLE [dbo].[Facturacion]  WITH CHECK ADD FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Pacientes] ([Id])
GO
ALTER TABLE [dbo].[Tratamientos]  WITH CHECK ADD FOREIGN KEY([PacienteId])
REFERENCES [dbo].[Pacientes] ([Id])
GO
/****** Object:  StoredProcedure [dbo].[uspAgregarCitas]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO






CREATE PROCEDURE [dbo].[uspAgregarCitas]
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
/****** Object:  StoredProcedure [dbo].[uspAgregarEspecialidades]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspAgregarEspecialidades]
    @Nombre NVARCHAR(100)
AS
BEGIN
    INSERT INTO Especialidades (Nombre)
    VALUES (@Nombre);
END;
GO
/****** Object:  StoredProcedure [dbo].[uspAgregarFacturacion]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspAgregarFacturacion]
    @Id INT,
    @PacienteId INT,
    @Monto DECIMAL(10,2),
    @MetodoPago NVARCHAR(50),
    @FechaPago DATE
AS
BEGIN
    IF @Id = 0 OR @Id IS NULL
    BEGIN
        -- Inserción
        INSERT INTO Facturacion (PacienteId, Monto, MetodoPago, FechaPago)
        VALUES (@PacienteId, @Monto, @MetodoPago, @FechaPago);
    END
    ELSE
    BEGIN
        -- Actualización
        UPDATE Facturacion
        SET PacienteId = @PacienteId,
            Monto = @Monto,
            MetodoPago = @MetodoPago,
            FechaPago = @FechaPago
        WHERE Id = @Id;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[uspAgregarMedicos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspAgregarMedicos]
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
/****** Object:  StoredProcedure [dbo].[uspAgregarPacientes]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[uspAgregarPacientes]
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
/****** Object:  StoredProcedure [dbo].[uspAgregarTratamientos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para agregar un Tratamiento
CREATE PROCEDURE [dbo].[uspAgregarTratamientos]
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
/****** Object:  StoredProcedure [dbo].[uspEliminarCitas]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[uspEliminarCitas]
    @Id INT
AS
BEGIN
    DELETE FROM Citas WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarEspecialidades]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarEspecialidades]
    @Id INT
AS
BEGIN
    DELETE FROM Especialidades WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarFacturacion]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[uspEliminarFacturacion]
    @Id INT
AS
BEGIN
    DELETE FROM Facturacion WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarMedicos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarMedicos]
    @Id INT
AS
BEGIN
    DELETE FROM Medicos WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarPacientes]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[uspEliminarPacientes]
    @Id INT
AS
BEGIN
    DELETE FROM Pacientes WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspEliminarTratamientos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspEliminarTratamientos]
    @Id INT
AS
BEGIN
    DELETE FROM Tratamientos WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarCitas]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspFiltrarCitas
CREATE PROCEDURE [dbo].[uspFiltrarCitas]
    @PacienteId INT
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        MedicoId as medicoId,
        FechaHora as fechaHora,
        Estado as estado
    FROM Citas WHERE PacienteId = @PacienteId;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarEspecialidades]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspFiltrarEspecialidades
CREATE PROCEDURE [dbo].[uspFiltrarEspecialidades]
    @Nombre NVARCHAR(100)
AS
BEGIN
    SELECT 
        Id as id,
        Nombre as nombre
    FROM Especialidades WHERE Nombre LIKE '%' + @Nombre + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarFacturacion]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspFiltrarFacturacion
CREATE PROCEDURE [dbo].[uspFiltrarFacturacion]
    @PacienteId INT = NULL,
    @MetodoPago NVARCHAR(50) = NULL,
    @FechaPago DATE = NULL
AS
BEGIN
    SELECT 
        Id AS id,
        PacienteId AS pacienteId,
        Monto AS monto,
        MetodoPago AS metodoPago,
        FechaPago AS fechaPago
    FROM 
        Facturacion
    WHERE 
        (@PacienteId IS NULL OR PacienteId = @PacienteId) AND
        (@MetodoPago IS NULL OR MetodoPago LIKE '%' + @MetodoPago + '%') AND
        (@FechaPago IS NULL OR FechaPago = @FechaPago);
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarMedicos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspFiltrarMedicos
CREATE PROCEDURE [dbo].[uspFiltrarMedicos]
    @EspecialidadId INT
AS
BEGIN
    SELECT 
        Id as id,
        Nombre as nombre,
        Apellido as apellido,
        EspecialidadId as especialidadId,
        Telefono as telefono,
        Email as email
    FROM Medicos WHERE EspecialidadId = @EspecialidadId;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarPacientes]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[uspFiltrarPacientes]
    @Nombre NVARCHAR(100) = NULL,
    @Apellido NVARCHAR(100) = NULL,
    @FechaNacimiento DATE = NULL,
    @Telefono NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL,
    @Direccion NVARCHAR(200) = NULL
AS
BEGIN
    SELECT 
        Id as id, 
        Nombre as nombre, 
        Apellido as apellido, 
        FechaNacimiento as fechaNacimiento, 
        Telefono as telefono, 
        Email as email, 
        Direccion as direccion
    FROM Pacientes
    WHERE 
        (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%') AND
        (@Apellido IS NULL OR Apellido LIKE '%' + @Apellido + '%') AND
        (@FechaNacimiento IS NULL OR FechaNacimiento = @FechaNacimiento) AND
        (@Telefono IS NULL OR Telefono LIKE '%' + @Telefono + '%') AND
        (@Email IS NULL OR Email LIKE '%' + @Email + '%') AND
        (@Direccion IS NULL OR Direccion LIKE '%' + @Direccion + '%')
END
GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarTratamientos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFiltrarTratamientos]
    @PacienteId INT = NULL,
    @Descripcion NVARCHAR(100) = NULL,
    @Fecha DATE = NULL,
    @Costo DECIMAL(18, 2) = NULL
AS
BEGIN
    SELECT 
        Id AS id,
        PacienteId AS pacienteId,
        Descripcion AS descripcion,
        Fecha AS fecha,
        Costo AS costo
    FROM Tratamientos
    WHERE 
        (@PacienteId IS NULL OR PacienteId = @PacienteId) AND
        (@Descripcion IS NULL OR Descripcion LIKE '%' + @Descripcion + '%') AND
        (@Fecha IS NULL OR Fecha = @Fecha) AND
        (@Costo IS NULL OR Costo = @Costo);
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarCitas]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspListarCitas
CREATE PROCEDURE [dbo].[uspListarCitas]
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        MedicoId as medicoId,
        FechaHora as fechaHora,
        Estado as estado
    FROM Citas;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarEspecialidades]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspListarEspecialidades
CREATE PROCEDURE [dbo].[uspListarEspecialidades]
AS
BEGIN
    SELECT 
        Id as id,
        Nombre as nombre
    FROM Especialidades;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarFacturacion]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspListarFacturacion
CREATE PROCEDURE [dbo].[uspListarFacturacion]
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        Monto as monto,
        MetodoPago as metodoPago,
        FechaPago as fechaPago
    FROM Facturacion;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarMedicos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspListarMedicos
CREATE PROCEDURE [dbo].[uspListarMedicos]
AS
BEGIN
    SELECT 
        Id as id,
        Nombre as nombre,
        Apellido as apellido,
        EspecialidadId as especialidadId,
        Telefono as telefono,
        Email as email
    FROM Medicos;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspListarPacientes]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[uspListarPacientes]
AS
BEGIN
    SELECT 
        Id as id, 
        Nombre as nombre, 
        Apellido as apellido, 
        FechaNacimiento as fechaNacimiento, 
        Telefono as telefono, 
        Email as email, 
        Direccion as direccion 
    FROM Pacientes
END
GO
/****** Object:  StoredProcedure [dbo].[uspListarTratamientos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspListarTratamientos
CREATE PROCEDURE [dbo].[uspListarTratamientos]
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        Descripcion as descripcion,
        Fecha as fecha,
        Costo as costo
    FROM Tratamientos;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarCitas]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspRecuperarCitas
CREATE PROCEDURE [dbo].[uspRecuperarCitas]
    @Id INT
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        MedicoId as medicoId,
        FechaHora as fechaHora,
        Estado as estado
    FROM Citas WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarEspecialidades]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspRecuperarEspecialidades
CREATE PROCEDURE [dbo].[uspRecuperarEspecialidades]
    @Id INT
AS
BEGIN
    SELECT 
        Id as id,
        Nombre as nombre
    FROM Especialidades WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarFacturacion]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspRecuperarFacturacion
CREATE PROCEDURE [dbo].[uspRecuperarFacturacion]
    @Id INT
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        Monto as monto,
        MetodoPago as metodoPago,
        FechaPago as fechaPago
    FROM Facturacion WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarMedicos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspRecuperarMedicos
CREATE PROCEDURE [dbo].[uspRecuperarMedicos]
    @Id INT
AS
BEGIN
    SELECT 
        Id as id,
        Nombre as nombre,
        Apellido as apellido,
        EspecialidadId as especialidadId,
        Telefono as telefono,
        Email as email
    FROM Medicos WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarPacientes]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[uspRecuperarPacientes]
    @Id INT
AS
BEGIN
    SELECT * FROM Pacientes WHERE Id = @Id;
END;
GO
/****** Object:  StoredProcedure [dbo].[uspRecuperarTratamientos]    Script Date: 04/03/2025 11:28:42 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Modificar uspRecuperarTratamientos
CREATE PROCEDURE [dbo].[uspRecuperarTratamientos]
    @Id INT
AS
BEGIN
    SELECT 
        Id as id,
        PacienteId as pacienteId,
        Descripcion as descripcion,
        Fecha as fecha,
        Costo as costo
    FROM Tratamientos WHERE Id = @Id;
END;
GO
USE [master]
GO
ALTER DATABASE [HospitalDB] SET  READ_WRITE 
GO
