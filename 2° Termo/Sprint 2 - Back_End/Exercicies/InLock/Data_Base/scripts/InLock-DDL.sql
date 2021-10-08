-- Script de criação do Banco de Dados e suas Tabelas - DDL
-- Criando banco de dados de InLock_Games
CREATE DATABASE InLock_Games;
GO

USE InLock_Games;

CREATE TABLE Estudio(
	idEstudio			INT PRIMARY KEY IDENTITY,
	nomEstudio			VARCHAR(50),
);
GO

CREATE TABLE Jogo(
	idJogo				INT PRIMARY KEY IDENTITY,
	idEstudio			INT FOREIGN KEY REFERENCES Estudios (idEstudio),
	nomeJogo			VARCHAR(50),
	descricao			VARCHAR(150),
	dataLancamento		DATE,
	valorJogo			DECIMAL(5, 2)
);
GO

CREATE TABLE Tipo_Usuario(
	idTipoUsuario	INT PRIMARY KEY IDENTITY,
	nomeTipo		VARCHAR(50),
);
GO

CREATE TABLE Usuario(
	idUsuario		INT PRIMARY KEY IDENTITY,
	idTipoUsuario	INT FOREIGN KEY REFERENCES Tipo_Usuario (idTipoUsuario),
	email			VARCHAR(50),
	senha			VARCHAR(255),	
);
GO