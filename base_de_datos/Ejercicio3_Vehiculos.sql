CREATE DATABASE IF NOT EXISTS estacionamiento_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE estacionamiento_db;

CREATE TABLE IF NOT EXISTS vehiculo (
    Dni VARCHAR(20) NOT NULL PRIMARY KEY,
    Patente VARCHAR(20) NOT NULL,
    Modelo VARCHAR(120) NOT NULL,
    TieneDeuda TINYINT(1) NOT NULL
);

INSERT INTO vehiculo (Dni, Patente, Modelo, TieneDeuda) VALUES
('31111222', 'AA123CD', 'Volkswagen Gol Trend', 0),
('32222333', 'AE456FG', 'Toyota Corolla', 1),
('33333444', 'AB789HI', 'Ford Fiesta Kinetic', 0)
ON DUPLICATE KEY UPDATE
    Patente = VALUES(Patente),
    Modelo = VALUES(Modelo),
    TieneDeuda = VALUES(TieneDeuda);
