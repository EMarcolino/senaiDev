

-- Indicando que o banco de dados Locadora será usado
USE Pclinics;
GO

SELECT * FROM Clinica;

SELECT * FROM Dono;

SELECT * FROM TipoPet;

SELECT * FROM RacaPet;

SELECT * FROM Veterinario;

SELECT * FROM Pet;

SELECT * FROM Atendimento;

--Lista as informaçoes do veterinario e a clinica que ele trabalha
SELECT nome, CRMV, razaoSocial FROM Veterinario
INNER JOIN Clinica
ON Clinica.idClinica = Veterinario.idClinica
WHERE Clinica.idClinica = 1;

-- Lista as raças que começam com a letra S
SELECT * FROM RacaPet
WHERE nomeRaca LIKE 'S%';

-- Lista os tipos de pet que terminam com a letra O
SELECT * FROM TipoPet
WHERE nomeTipoPet LIKE '%o';

-- Lista os pets mostrando os nomes dos seus donos
-- AS (apelido) 
SELECT idPet, nomePet Pet, dataNascimento AS 'Data Nascimento', Dono.nome AS Dono FROM Pet
INNER JOIN Dono
ON Pet.idDono = Dono.idDono;

-- listar todos os atendimentos mostrando o nome do veterinário que atendeu, 
-- o nome, a raça e o tipo do pet que foi atendido,
-- o nome do dono do pet e o nome da clínica onde o pet foi atendido
SELECT idAtendimento, Veterinario.nome [Veterinário], Pet.nome Pet,
Raca.descricao [Raça], TipoPet.descricao [Espécie], Dono.nome Dono, razaoSocial [Razão Social]
FROM Atendimento AS A
LEFT JOIN veterinario V
ON Atendimento.idVeterinario = V.idVeterinario
INNER JOIN Pet P
ON A.idPet = P.idPet
INNER JOIN RacaPet R
ON P.idRaca = R.idRaca
INNER JOIN TipoPet TP
ON TP.idTipoPet = R.idTipoPet
INNER JOIN Dono D
ON P.idDono = D.idDono
INNER JOIN Clinica C
ON C.idClinica = V.idClinica;