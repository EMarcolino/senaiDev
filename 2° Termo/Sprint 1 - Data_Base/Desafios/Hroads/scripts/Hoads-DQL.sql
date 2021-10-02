-- Indicando que o banco de dados Locadora será usado
USE Hroads;
GO
--Seleciona toda tabela de TipoHabilidade
SELECT * FROM TipoHabilidade;

--Seleciona toda tabela de Habilidade
SELECT * FROM Habilidade;

--Seleciona toda tabela de Classe
SELECT * FROM Classe;

--Seleciona toda tabela de Classe_Habilidade
SELECT * FROM Classe_Habilidade;

--Seleciona toda tabela de Personagem
SELECT * FROM Personagem;

--Seleciona toda tabela de TipoUsuario
SELECT * FROM TipoUsuario;

--Seleciona toda tabela de Usuario
SELECT * FROM Usuario;

--Atualiza o nome do personagem Fer8 para Fer7
UPDATE Personagem
SET nomePersonagem = 'Fer7'
WHERE Personagem.idPersonagem = 3;

--Atualiza o nome do personagem Necromante para Necromancer
UPDATE Classe
SET nomeClasse = 'Necromancer'
WHERE Classe.idClasse = 7;

--Seleciona somente o nome das classes.
SELECT Classe.nomeClasse AS [Classe]
FROM Classe;

--Realizar contagem de quantas habilidades estão cadastradas.
SELECT COUNT(Habilidade.idHabilidade) AS [Qtd. de Habilidades]
FROM Habilidade;

--Selecionar somente os id's das habilidades classificando-os por ordem crescente.
SELECT * FROM Habilidade
ORDER BY Habilidade.idHabilidade ASC;

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte.
SELECT Habilidade.idHabilidade, Habilidade.nomeHabilidade AS [Habilidade], TipoHabilidade.nomeTipoHabilidate AS [Tipo de Habilidade]
FROM Habilidade
INNER JOIN TipoHabilidade
ON Habilidade.idTipoHabilidade = TipoHabilidade.idTipoHabilidade;

-- Selecionar todos os personagem e suas respectivas classes.
SELECT P.idPersonagem, P.nomePersonagem AS [Personagem], C.nomeClasse AS [Classe], C.vidaClasse AS [Vida], C.manaClasse AS [Mana], P.datAtualizacao AS [Data Atualização], P.dataCriacao AS [Data Criação]
FROM Personagem AS P
INNER JOIN Classe AS C
ON P.idClasse = C.idClasse;

-- Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência).
SELECT P.idPersonagem, P.nomePersonagem AS [Personagem], C.nomeClasse AS [Classe], C.vidaClasse AS [Vida], C.manaClasse AS [Mana], P.dtAtualizacao AS [Data Atualização], P.dataCriacao AS [Data Criação]
FROM Personagem AS P
LEFT JOIN Classe AS C
ON P.idClasse = C.idClasse;

-- Selecionar todas as habilidades e suas classes (somente as que possuem correspondência).
SELECT C.nomeClasse AS [Classe], H.nomeHabilidade AS [Habilidade]
FROM Classe_Habilidade AS CH
INNER JOIN Classe AS C
ON CH.idClasse = C.idClasse
INNER JOIN Habilidade AS H
ON CH.idHabilidade = H.idHabilidade;

-- Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).
SELECT C.nomeClasse AS [Classe], H.nomeHabilidade AS [Habilidade]
FROM Classe_Habilidade AS CH
RIGHT JOIN Classe AS C
ON CH.idClasse = C.idClasse
LEFT JOIN Habilidade AS H
ON CH.idHabilidade = H.idHabilidade;




