-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando banco de dados de Hroads
CREATE DATABASE Hroads;

-- Indicando que o banco de dados Hroads será usado
USE Hroads;
GO

-- Criando tabela Tipo de TipoHabilidade
CREATE TABLE TipoHabilidade(
		idTipoHabilidade	INT PRIMARY KEY IDENTITY,
		nomeTipoHabilidate	VARCHAR(25) NOT NULL
);
GO

-- Criando tabela Tipo de Habilidade
CREATE TABLE Habilidade(
		idHabilidade		INT PRIMARY KEY IDENTITY,
		idTipoHabilidade	INT FOREIGN KEY REFERENCES TipoHabilidade (idTipoHabilidade),
		nomeHabilidade		VARCHAR(30) NOT NULL
);
GO

-- Criando tabela Tipo de Classe
CREATE TABLE Classe(
		idClasse			INT PRIMARY KEY IDENTITY,
		nomeClasse			VARCHAR(35) NOT NULL UNIQUE,
		vidaClasse			DECIMAL,
		manaClasse			DECIMAL
);
GO

-- Criando tabela Tipo de Classe_Habilidade
CREATE TABLE Classe_Habilidade(
		idClasseHabilidade	INT PRIMARY KEY IDENTITY,
		idClasse			INT FOREIGN KEY REFERENCES Classe (idClasse),
		idHabilidade		INT FOREIGN KEY REFERENCES Habilidade (idHabilidade)
);
GO

-- Criando tabela Tipo de Personagem
CREATE TABLE Personagem(
		idPersonagem		INT PRIMARY KEY IDENTITY,
		idClasse			INT FOREIGN KEY REFERENCES Classe (idClasse),
		nomePersonagem		VARCHAR(50),
		datAtualizacao		DATE,
		dataCriacao			DATE,
);
GO

-- Criando tabela Tipo de TipoUsuario
CREATE TABLE TipoUsuario(
		idTipoUsuario		INT PRIMARY KEY IDENTITY,
		nomeTipoUsuario		VARCHAR(25),
);
GO

-- Criando tabela de Usuario
CREATE TABLE Usuario(
		idUsuario			INT PRIMARY KEY IDENTITY,
		idTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
		email				VARCHAR(50),
		senha				VARCHAR(255),
);
GO