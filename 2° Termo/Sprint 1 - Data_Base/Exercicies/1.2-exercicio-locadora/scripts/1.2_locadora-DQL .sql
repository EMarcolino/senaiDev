-- Indicando que o banco de dados Locadora será usado
USE Locadora;
GO

SELECT * FROM Empresa  

SELECT * FROM Marca

SELECT * FROM Modelo

SELECT * FROM Veiculo

SELECT * FROM Aluguel

SELECT * FROM Cliente


--Lista Todos os Alugueis mostrando a data de inicio e fim
--Mostra o Nome e Sobrenome do Cliente
--Mostra a Marca e o Modelo do Veículo Alugado
SELECT dataInicio, dataEntrega, Cliente.nomeCliente AS Nome, Cliente.sobrenomeCliente AS Sobrenome, Marca.nomeMarca AS Marca, Modelo.nomeModelo AS Modelo 
FROM Aluguel
INNER JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente 
INNER JOIN Veiculo
ON Aluguel.idVeiculo = Veiculo.idVeiculo 
INNER JOIN Modelo
ON Modelo.idModelo = Veiculo.idModelo 
INNER JOIN Marca
ON Marca.idMarca = Modelo.idMarca
GO


--Lista Todos os Alugueis de um Cliente
SELECT dataInicio, dataEntrega, Cliente.nomeCliente AS Nome, Cliente.sobrenomeCliente AS Sobrenome, Marca.nomeMarca AS Marca, Modelo.nomeModelo AS Modelo 
FROM Aluguel
INNER JOIN Cliente
ON Aluguel.idCliente = Cliente.idCliente 
INNER JOIN Veiculo
ON Aluguel.idVeiculo = Veiculo.idVeiculo 
INNER JOIN Modelo
ON Modelo.idModelo = Veiculo.idModelo 
INNER JOIN Marca
ON Marca.idMarca = Modelo.idMarca
WHERE Cliente.nomeCliente = 'Amanda';
GO