select * from empleado
drop table empleado

CREATE TABLE empleado (
    idempleado INT IDENTITY PRIMARY KEY,
    nombre VARCHAR(50) not null,
    cdempleado varchar (20) not null,
    clave VARCHAR(8000) CONSTRAINT CK_Clave CHECK (LEN(clave) BETWEEN 8 AND 8000) not null
);




insert into empleado(nombre, cdempleado, clave) values ('Carlos Vera','gerente1','123456789')