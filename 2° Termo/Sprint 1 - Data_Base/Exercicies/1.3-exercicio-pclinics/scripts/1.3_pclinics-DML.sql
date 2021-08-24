

-- Indicando que o banco de dados Locadora será usado
USE Pclinics;
GO

--Inserindo informações na tabela Clinica
INSERT INTO Clinica (razaoSocial, endereco, CNPJ)
VALUES ('Pets', 'rua dos animais, 555, SP'), ('Mdos', 'rua brigadeiro joão, 2771, SP');
GO

--Inserindo informações na tabela Dono
INSERT INTO Dono (nome)
VALUES ('Sabrina'), ('Thiago'), ('Mary');
GO

--Inserindo informações na tabela TipoPet
INSERT INTO TipoPet (nome)
VALUES ('Cachorro'), ('Peixe'), ('Pássaro');
GO

--Inserindo informações na tabela RacaPet
INSERT INTO RacaPet (idTipoPet, nome)
VALUES (1'Buldogue'), (1'Pug'), (1'Boxer');
GO

--Inserindo informações na tabela Veterinario
INSERT INTO Veterinario (idClinica, nome, CRMV)
VALUES (1,'Tereza Cristina dos Anjos','53874'), (1,'Marcela de Amaral Dutra','37450'), (2,'Rodolfo Reisemberg Trindade','72997');
GO

--Inserindo informações na tabela Pet
INSERT INTO Pet (idDono, idTipoPet, nomePet, dataNascimento)
VALUES (1,2,'Lis'04/09/2020), (1,3,'Rex',09/07/2015);
GO

--Inserindo informações na tabela Atendimento
INSERT INTO Atendimento (idVeterinario, idPet, dataAtendimento, descricao)
VALUES (2,1,31/08/2021,'Lorem ipsum...'), (1,2/10/062/021'Lorem ipsum...'), (2,1,07/07/2021'Lorem ipsum...');
GO

/*
	PRIMARY KEY = Chave Primária
	FOREIGN KEY = Chave Estrangeira
	IDENTITY	= Define que o campo será auto-incrementado e único
	NOT NULL	= Define que não pode ser nulo, ou seja, obrigatório
	UNIQUE		= Define que o valor do campo é único, ou seja, não se repete
	DEFAULT		= Define um valor padrão, caso nenhum seja informado
	GO			= Pausa a leitura e executa o bloco de código acima
*/