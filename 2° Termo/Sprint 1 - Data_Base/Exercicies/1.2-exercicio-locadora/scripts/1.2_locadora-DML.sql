
-- Indicando que o banco de dados Locadora será usado
USE Locadora;
GO

--Inserindo informações na tabela Empresa
INSERT INTO Empresa (nomeEmpresa)
VALUES ('Localiza'), ('Unidas');
GO

--Inserindo informações na tabela Marca
INSERT INTO Marca (nomeMarca)
VALUES ('Ford'), ('Fiat');
GO

--Inserindo informações na tabela Modelo
INSERT INTO Modelo (nomeModelo)
VALUES (1,'Focus'), (2, 'Bravo');
GO

--Inserindo informações na tabela Cliente
INSERT INTO Cliente (nomeCliente, CPF)
VALUES ('José', 23498476297), ('Amanda', 8649026749);
GO

--Inserindo informações na tabela Aluguel
INSERT INTO Aluguel()
VALUES (1,1,'08/07/2021'), (2,2, '09/07/2021');
GO

--Inserindo informações na tabela Veículo
INSERT INTO Veículo (idEmpresa, idModelo)
VALUES (1, 2), (1, 1);
GO


