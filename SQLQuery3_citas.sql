CREATE TABLE citas (
    IdCita INT PRIMARY KEY IDENTITY,
    Fecha DATE NOT NULL,
    Hora VARCHAR(10) NOT NULL,
    Nombre NVARCHAR(50) NOT NULL,
    Apellido NVARCHAR(50) NOT NULL,
    Ocupado BIT NOT NULL DEFAULT 0
);