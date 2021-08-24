-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando banco de dados de catalogo de filmes
CREATE DATABASE Catalogo_Filmes;

-- Indicando que o banco de dados Filme será usado
USE Catalogo_Filmes;
GO

-- Criando tabela de Generos
CREATE TABLE Generos (
	idGeneros 		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);
GO

-- Criando tabela de Filmes 
CREATE TABLE Filmes (
	idFilme			INT PRIMARY KEY IDENTITY, 
	idGeneros		INT FOREIGN KEY REFERENCES Generos (idGeneros),
	Titulo			VARCHAR(200) NOT NULL
);
GO 

-- Criando Tabela de Usuários
CREATE TABLE Usuarios (
	idUsuario		INT PRIMARY KEY IDENTITY,
	Email			VARCHAR(250) NOT NULL UNIQUE, 
	Senha			VARCHAR(250) NOT NULL,
	Permissao		VARCHAR(250) NOT NULL
	
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
	DROP TABLE Nome_Tabela	= para excluir uma tabela  
*/

