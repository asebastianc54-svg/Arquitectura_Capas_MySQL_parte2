CREATE DATABASE IF NOT EXISTS biblioteca_db CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE biblioteca_db;

CREATE TABLE IF NOT EXISTS libro (
    Dni VARCHAR(20) NOT NULL PRIMARY KEY,
    Isbn VARCHAR(30) NOT NULL,
    Titulo VARCHAR(150) NOT NULL,
    Autor VARCHAR(120) NOT NULL,
    Disponible TINYINT(1) NOT NULL
);

INSERT INTO libro (Dni, Isbn, Titulo, Autor, Disponible) VALUES
('20111222', '978-84-376-0494-7', 'Cien años de soledad', 'Gabriel García Márquez', 1),
('20222333', '978-950-07-0010-8', 'El Aleph', 'Jorge Luis Borges', 0),
('20333444', '978-84-204-7183-9', 'Don Quijote de la Mancha', 'Miguel de Cervantes', 1)
ON DUPLICATE KEY UPDATE
    Isbn = VALUES(Isbn),
    Titulo = VALUES(Titulo),
    Autor = VALUES(Autor),
    Disponible = VALUES(Disponible);
