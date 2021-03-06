-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando Banco de Dados
CREATE DATABASE SpMedGroup;
GO

-- Definindo Banco de Dados que será usado
USE SpMedGroup;
GO

-- Criando tabela com nome Clinica
CREATE TABLE Clinica (
	idClinica		INT PRIMARY KEY IDENTITY,
	nome			VARCHAR(200) UNIQUE NOT NULL,
	cnpj			CHAR(14) UNIQUE NOT NULL,
	razaoSocial		VARCHAR(200) UNIQUE NOT NULL,
	enderecoLogradouro	VARCHAR(200) NOT NULL,
	enderecoNumero		VARCHAR(200) NOT NULL,
	enderecoBairro		VARCHAR(200) NOT NULL,
	enderecoCidade		VARCHAR(200) NOT NULL,
	enderecoEstado		VARCHAR(200) NOT NULL,
	enderecoEstado		CHAR(8) NOT NULL
);
GO

-- Criando tabela de Tipo de Usuário
CREATE TABLE Tipo_Usuario (
	idTipoUsuario 		INT PRIMARY KEY IDENTITY,
	idClinica		INT FOREIGN KEY REFERENCES Clinica (idClinica),
	nomeTipo		VARCHAR(200) NOT NULL	
); 
GO

-- Criando tabela de Especialidade
CREATE TABLE Especialidade (
	idEspecialidade 	INT PRIMARY KEY IDENTITY,
	idClinica		INT FOREN KEY REFERENCES Clinica (idClinica),
	nomeEspecialidade	VARCHAR(200) NOT NULL	
); 
GO

-- Criando tabela de Usuário
CREATE TABLE Usuario (
	idUsuario		INT PRIMARY KEY IDENTITY,	
	idTipoUsuario		INT FOREN KEY REFERENCES Tipo_Usuario (idTipoUsuario),
	nomeUsuario		VARCHAR(200) NOT NULL,
	email			VARCHAR(100) UNIQUE NOT NULL,
	senha			VARCHAR(18) NOT NULL
);
GO

-- Criando tabela Administrativo
CREATE TABLE Administrativo (
	idAdministrativo	PRIMARY KEY IDENTITY,
	idUsuario		FOREN KEY REFERENCES Usuario (idUsuario),
	descricao		VARCHAR(100)
);
GO

-- Criando tabela de Médico
CREATE TABLE Medico (
	idMedico		INT PRIMARY KEY IDENTITY,
	idUsuario		INT FOREN KEY REFERENCES Usuario (idUsuario),
	idEspecialidade		INT FOREN KEY REFERENCES Especialidade (idEspecialidade),
	CRM			CHAR(7) UNIQUE NOT NULL
);
GO

-- Criando tabela de Paciente
CREATE TABLE PACIENTE (
	idPaciente		INT PRIMARY KEY IDENTITY,
	idUsuario		INT FOREN KEY REFERENCES Usuario (idUsuario),
	RG			CHAR(9) UNIQUE NOT NULL,
	CPF			CHAR(11) UNIQUE NOT NULL,
	enderecoLogradouro	VARCHAR(200) NOT NULL,
	enderecoNumero		VARCHAR(200) NOT NULL,
	enderecoBairro		VARCHAR(200) NOT NULL,
	enderecoCidade		VARCHAR(200) NOT NULL,
	enderecoEstado		VARCHAR(200) NOT NULL,
	enderecoCEP		CHAR(8) NOT NULL
);
GO

-- Criando tabela Consulta
CREATE TABLE Consulta (
	idConsulta		INT PRIMARY KEY IDENTITY,
	idMedico		INT FOREN KEY REFERENCES Medico (idMedico),
	idPaciente		INT FOREN KEY REFERENCES Paciente (idPaciente),
	dataConsulta		DATE NOT NULL,
	situação		VARCHAR(15) NOT NULL,
	descricaoProntuario	VARCHAR(255)
);
GO


