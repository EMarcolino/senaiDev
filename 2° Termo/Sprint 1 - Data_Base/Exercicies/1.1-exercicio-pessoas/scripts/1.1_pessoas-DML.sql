-- Indicando que o banco de dados Pessoa será usado
USE Pessoas;

--Inserindo informações na tabela Pessoa
INSERT INTO Pessoa (nomePessoa)
VALUES ('Rafael'), ('Evelyn');
GO

--Inserindo informações na tabela CNH
INSERT INTO CNH (numeroCNH)
VALUES ('12345678905'), ('12429876539');
GO

--Inserindo informações na tabela Email
INSERT INTO Email (email)
VALUES ('email@email.com'), ('algum@email.com');
GO

--Inserindo informações na tabela Telefone
INSERT INTO Telefone (telefone)
VALUES ('988887777'), ('966665555');
GO
