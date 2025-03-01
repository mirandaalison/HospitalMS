
USE HospitalDB;
GO



INSERT INTO Especialidades (Nombre) VALUES 
('Cardiología'), ('Dermatología'), ('Neurología'), ('Pediatría'), ('Ginecología'),
('Oncología'), ('Psiquiatría'), ('Ortopedia'), ('Endocrinología'), ('Urología'),
('Oftalmología'), ('Otorrinolaringología'), ('Gastroenterología'), ('Neumología'), ('Reumatología');
GO

INSERT INTO Medicos (Nombre, Apellido, EspecialidadId, Telefono, Email) VALUES 
('Carlos', 'Hernández', 1, '095101010', 'carlos.hernandez@hospital.com'),
('María', 'López', 2, '095178910', 'maria.lopez@hospital.com'),
('Javier', 'Martínez', 3, '095104571', 'javier.martinez@hospital.com'),
('Laura', 'González', 4, '095101070', 'laura.gonzalez@hospital.com'),
('Fernando', 'Rodríguez', 5, '095112340', 'fernando.rodriguez@hospital.com'),
('Sofía', 'Fernández', 6, '095101784', 'sofia.fernandez@hospital.com'),
('Alejandro', 'Pérez', 7, '095107410', 'alejandro.perez@hospital.com'),
('Carmen', 'Sánchez', 8, '091231010', 'carmen.sanchez@hospital.com'),
('Daniel', 'Ramírez', 9, '097461010', 'daniel.ramirez@hospital.com'),
('Paula', 'Jiménez', 10, '093821010', 'paula.jimenez@hospital.com'),
('Ricardo', 'Morales', 11, '097801010', 'ricardo.morales@hospital.com'),
('Natalia', 'Reyes', 12, '095174109', 'natalia.reyes@hospital.com'),
('Esteban', 'Ortega', 13, '095785236', 'esteban.ortega@hospital.com'),
('Andrea', 'Castro', 14, '097107040', 'andrea.castro@hospital.com'),
('Hugo', 'Vargas', 15, '094441010', 'hugo.vargas@hospital.com');
GO

INSERT INTO Pacientes (Nombre, Apellido, FechaNacimiento, Telefono, Email, Direccion) VALUES 
('Luis', 'Gómez', '1997-01-15', '095710336', 'luis.gomez@gmail.com', 'Calle 123, Ciudad A'),
('Ana', 'Torres', '2004-05-22', '095778936', 'ana.torres@gmail.com', 'Avenida 456, Ciudad B'),
('Pedro', 'Mendoza', '1999-08-30', '091115236', 'pedro.mendoza@gmail.com', 'Calle 789, Ciudad C'),
('Elena', 'Duarte', '1990-10-10', '095783419', 'elena.duarte@gmail.com', 'Avenida 123, Ciudad D'),
('Roberto', 'Sosa', '1979-12-25', '097845147', 'roberto.sosa@gmail.com', 'Calle 456, Ciudad E');
GO

INSERT INTO Citas (PacienteId, MedicoId, FechaHora, Estado) VALUES 
(1, 1, '2024-08-01 09:00:00', 'Pendiente'),
(2, 2, '2024-08-02 10:30:00', 'Confirmada'),
(3, 3, '2024-08-03 11:00:00', 'Pendiente'),
(4, 4, '2024-08-04 12:00:00', 'Cancelada'),
(5, 5, '2024-08-05 14:30:00', 'Pendiente');
GO

INSERT INTO Tratamientos (PacienteId, Descripcion, Fecha, Costo) VALUES 
(1, 'Tratamiento de hipertensión', '2024-08-01', 120.50),
(2, 'Terapia para la piel', '2024-08-02', 200.75),
(3, 'Evaluación neurológica', '2024-08-03', 150.00),
(4, 'Procedimiento ginecológico', '2024-08-04', 450.00),
(5, 'Terapia ortopédica', '2024-08-05', 180.90);
GO

INSERT INTO Facturacion (PacienteId, Monto, MetodoPago, FechaPago) VALUES 
(1, 120.50, 'Tarjeta de crédito', '2024-08-01'),
(2, 200.75, 'Efectivo', '2024-08-02'),
(3, 150.00, 'Transferencia bancaria', '2024-08-03'),
(4, 450.00, 'Tarjeta de débito', '2024-08-04'),
(5, 180.90, 'Efectivo', '2024-08-05');
GO