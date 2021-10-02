-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando banco de dados de Pessoas
CREATE DATABASE Pessoas

-- Indicando que o banco de dados Pessoa será usado
USE Pessoa;
GO

-- Criando tabela de Pessoa
CREATE TABLE Pessoa (
	idPessoa		INT PRIMARY KEY IDENTITY,
	nomePessoa		VARCHAR(250) NOT NULL
)
;Go

-- Criando tabela de CNH
CREATE TABLE CNH (
	idCNH			INT PRIMARY KEY IDENTITY,
	idPessoa		INT FOREIGN KEY REFERENCES CNH (idCNH),
	numeroCNH		CHAR (11) UNIQUE NOT NULL
);
GO

-- Criando tabela de Email
CREATE TABLE Email (
	idEmail			INT PRIMARY KEY IDENTITY,
	idPessoa		INT FOREIGN KEY REFERENCES Pessoa (idPessoa),
	email			VARCHAR (150) UNIQUE NOT NULL
);
GO

-- Criando tabela de Telefone 
CREATE TABLE Telefone (
	idTelefone 		INT PRIMARY KEY IDENTITY,
	idPessoa		INT FOREIGN KEY REFERENCES Telefone (idTelefone),
	telefone		CHAR (9) UNIQUE NOT NULL
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