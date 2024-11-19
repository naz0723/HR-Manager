1. Control de horas trabajadas (entrada/salida)


CREATE PROCEDURE sp_CrearControlHoras
    @EmpleadoID INT,
    @Fecha DATE,
    @HoraEntrada TIME
AS
BEGIN
    INSERT INTO ControlHoras (EmpleadoID, Fecha, HoraEntrada)
    VALUES (@EmpleadoID, @Fecha, @HoraEntrada);
END


CREATE PROCEDURE sp_ActualizarControlHoras
    @ControlHorasID INT,
    @HoraSalida TIME
AS
BEGIN
    UPDATE ControlHoras
    SET HoraSalida = @HoraSalida
    WHERE ID = @ControlHorasID;
END


CREATE PROCEDURE sp_EliminarControlHoras
    @ControlHorasID INT
AS
BEGIN
    DELETE FROM ControlHoras WHERE ID = @ControlHorasID;
END

---------------------------------------------------------

2. Gestión de ausencias, permisos y licencias

CREATE PROCEDURE sp_CrearGestionAusencias
    @EmpleadoID INT,
    @FechaInicio DATE,
    @FechaFin DATE,
    @TipoAusencia NVARCHAR(50),
    @Motivo NVARCHAR(255)
AS
BEGIN
    INSERT INTO GestionAusencias (EmpleadoID, FechaInicio, FechaFin, TipoAusencia, Motivo)
    VALUES (@EmpleadoID, @FechaInicio, @FechaFin, @TipoAusencia, @Motivo);
END


CREATE PROCEDURE sp_ActualizarGestionAusencias
    @AusenciaID INT,
    @FechaInicio DATE,
    @FechaFin DATE,
    @TipoAusencia NVARCHAR(50),
    @Motivo NVARCHAR(255)
AS
BEGIN
    UPDATE GestionAusencias
    SET FechaInicio = @FechaInicio,
        FechaFin = @FechaFin,
        TipoAusencia = @TipoAusencia,
        Motivo = @Motivo
    WHERE ID = @AusenciaID;
END


CREATE PROCEDURE sp_EliminarGestionAusencias
    @AusenciaID INT
AS
BEGIN
    DELETE FROM GestionAusencias WHERE ID = @AusenciaID;
END


------------------------------------------------------------

3. Reportes de puntualidad y cumplimiento de horas laborales


CREATE PROCEDURE sp_CrearReportePuntualidad
    @EmpleadoID INT,
    @Mes INT,
    @Año INT,
    @DiasTarde INT,
    @DiasCumplidos INT,
    @HorasExtras FLOAT
AS
BEGIN
    INSERT INTO ReportesPuntualidad (EmpleadoID, Mes, Año, DiasTarde, DiasCumplidos, HorasExtras)
    VALUES (@EmpleadoID, @Mes, @Año, @DiasTarde, @DiasCumplidos, @HorasExtras);
END



CREATE PROCEDURE sp_ActualizarReportePuntualidad
    @ReporteID INT,
    @DiasTarde INT,
    @DiasCumplidos INT,
    @HorasExtras FLOAT
AS
BEGIN
    UPDATE ReportesPuntualidad
    SET DiasTarde = @DiasTarde,
        DiasCumplidos = @DiasCumplidos,
        HorasExtras = @HorasExtras
    WHERE ID = @ReporteID;
END



CREATE PROCEDURE sp_EliminarReportePuntualidad
    @ReporteID INT
AS
BEGIN
    DELETE FROM ReportesPuntualidad WHERE ID = @ReporteID;
END


--Tablas

CREATE TABLE ControlHoras (
    ID INT IDENTITY(1,1) PRIMARY KEY, -- Identificador único para cada registro
    EmpleadoID INT NOT NULL,          -- ID del empleado
    Fecha DATE NOT NULL,              -- Fecha de registro
    HoraEntrada TIME NOT NULL,        -- Hora de entrada
    HoraSalida TIME NULL              -- Hora de salida, puede ser NULL inicialmente
);


CREATE TABLE GestionAusencias (
    ID INT IDENTITY(1,1) PRIMARY KEY, -- Identificador único para cada ausencia
    EmpleadoID INT NOT NULL,          -- ID del empleado
    FechaInicio DATE NOT NULL,        -- Fecha de inicio de la ausencia
    FechaFin DATE NOT NULL,           -- Fecha de fin de la ausencia
    TipoAusencia NVARCHAR(50) NOT NULL, -- Tipo de ausencia (permiso, licencia, etc.)
    Motivo NVARCHAR(255) NOT NULL     -- Motivo de la ausencia
);


CREATE TABLE ReportesPuntualidad (
    ID INT IDENTITY(1,1) PRIMARY KEY, -- Identificador único para cada reporte
    EmpleadoID INT NOT NULL,          -- ID del empleado
    Mes INT NOT NULL,                 -- Mes del reporte (1-12)
    Año INT NOT NULL,                 -- Año del reporte
    DiasTarde INT NOT NULL,           -- Número de días que el empleado llegó tarde
    DiasCumplidos INT NOT NULL,       -- Número de días que el empleado cumplió
    HorasExtras FLOAT NOT NULL        -- Total de horas extras trabajadas
);
