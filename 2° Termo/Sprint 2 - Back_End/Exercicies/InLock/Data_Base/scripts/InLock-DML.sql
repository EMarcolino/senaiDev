-- Indicando que o banco de dados Locadora será usado
USE InLock;
GO

USE InLock_Games;

--Inserindo informações na tabela Clinica
INSERT INTO Estudio(nomEstudio)
VALUES( 'Blizzard' ), ( 'Rockstar Studios' ), ( 'Square Enix' );

--Inserindo informações na tabela Jogos
INSERT INTO Jogo(idEstudio, nomeJogo, descricao, dataLancamento, valorJogo)
VALUES (1, 'Diablo 3', 'É um jogo que contém bastante ação e é viciante, seja você um novato ou fã.', '15/05/2012', 99.00), 
	   (2, 'Red Dead Redemption II', 'Jogo eletrônico de ação-aventura western', '26/10/2018', 120.00);

--Inserindo informações na tabela Tipo_Usuario
INSERT INTO Tipo_Usuario(nomeTipo)
VALUES( 'Administrador' ), ( 'Cliente' );

--Inserindo informações na tabela Usuario
INSERT INTO Usuario(idTipoUsuario, email, senha )
VALUES(1, 'admin@admin.com', 'admin'), 
	  (2, 'cliente@cliente.com', 'cliente');