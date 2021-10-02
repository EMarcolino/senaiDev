
USE Optus;
GO

SELECT * FROM Artista

SELECT * FROM Estilo

SELECT * FROM Album

SELECT * FROM EstiloAlbum

SELECT * FROM Usuario


-- Todos os usuários s, sem exibir suas senhas
SELECT nomeUsuario, email, permissao FROM Usuario
WHERE Usuario.permissao LIKE 'adm'

-- listar todos os álbuns lançados após o um determinado ano de lançamento
SELECT titulo AS Album, YEAR(dataLancamento) AS Lancamento, Localizacao, minutos AS Duração, Artistas.nomeArtista AS Artista 
FROM Album
INNER JOIN Artista
ON Album.idArtista = Artista.idArtista
WHERE Album.dataLancamento > '2010'

-- Dados de um usuário através do e-mail e senha
SELECT nomeUsuario, email, permissao FROM Usuario
WHERE email LIKE 'f.larissa@email.com' AND senha LIKE '1234567'

-- Albuns ativos, mostrando o nome do artista e os estilos do álbum 
SELECT titulo, dataLancamento, localizacao, minutos, Artistas.nomeArtista AS Artista, Estilo.nomeEstilo AS Estilo 
FROM Album AL
INNER JOIN Artista AR
ON AL.idArtista = AR.idArtista
INNER JOIN EstiloAlbum EA
ON AL.idAlbum = EA.idAlbum
INNER JOIN Estilo E
ON EA.idEstilo = E.idEstilo
