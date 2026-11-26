CREATE DATABASE IF NOT EXISTS academia_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE academia_db;

CREATE TABLE IF NOT EXISTS alumno (
    Dni VARCHAR(20) NOT NULL PRIMARY KEY,
    Legajo INT NOT NULL,
    Nombre VARCHAR(120) NOT NULL,
    Condicion VARCHAR(50) NOT NULL
);

INSERT INTO alumno (Dni, Legajo, Nombre, Condicion) VALUES
('40111222', 10042, 'Sebastián Canazas', 'Aprobado'),
('40222333', 10043, 'Martín Peña', 'Regular'),
('40333444', 10044, 'Lucía Núñez', 'Promocionado')
ON DUPLICATE KEY UPDATE
    Legajo = VALUES(Legajo),
    Nombre = VALUES(Nombre),
    Condicion = VALUES(Condicion);
