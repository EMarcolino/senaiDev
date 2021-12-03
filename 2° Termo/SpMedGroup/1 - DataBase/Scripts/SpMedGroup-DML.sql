--Inserindo informações no banco de dados SpMedGroup
-- Definindo Banco de Dados que será usado
USE SpMedGroup;
GO

--Inserindo informações na tabela TipoUsuario
INSERT INTO TipoUsuario (nomeTipoUsuario)
VALUES ('Administrador'), ('Paciente'), ('Medico'), ('Funcionario');
GO

--Inserindo informações na tabela Endereco
INSERT INTO Endereco (logradouro, numero, bairro, cidade, estado, cep)
VALUES	('Alameda Barão de Limeira', '539', 'Santa Cecília', 'São Paulo', 'SP', ' 01202001'), ('Rua Capote Valente', '39', 'Pinheiros', 'São Paulo', 'SP', '05409000'),
		('Avenida Paulista', '1374', 'Paulista', 'São Paulo', 'SP', '01310100'), ('Alameda Vicente Pinzon', '54', 'Vila Olímpia', 'São Paulo', 'SP', '04547130');
GO

--Inserindo informações na tabela Usuario
INSERT INTO Usuario (idTipoUsuario, nomeUsuario, email, senha)
VALUES	('2', 'Andre', 'andre@email.com', 'andre123'), ('3', 'Fernando', 'fernando@email.com', 'fernando123'), ('2', 'Bruna', 'bruna@email.com', 'bruna123'),
		('1', 'Saulo', 'saulo@email.com', 'saulo123'), ('4', 'Lucas', 'lucas@email.com', 'lucas123'), ('1', 'Estevan', 'estevan@email.com', 'estevan123'),
		('3', 'Ricardo', 'ricardo@email.com', 'ricardo123'), ('3', 'Thais', 'thais@email.com', 'thais123');
GO

--Inserindo informações na tabela Clinica 
INSERT INTO Clinica (idEndereco, nomeClinica, cnpj)
VALUES ('1','SpMedicalGroup', '68617564000101');
GO

--Inserindo informações na tabela Medico
INSERT INTO Medico (idClinica, idUsuario, CRM)
VALUES ('1', '2', '1441803'), ('1', '7', '2071800'), ('1', '8', '1671800');
GO

--Inserindo informações na tabela Especialidade
--INSERT INTO Especialidade (idClinica, idMedico, nomeEspecialidade)
--VALUES ('1', '1', 'Pediatria'), ('1', '2', 'Psicologia'), ('1', '3', 'Cardiologia');
INSERT INTO Especialidade (nomeEspecialidade)
VALUES ('Pediatria'), ('Psicologia'), ('Cardiologia');
GO

--Inserindo informações na tabela Paciente
INSERT INTO Paciente (idUsuario, idEndereco, rg, cpf)
VALUES ('1', '1', '387485944', '26499854820'), ('3', '2', '450457743', '49099832550');
GO

--Inserindo informações na tabela Situacao
INSERT INTO Situacao (nomeSituacao)
VALUES ('Agendada'), ('Realizada'), ('Cancelada');
GO

--Inserindo informações na tabela Consulta***
INSERT INTO Consulta (idMedico, idPaciente, idSituacao, dataConsulta, descricaoProntuario)
VALUES	('1', '1', '1', '15/11/2021', 'Lorem ipsum... Lorem ipsum... Lorem ipsum...'), ('3', '2', '3', '05/12/2021', 'Lorem ipsum... Lorem ipsum... Lorem ipsum...'),
		('2', '2', '2', '15/10/2021', 'Lorem ipsum... Lorem ipsum... Lorem ipsum...'), ('2', '1', '1', '25/12/2021', 'Lorem ipsum... Lorem ipsum... Lorem ipsum...');
GO

