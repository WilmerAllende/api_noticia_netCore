CREATE DATABASE Noticias
GO
USE Noticias
GO

Create Table Noticia(
	NoticiaID int primary key identity(1,1),
	Titulo varchar(120),
	Descripcion varchar(200),
	Contenido varchar(max),
	Fecha Datetime,
	AutorID int
)
GO
Create Table Autor(
	AutorID int primary key identity(1,1),
	Nombre Varchar(100),
	Apellido Varchar(100)
)

-- procedimiento almacenado

CREATE PROCEDURE pa_buscar_noticia
@titulo VARCHAR(200)

AS
	BEGIN
		SELECT NoticiaID,Titulo,Descripcion,Contenido FROM Noticia WHERE Titulo LIKE '%' + @titulo + '%'
	END


