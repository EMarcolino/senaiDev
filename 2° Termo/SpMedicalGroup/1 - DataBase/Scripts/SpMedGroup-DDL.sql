-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando Banco de Dados
CREATE DATABASE SpMedGroup;
GO

-- Definindo Banco de Dados que será usado
USE SpMedGroup;
GO

--Criando tabela Tipo Usuario
CREATE TABLE TipoUsuario (
	idTipoUsuario			INT PRIMARY KEY IDENTITY,
	nomeTipoUsuario			VARCHAR(200) NOT NULL	
);
GO

--Criando tabela Endereco
CREATE TABLE Endereco (
	idEndereco				INT PRIMARY KEY IDENTITY,
	logradouro				VARCHAR(200) NOT NULL,
	numero					VARCHAR(200) NOT NULL,
	bairro					VARCHAR(200) NOT NULL,
	cidade					VARCHAR(200) NOT NULL,
	estado					VARCHAR(200) NOT NULL,
	cep						CHAR(15) NOT NULL
);
GO

-- Criando tabela de Usuário
CREATE TABLE Usuario (
	idUsuario				INT PRIMARY KEY IDENTITY,	
	idTipoUsuario			INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
	nomeUsuario				VARCHAR(200) NOT NULL,
	email					VARCHAR(100) UNIQUE NOT NULL,
	senha					VARCHAR(18) NOT NULL
);
GO

-- Criando tabela Clinica
CREATE TABLE Clinica (
	idClinica				INT PRIMARY KEY IDENTITY,
	idEndereco				INT FOREIGN KEY REFERENCES Endereco (idEndereco),
	nomeClinica				VARCHAR(200) UNIQUE NOT NULL,
	cnpj					CHAR(14) UNIQUE NOT NULL
);
GO

--Criando tabela Especialidade
CREATE TABLE Especialidade (
	idEspecialidade			INT PRIMARY KEY IDENTITY,
	nomeEspecialidade		VARCHAR(200) NOT NULL
);
GO

-- Criando tabela de Médico
CREATE TABLE Medico (
	idMedico				INT PRIMARY KEY IDENTITY,
	idClinica				INT FOREIGN KEY REFERENCES Clinica (idClinica),
	idUsuario				INT FOREIGN KEY REFERENCES Usuario (idUsuario),
	idEspecialidade			INT FOREIGN KEY REFERENCES Especialidade (idEspecialidade),
	CRM						CHAR(7) UNIQUE NOT NULL
);
GO

-- Criando tabela de Paciente
CREATE TABLE Paciente (
	idPaciente				INT PRIMARY KEY IDENTITY,
	idUsuario				INT FOREIGN KEY REFERENCES Usuario (idUsuario),
	idEndereco				INT FOREIGN KEY REFERENCES Endereco (idEndereco),
	rg						CHAR(9) UNIQUE NOT NULL,
	cpf						CHAR(11) UNIQUE NOT NULL
);
GO

--Criando tabela de Situação de consulta
CREATE TABLE Situacao (
	idSituacao				INT PRIMARY KEY IDENTITY,
	nomeSituacao			VARCHAR(15) NOT NULL
);
GO

-- Criando tabela Consulta
CREATE TABLE Consulta (
	idConsulta				INT PRIMARY KEY IDENTITY,
	idMedico				INT FOREIGN KEY REFERENCES Medico (idMedico),
	idPaciente				INT FOREIGN KEY REFERENCES Paciente (idPaciente),
	idSituacao				INT FOREIGN KEY REFERENCES Situacao (idSituacao),
	dataConsulta			DATE NOT NULL,
	descricaoProntuario		VARCHAR(255)
);
GO

