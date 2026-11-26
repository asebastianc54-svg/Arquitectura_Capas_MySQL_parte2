CREATE DATABASE IF NOT EXISTS rrhh_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE rrhh_db;

CREATE TABLE IF NOT EXISTS empleado (
    Dni VARCHAR(20) NOT NULL PRIMARY KEY,
    Id INT NOT NULL,
    Nombre VARCHAR(120) NOT NULL,
    Puesto VARCHAR(100) NOT NULL,
    Departamento VARCHAR(100) NOT NULL
);

INSERT INTO empleado (Dni, Id, Nombre, Puesto, Departamento) VALUES
('28111222', 501, 'Diego Ibáñez', 'Desarrollador Backend', 'Sistemas'),
('29222333', 502, 'Carolina Muñoz', 'Analista de Selección', 'Recursos Humanos'),
('30333444', 503, 'Hernán Castañeda', 'Administrador de Redes', 'Infraestructura')
ON DUPLICATE KEY UPDATE
    Id = VALUES(Id),
    Nombre = VALUES(Nombre),
    Puesto = VALUES(Puesto),
    Departamento = VALUES(Departamento);
