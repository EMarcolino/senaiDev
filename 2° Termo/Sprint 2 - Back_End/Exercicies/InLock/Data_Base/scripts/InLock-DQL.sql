-- Indicando que o banco de dados Locadora será usado
USE InLock_Games;
GO

-- Listar todos os usuários.
SELECT *
FROM Usuario;

-- Listar todos os estúdios.
SELECT *
FROM Estudio;

-- Listar todos os jogos.
SELECT *
FROM Jogo;

-- Listar todos os jogos e seus respectivos estúdios.
SELECT *
FROM Jogo AS J
INNER JOIN Estudio AS E 
ON J.idEstudio = E.idEstudio;

-- Buscar e trazer na lista todos os estúdios com os respectivos jogos.
-- Obs.: Listar todos os estúdios mesmo que eles não contenham nenhum jogo de referência;
SELECT *
FROM Jogo AS J
RIGHT JOIN Estudio AS E 
ON J.idEstudio = E.idEstudio;

-- Buscar um usuário por e-mail e senha (login).
SELECT email, senha, Tipo_Usuario 
FROM Usuario 
LEFT JOIN Tipo_Usuario 
ON Usuario.idTipoUsuario = Tipo_Usuario.idTipoUsuario 
WHERE email = 'cliente@cliente.com' AND senha = 'cliente';

-- Buscar um jogo por idJogo.
SELECT *
FROM Jogo
WHERE idJogo = 1;

-- Buscar um estúdio por idEstudio.
SELECT *
FROM Estudio
WHERE idEstudio = 1;