-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando banco de dados de Locadora
CREATE DATABASE Pclinics;

-- Indicando que o banco de dados Locadora será usado
USE Pclinics;
GO

-- Criando tabela Clinica
CREATE TABLE Clinica (
	idClinica			INT PRIMARY KEY IDENTITY,
	razaoSocial			VARCHAR(150) NOT NULL,
	endereco			VARCHAR(250) NOT NULL,
	CNPJ				CHAR(14) UNIQUE NOT NULL
);
GO

-- Criando tabela Dono
CREATE TABLE Dono (
	idDono				INT PRIMARY KEY IDENTITY,
	nome				VARCHAR (200) NOT NULL
);
GO

-- Criando tabela de Tipo de Pet
CREATE TABLE TipoPet (
	idTipoPet			INT PRIMARY KEY IDENTITY,
	nomeTipoPet			VARCHAR (200) NOT NULL
);
GO

-- Criando tabela de Raça do Pet
CREATE TABLE RacaPet (
	idRacaPet			INT PRIMARY KEY IDENTITY,
	idTipoPet			INT FOREIGN KEY REFERENCES TipoPet (idTipoPet),
	nomeRaca			VARCHAR (200) NOT NULL
);
GO

-- Criando tabela de Veterinario
CREATE TABLE Veterinario (
	idVeterinario		INT PRIMARY KEY IDENTITY,
	idClinica			INT FOREIGN KEY REFERENCES Clinica (idClinica),
	nome				VARCHAR (250) NOT NULL,
	CRMV				CHAR (5) UNIQUE NOT NULL
);
GO

-- Criando tabela de Pet
CREATE TABLE Pet (
	idPet			INT PRIMARY KEY IDENTITY,
	idDono			INT FOREIGN KEY REFERENCES Dono (idDono),
	idRacaPet		INT FOREIGN KEY REFERENCES RacaPet (idRacaPet),
	nomePet			VARCHAR (150) NOT NULL,
	dataNascimento	DATE NOT NULL
);
GO

-- Criando tabela de Atendimento
CREATE TABLE Atendimento (
	idAtendimento	INT PRIMARY KEY IDENTITY,
	idVeterinario	INT FOREIGN KEY REFERENCES Veterinario (idVeterinario),
	idPet			INT FOREIGN KEY REFERENCES Pet (idPet),
	dataAtendimento	DATE NOT NULL,
	descricao		VARCHAR (250) NOT NULL 
);
GO

/*
	PRIMARY KEY = Chave Primária
	FOREIGN KEY = Chave Estrangeira
	IDENTITY	= Define que o campo será auto-incrementado e único
	NOT NULL	= Define que não pode ser nulo, ou seja, obrigatório
	UNIQUE		= Define que o valor do campo é único, ou seja, não se repete
	DEFAULT		= Define um valor padrão, caso nenhum seja informado
	GO			= Pausa a leitura e executa o bloco de código acima
*/