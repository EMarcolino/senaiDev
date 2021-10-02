
USE Optus;
GO

INSERT INTO Artista(nomeArtista)
VALUES	("Los Polos"),("Caiçara"),
		("The Beatles"),("whindersson Nunes");
GO

INSERT INTO Estilo(nomeEstilo)
VALUES	("Mariachi"),("Reg"),
		("Rock"),("Pop");
GO

INSERT INTO Album(idArtista, titulo, dataLancamento, minutos, vizualizacao, localizacao)
VALUES	(1, "La Macia", 10/09/1987, 82, 10000, "México" ), (2, "Na Onda", 10/09/1970, 82, 110000, "Brasil" ),
		(3, "Abbey Road", 10/09/1969, 48, 900000, "Inglaterra" ), (4, "Piauí", 09/10/2020, 73, 10000, "Brasil" );
GO

INSERT INTO EstiloAlbum(idEstilo, idAlbum)
VALUES	(1, 1),(2, 2),
		(3, 3),(4, 4);
GO

INSERT INTO Usuario(nomeUsuario, email, senha)
VALUES	("Teresinha Afonso", "teresinha@email.com", 1234567, adm), ("João Carlos", "joaocarlos@email.com", 1234567, comum),
		("Claudinete Camargo", "claud@email.com", 1234567, comum), ("Larissa Ferreira", "f.larissa@email.com", 1234567, comum);
GO