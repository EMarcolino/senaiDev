-- Indicando que o banco de dados Hroads será usado
USE Hroads;
GO

--Inserindo informações na tabela TipoHabilidade
INSERT INTO TipoHabilidade (nomeTipoHabilidate)
VALUES ('Ataque'), ('Defesa'),
		('Cura'), ('Magia');
GO

--Inserindo informações na tabela Habilidade
INSERT INTO Habilidade (idTipoHabilidade, nomeHabilidade)
VALUES (1, 'Lança Mortal'), (2, 'Escudo Supremo'), (3, 'Recuperar Vida');
GO

--Inserindo informações na tabela Classe
INSERT INTO Classe (nomeClasse, vidaClasse, manaClasse)
VALUES ('Bárbaro', 100, 80);
GO

INSERT INTO Classe (nomeClasse, vidaClasse, manaClasse)
VALUES('Cruzado', 0, 0), ('Caçadora de Demônios', 0, 0), ('Monge', 70, 100), ('Necromante', 0, 0), ('Feiticeiro', 0, 0), ('Arcantista', 75, 60);
GO

--Inserindo informações na tabela Classe_Habilidade
INSERT INTO Classe_Habilidade (idClasse, idHabilidade)
VALUES (1, 2), (2, 2), (3, 1), (4, 3), (4, 2), (6, 3);
GO

--Inserindo informações na tabela Personagem
INSERT INTO Personagem (idClasse, nomePersonagem, datAtualizacao, dataCriacao)
VALUES (1, 'DeuBug', '07/07/2021', '03/03/2020'), (4,'BitBug', '07/07/2021', '03/03/2020');-- 

INSERT INTO Personagem (idClasse, nomePersonagem, datAtualizacao, dataCriacao)
VALUES (7,'Fer8', '07/07/2021', '03/03/2020');
GO

--Inserindo informações na tabela TipoUsuario
INSERT INTO TipoUsuario (nomeTipoUsuario)
VALUES ('Administrador'), ('Jogador');
GO

--Inserindo informações na tabela TipoUsuario
INSERT INTO Usuario (idTipoUsuario, email, senha)
VALUES (1, 'joana@email.com', 1234567), (2, 'agatha@email.com', 1234567), (2, 'pedro@email.com', 1234567);
GO