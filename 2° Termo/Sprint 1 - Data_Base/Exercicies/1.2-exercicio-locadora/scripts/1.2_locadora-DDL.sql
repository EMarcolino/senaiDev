-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando banco de dados de Locadora
CREATE DATABASE Locadora;

-- Indicando que o banco de dados Locadora será usado
USE Locadora;
GO

-- Criando tabela de Empresa
CREATE TABLE Empresa (
	idEmpresa			INT PRIMARY KEY IDENTITY,
	nomeEmpresa			VARCHAR (150) NOT NULL
);
GO

-- Criando tabela de Marca
CREATE TABLE Marca (
	idMarca				INT PRIMARY KEY IDENTITY,
	nomeMarca			VARCHAR (200) NOT NULL
);
GO

-- Criando tabela de Modelo
CREATE TABLE Modelo (
	idModelo			INT PRIMARY KEY IDENTITY,
	idMarca				INT FOREIGN KEY REFERENCES Marca (idMarca),
	nomeModelo			VARCHAR (200) NOT NULL
);
GO

-- Criando tabela de Veículo
CREATE TABLE Veiculo (
	idVeiculo			INT PRIMARY KEY IDENTITY,
	idEmpresa			INT FOREIGN KEY REFERENCES Empresa (idEmpresa),
	idModelo			INT FOREIGN KEY REFERENCES Modelo	(idModelo)
);
GO

-- Criando tabela de Cliente
CREATE TABLE Cliente (
	idCliente			INT PRIMARY KEY IDENTITY,
	nomeCliente			VARCHAR (200) NOT NULL, 
	sobrenomeCliente	VARCHAR (200) NOT NULL, 
	cpfCliente			CHAR (11) UNIQUE NOT NULL
);
GO

-- Criando tabela de Aluguel 
CREATE TABLE Aluguel (
	idAluguel			INT PRIMARY KEY IDENTITY,
	idCliente			INT FOREIGN KEY REFERENCES Cliente (idCliente),
	idVeiculo			INT FOREIGN KEY REFERENCES Veiculo (idVeiculo),
	dataInicio			DATETIME NOT NULL,
	dataEntrega			DATETIME NOT NULL
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

