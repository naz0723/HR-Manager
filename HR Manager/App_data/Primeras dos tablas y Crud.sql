
--Registro empleado
CREATE TABLE Empleado (
    EmpleadoID INT PRIMARY KEY IDENTITY(1,1),  -- ID único del empleado
    Nombre NVARCHAR(100),                      -- Nombre del empleado
    Direccion NVARCHAR(255),                   -- Dirección del empleado
    Contacto NVARCHAR(50),                     -- Información de contacto (teléfono, correo, etc.)
    FechaIngreso DATE,                         -- Fecha de ingreso del empleado a la empresa
    Cargo NVARCHAR(100),                       -- Cargo del empleado en la empresa
    Departamento NVARCHAR(100),                -- Departamento del empleado
    Salario DECIMAL(18, 2),                    -- Salario del empleado
    AdicionadoPor NVARCHAR(100),               -- Persona que añadió el empleado
    FechaRegistro DATETIME DEFAULT GETDATE(),  -- Fecha de registro del empleado
    ModificadoPor NVARCHAR(100),               -- Persona que modificó el empleado (opcional)
    FechaModificacion DATETIME,                -- Fecha de la última modificación del empleado (opcional)
);

--Estado laboral

CREATE TABLE EstadoLaboral (
    EstadoLaboralID INT PRIMARY KEY IDENTITY(1,1), -- ID único del estado laboral
    EmpleadoID INT,                                 -- Referencia al empleado
    Estado NVARCHAR(50),                            -- Estado laboral del empleado (Ej: "Activo", "Licencia", "Terminado")
    FechaInicio DATE,                               -- Fecha de inicio del estado
    FechaFin DATE,                                  -- Fecha de fin del estado (si aplica)
    AdicionadoPor NVARCHAR(100),                    -- Persona que añadió el estado
    FechaRegistro DATETIME DEFAULT GETDATE(),       -- Fecha de registro del estado laboral
    ModificadoPor NVARCHAR(100),                    -- Persona que modificó el estado (opcional)
    FechaModificacion DATETIME,                     -- Fecha de la última modificación (opcional)
    CONSTRAINT FK_Empleado FOREIGN KEY (EmpleadoID) REFERENCES Empleado(EmpleadoID)
);


-- Procedimientos para Empleado:

CREATE PROCEDURE sp_CrearEmpleado
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(255),
    @Contacto NVARCHAR(50),
    @FechaIngreso DATE,
    @Cargo NVARCHAR(100),
    @Departamento NVARCHAR(100),
    @Salario DECIMAL(18, 2),
    @AdicionadoPor NVARCHAR(50)
AS
BEGIN
    INSERT INTO Empleado (Nombre, Direccion, Contacto, FechaIngreso, Cargo, Departamento, Salario, AdicionadoPor)
    VALUES (@Nombre, @Direccion, @Contacto, @FechaIngreso, @Cargo, @Departamento, @Salario, @AdicionadoPor);
END

CREATE PROCEDURE sp_ActualizarEmpleado
    @EmpleadoID INT,
    @Nombre NVARCHAR(100),
    @Direccion NVARCHAR(255),
    @Contacto NVARCHAR(50),
    @FechaIngreso DATE,
    @Cargo NVARCHAR(100),
    @Departamento NVARCHAR(100),
    @Salario DECIMAL(18, 2),
    @ModificadoPor NVARCHAR(50)
AS
BEGIN
    UPDATE Empleado
    SET Nombre = @Nombre,
        Direccion = @Direccion,
        Contacto = @Contacto,
        FechaIngreso = @FechaIngreso,
        Cargo = @Cargo,
        Departamento = @Departamento,
        Salario = @Salario,
        ModificadoPor = @ModificadoPor
    WHERE EmpleadoID = @EmpleadoID;
END

CREATE PROCEDURE sp_EliminarEmpleado
    @EmpleadoID INT
AS
BEGIN
    DELETE FROM Empleado WHERE EmpleadoID = @EmpleadoID;
END

-- Procedimientos para Estado Laboral:

CREATE PROCEDURE sp_CrearEstadoLaboral
    @EmpleadoID INT,
    @Estado NVARCHAR(50),
    @FechaInicio DATE,
    @FechaFin DATE,
    @AdicionadoPor NVARCHAR(50)
AS
BEGIN
    INSERT INTO EstadoLaboral (EmpleadoID, Estado, FechaInicio, FechaFin, AdicionadoPor)
    VALUES (@EmpleadoID, @Estado, @FechaInicio, @FechaFin, @AdicionadoPor);
END

CREATE PROCEDURE sp_ActualizarEstadoLaboral
    @EstadoLaboralID INT,
    @EmpleadoID INT,
    @Estado NVARCHAR(50),
    @FechaInicio DATE,
    @FechaFin DATE,
    @ModificadoPor NVARCHAR(50)
AS
BEGIN
    UPDATE EstadoLaboral
    SET EmpleadoID = @EmpleadoID,
        Estado = @Estado,
        FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        ModificadoPor = @ModificadoPor
    WHERE EstadoLaboralID = @EstadoLaboralID;
END

CREATE PROCEDURE sp_EliminarEstadoLaboral
    @EstadoLaboralID INT
AS
BEGIN
    DELETE FROM EstadoLaboral WHERE EstadoLaboralID = @EstadoLaboralID;
END