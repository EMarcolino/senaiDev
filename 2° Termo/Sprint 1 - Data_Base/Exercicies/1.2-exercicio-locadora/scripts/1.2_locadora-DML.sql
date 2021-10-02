
-- Indicando que o banco de dados Locadora será usado
USE Locadora;
GO

--Inserindo informações na tabela Empresa
INSERT INTO Empresa (nomeEmpresa)
VALUES ('Rental');
GO

--Inserindo informações na tabela Marca
INSERT INTO Marca (nomeMarca)
VALUES ('Ford'), ('Fiat');
GO

--Inserindo informações na tabela Modelo
INSERT INTO Modelo (idMarca, nomeModelo)
VALUES (1,'Focus'), (2, 'Bravo');
GO

--Inserindo informações na tabela Cliente
INSERT INTO Cliente (nomeCliente, sobrenomeCliente, cpfCliente)
VALUES ('José', 'Santos', 23498476297), ('Amanda', 'Duarte', 8649026749);
GO

--Inserindo informações na tabela Veículo
INSERT INTO Veiculo (idEmpresa, idModelo)
VALUES (1, 2), (1, 1);
GO

--Inserindo informações na tabela Aluguel
INSERT INTO Aluguel(idCliente, idVeiculo, dataInicio, dataEntrega)
VALUES (1,1,'08/07/2021', '10/07/2021'), (2,2, '15/08/2021', '20/08/2021');
GO
