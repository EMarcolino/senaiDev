-- Script de criação do Banco de Dados e suas Tabelas - DDL

-- Criando banco de dados de catalogo de filmes
CREATE DATABASE Catalogo_Filme

-- Indicando que o banco de dados Filme será usado
USE Catalogo_Filme;
GO

-- Criando tabela de Filme
CREATE TABLE Filme (
	idFilme			INT PRIMARY KEY IDENTITY,
	titulo			VARCHAR(200) NOT NULL
);
GO

-- Criando tabela de Gêneros 
CREATE TABLE Genero (
	idGenero		INT PRIMARY KEY IDENTITY, 
	idFilme			INT FOREIGN KEY REFERENCES Filme (idFilme),
	nome			VARCHAR(200) NOT NULL
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