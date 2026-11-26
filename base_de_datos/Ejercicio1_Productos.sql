CREATE DATABASE IF NOT EXISTS comercio_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE comercio_db;

CREATE TABLE IF NOT EXISTS producto (
    Dni VARCHAR(20) NOT NULL PRIMARY KEY,
    Codigo VARCHAR(30) NOT NULL,
    Nombre VARCHAR(120) NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL
);

INSERT INTO producto (Dni, Codigo, Nombre, Precio) VALUES
('12345678', 'PROD-101', 'Teclado Mecánico Español', 45500.00),
('23456789', 'PROD-102', 'Mouse Inalámbrico', 22000.00),
('34567890', 'PROD-103', 'Monitor 27 Pulgadas', 280000.00)
ON DUPLICATE KEY UPDATE
    Codigo = VALUES(Codigo),
    Nombre = VALUES(Nombre),
    Precio = VALUES(Precio);
