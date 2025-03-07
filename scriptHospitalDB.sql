USE [master]
GO
/****** Object:  Database [HospitalDB]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
/****** Object:  Table [dbo].[Citas]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
/****** Object:  Table [dbo].[Especialidades]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
/****** Object:  Table [dbo].[Facturacion]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
/****** Object:  Table [dbo].[Medicos]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pacientes]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tratamientos]    Script Date: 05/03/2025 10:23:50 a. m. ******/
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
SET IDENTITY_INSERT [dbo].[Citas] ON 

INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (1, 1, 1, CAST(N'2024-08-01T14:00:00.000' AS DateTime), N'Cancelada')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (2, 2, 2, CAST(N'2024-08-02T10:30:00.000' AS DateTime), N'Confirmada')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (3, 3, 3, CAST(N'2024-08-03T11:00:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (4, 4, 4, CAST(N'2024-08-04T17:00:00.000' AS DateTime), N'Confirmada')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (5, 5, 5, CAST(N'2024-08-05T14:30:00.000' AS DateTime), N'Pendiente')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (6, 7, 12, CAST(N'2025-03-14T07:59:00.000' AS DateTime), N'Confirmada')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (7, 4, 15, CAST(N'2025-03-04T23:00:00.000' AS DateTime), N'Atendida')
INSERT [dbo].[Citas] ([Id], [PacienteId], [MedicoId], [FechaHora], [Estado]) VALUES (8, 7, 14, CAST(N'2025-03-05T02:00:00.000' AS DateTime), N'Pendiente')
SET IDENTITY_INSERT [dbo].[Citas] OFF
GO
SET IDENTITY_INSERT [dbo].[Especialidades] ON 

INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (1, N'Cardiologia')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (2, N'Dermatologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (3, N'Neurologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (4, N'Pediatri´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (5, N'Ginecologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (6, N'Oncologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (7, N'Psiquiatri´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (8, N'Ortopedia')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (9, N'Endocrinologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (10, N'Urologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (11, N'Oftalmologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (12, N'Otorrinolaringologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (13, N'Gastroenterologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (14, N'Neumologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (15, N'Reumatologi´a')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (16, N'loquería')
INSERT [dbo].[Especialidades] ([Id], [Nombre]) VALUES (17, N'aaaaa')
SET IDENTITY_INSERT [dbo].[Especialidades] OFF
GO
SET IDENTITY_INSERT [dbo].[Facturacion] ON 

INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (1, 1, CAST(120.50 AS Decimal(10, 2)), N'Tarjeta de crédito', CAST(N'2024-08-01' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (2, 2, CAST(200.75 AS Decimal(10, 2)), N'Transferencia', CAST(N'2024-08-02' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (3, 3, CAST(150.00 AS Decimal(10, 2)), N'Transferencia bancaria', CAST(N'2024-08-03' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (4, 4, CAST(450.00 AS Decimal(10, 2)), N'Tarjeta de de´bito', CAST(N'2024-08-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (5, 5, CAST(180.90 AS Decimal(10, 2)), N'Efectivo', CAST(N'2024-08-05' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (6, 4, CAST(450.00 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (7, 1, CAST(120.50 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (8, 3, CAST(150.00 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (9, 5, CAST(180.90 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (10, 2, CAST(200.75 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (11, 1, CAST(220.50 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (12, 1, CAST(220.50 AS Decimal(10, 2)), N'Tarjeta de crédito', CAST(N'2025-03-04' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (13, 1, CAST(220.50 AS Decimal(10, 2)), N'Transferencia', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (14, 7, CAST(500.00 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (15, 7, CAST(500.00 AS Decimal(10, 2)), N'Tarjeta de débito', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (16, 4, CAST(450.00 AS Decimal(10, 2)), N'Efectivo', CAST(N'2025-03-05' AS Date))
INSERT [dbo].[Facturacion] ([Id], [PacienteId], [Monto], [MetodoPago], [FechaPago]) VALUES (17, 4, CAST(450.00 AS Decimal(10, 2)), N'Tarjeta de crédito', CAST(N'2025-03-05' AS Date))
SET IDENTITY_INSERT [dbo].[Facturacion] OFF
GO
SET IDENTITY_INSERT [dbo].[Medicos] ON 

INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (1, N'Carlos', N'Herna´ndez', 1, N'095101010', N'carlos.hernandez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (2, N'Mari´a', N'Lo´pez', 2, N'095178910', N'maria.lopez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (3, N'Javier', N'Marti´nez', 3, N'095104571', N'javier.martinez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (4, N'Laura', N'Gonza´lez', 4, N'095101070', N'laura.gonzalez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (5, N'Fernando', N'Rodri´guez', 5, N'095112340', N'fernando.rodriguez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (6, N'Sofi´a', N'Ferna´ndez', 6, N'095101784', N'sofia.fernandez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (7, N'Alejandro', N'Pe´rez', 7, N'095107410', N'alejandro.perez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (8, N'Carmen', N'Sa´nchez', 8, N'091231010', N'carmen.sanchez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (9, N'Daniel', N'Rami´rez', 9, N'097461010', N'daniel.ramirez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (10, N'Paula', N'Jime´nez', 10, N'093821010', N'paula.jimenez@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (11, N'Ricardo', N'Morales', 11, N'097801010', N'ricardo.morales@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (12, N'Natalia', N'Reyes', 12, N'095174109', N'natalia.reyes@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (13, N'Esteban', N'Ortega', 13, N'095785236', N'esteban.ortega@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (14, N'Andrea', N'Castro', 14, N'097107040', N'andrea.castro@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (15, N'Hugo', N'Vargas', 15, N'094441010', N'hugo.vargas@hospital.com')
INSERT [dbo].[Medicos] ([Id], [Nombre], [Apellido], [EspecialidadId], [Telefono], [Email]) VALUES (16, N'Alison', N'Miranda', 1, N'0993190749', N'mirandacreamer@gmail.com')
SET IDENTITY_INSERT [dbo].[Medicos] OFF
GO
SET IDENTITY_INSERT [dbo].[Pacientes] ON 

INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (1, N'Luis', N'Gomez', CAST(N'1997-01-15' AS Date), N'095710336', N'luis.gomez@gmail.co', N'Calle 123, Ciudad A')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (2, N'Ana', N'Torres', CAST(N'2004-05-22' AS Date), N'095778936', N'ana.torres@gmail.com', N'Avenida 456, Ciudad B')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (3, N'Pedro', N'Mendoza', CAST(N'1999-08-30' AS Date), N'091115236', N'pedro.mendoza@gmail.com', N'Calle 789, Ciudad C')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (4, N'Elena', N'Duarte', CAST(N'1990-10-10' AS Date), N'095783419', N'elena.duarte@gmail.com', N'Avenida 123, Ciudad D')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (5, N'Roberto', N'Sosa', CAST(N'1979-12-25' AS Date), N'097845147', N'roberto.sosa@gmail.com', N'Calle 456, Ciudad E')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (7, N'Alison', N'Miranda', CAST(N'2025-03-31' AS Date), N'0993190749', N'mirandacreamer@gmail.com', N'Sangolquí')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (8, N'aaaaa', N'aaaaa', CAST(N'2025-03-07' AS Date), N'789456123', N'mcalison334@gmail.com', N'Sangolquí')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (10, N'bb', N'bb', CAST(N'2001-01-31' AS Date), N'741258963', N'asd@gmail.com', N'quito')
INSERT [dbo].[Pacientes] ([Id], [Nombre], [Apellido], [FechaNacimiento], [Telefono], [Email], [Direccion]) VALUES (11, N'daweed', N'moran', CAST(N'2014-07-17' AS Date), N'741258963', N'daweed@gmail.com', N'qcc')
SET IDENTITY_INSERT [dbo].[Pacientes] OFF
GO
SET IDENTITY_INSERT [dbo].[Tratamientos] ON 

INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (1, 1, N'Tratamiento de hipertension', CAST(N'2024-08-01' AS Date), CAST(120.50 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (2, 2, N'Terapia para la piel', CAST(N'2024-08-02' AS Date), CAST(200.75 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (3, 3, N'Evaluacio´n neurolo´gica', CAST(N'2024-08-03' AS Date), CAST(150.00 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (4, 4, N'Procedimiento ginecolo´gico', CAST(N'2024-08-04' AS Date), CAST(450.00 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (5, 5, N'Terapia ortope´dica', CAST(N'2024-08-05' AS Date), CAST(180.90 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (7, 1, N'holass', CAST(N'2025-03-21' AS Date), CAST(100.00 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (8, 7, N'holass', CAST(N'2025-03-29' AS Date), CAST(500.00 AS Decimal(10, 2)))
INSERT [dbo].[Tratamientos] ([Id], [PacienteId], [Descripcion], [Fecha], [Costo]) VALUES (9, 11, N'weed', CAST(N'2025-03-03' AS Date), CAST(50.00 AS Decimal(10, 2)))
SET IDENTITY_INSERT [dbo].[Tratamientos] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Medicos__A9D1053474D72EE7]    Script Date: 05/03/2025 10:23:51 a. m. ******/
ALTER TABLE [dbo].[Medicos] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Paciente__A9D105348E55EBAA]    Script Date: 05/03/2025 10:23:51 a. m. ******/
ALTER TABLE [dbo].[Pacientes] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
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
/****** Object:  StoredProcedure [dbo].[uspAgregarCitas]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspAgregarEspecialidades]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspAgregarFacturacion]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspAgregarMedicos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspAgregarPacientes]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspAgregarTratamientos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspEliminarCitas]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspEliminarEspecialidades]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspEliminarFacturacion]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspEliminarMedicos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspEliminarPacientes]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspEliminarTratamientos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspFiltrarCitas]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspFiltrarEspecialidades]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspFiltrarFacturacion]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspFiltrarMedicos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[uspFiltrarMedicos]
    @Nombre NVARCHAR(100) = NULL,
    @Apellido NVARCHAR(100) = NULL,
    @EspecialidadId INT = NULL,
    @Telefono NVARCHAR(20) = NULL,
    @Email NVARCHAR(100) = NULL
AS
BEGIN
    SELECT 
        Id as id, 
        Nombre as nombre, 
        Apellido as apellido, 
        EspecialidadId as especialidadId, 
        Telefono as telefono, 
        Email as email
    FROM Medicos
    WHERE 
        (@Nombre IS NULL OR Nombre LIKE '%' + @Nombre + '%') AND
        (@Apellido IS NULL OR Apellido LIKE '%' + @Apellido + '%') AND
        (@EspecialidadId IS NULL OR EspecialidadId = @EspecialidadId) AND
        (@Telefono IS NULL OR Telefono LIKE '%' + @Telefono + '%') AND
        (@Email IS NULL OR Email LIKE '%' + @Email + '%')
END

GO
/****** Object:  StoredProcedure [dbo].[uspFiltrarPacientes]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspFiltrarTratamientos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspListarCitas]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspListarEspecialidades]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspListarFacturacion]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspListarMedicos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspListarPacientes]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspListarTratamientos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspRecuperarCitas]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspRecuperarEspecialidades]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspRecuperarFacturacion]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspRecuperarMedicos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspRecuperarPacientes]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
/****** Object:  StoredProcedure [dbo].[uspRecuperarTratamientos]    Script Date: 05/03/2025 10:23:51 a. m. ******/
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
