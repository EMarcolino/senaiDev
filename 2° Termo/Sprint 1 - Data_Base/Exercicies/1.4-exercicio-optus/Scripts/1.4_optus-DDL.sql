-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando Banco de Dados
CREATE DATABASE Optus;
GO

-- Definindo Banco de Dados que será usado
USE Optus;
GO

-- Criando tabela Artista
CREATE TABLE Artista (
	idArtista		INT PRIMARY KEY IDENTITY,
	nomeArtista		VARCHAR (250) NOT NULL
);
GO

-- Criando tabela de Estilo
CREATE TABLE Estilo (
	idEstilo 		INT PRIMARY KEY IDENTITY,
	nomeEstilo		VARCHAR(200) NOT NULL	
); 
GO

-- Criando tabela de Album
CREATE TABLE Album (
	idAlbum		 	INT PRIMARY KEY IDENTITY,
	idArtista		INT FOREN KEY REFERENCES Artista (idArtista),
	titulo			VARCHAR(200) NOT NULL,	
	dataLancamento	DATE,
	minutos			INT,
	vizualizacao	INT,
	localizacao		VARCHAR(200) NOT NULL
); 
GO

-- Criando tabela de Usuario
CREATE TABLE Usuario (
	idUsuario		INT PRIMARY KEY IDENTITY,	
	nomeUsuario		VARCHAR(200) NOT NULL,
	email			VARCHAR(100) UNIQUE NOT NULL,
	senha			VARCHAR(18) NOT NULL,
	permissao		CHAR(14) NOT NULL
);
GO
-- Criando tabela de EstiloAlbum
CREATE TABLE EstiloAlbum (
	idEstiloAlbum	INT PRIMARY KEY IDENTITY,	
	idEstilo		INT FOREN KEY REFERENCES Estilo (idEstilo),
	idAlbum			INT FOREN KEY REFERENCES Album (idAlbum)
);
GO


