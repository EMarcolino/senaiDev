USE Catalogo_Filmes;

--			Tabela	 Coluna
INSERT INTO Generos (Nome)
VALUES				('Ação'),
					('Ficção Cientifica'),
					('Suspense'),
					('Romance');
GO

INSERT INTO Generos (Nome)
VALUES				('Fantasia'),
					('Aventura');
GO
----------------------------------------------------

INSERT INTO Filmes	(Titulo, idGeneros)
VALUES				('John Wick', 1),
					('Vingadores - Ultimato', 5),
					('Nasce Uma Estrela', 4),
					('Star Wars', 5);
GO

INSERT INTO Filmes	(Titulo, idGeneros)
VALUES				('Assalto ao Banco da Espanha', 5),
					('Jumanji', 6);
GO
---------------------------------------------------

INSERT INTO Usuarios(Email, Senha, Permissao)
VALUES				('julia@email.com', '123', 'comum'),
					('teste@email.com', '123', 'comum'),
					('adm@adm.com', '123', 'administrador');
GO

--UPDATE Generos
--SET Nome = 'Romance'
--WHERE idGenero = 2;

--DELETE FROM Generos
--WHERE idGenero = 3;