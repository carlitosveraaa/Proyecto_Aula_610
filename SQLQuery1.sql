select * from empleado

drop table usuario

CREATE TABLE empleado (
    idempleado INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) not null,
    cdempleado varchar (20) not null,
	correo varchar (50),
    clave VARCHAR(8000) CONSTRAINT CK_Clave CHECK (LEN(clave) BETWEEN 8 AND 8000) not null,	
	restablecer bit,
	confirmado bit,
	token varchar (200)
);