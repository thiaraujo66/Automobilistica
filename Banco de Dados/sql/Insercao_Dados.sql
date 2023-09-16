BEGIN TRAN
GO
INSERT INTO Enderecos (EDLOGRADOURO, EDNUMERO, EDBAIRRO, EDCIDADE, EDUF, EDCEP, EDCOMPLEMENTO, EDTIPOENDERECO)
VALUES ('Rua das Flores', '10', 'Centro', 'Rio de Janeiro', 'RJ', '20010000', 'Sala 1', 2),
('Avenida Paulista', '100', 'Bela Vista', 'São Paulo', 'SP', '01310000', 'Loja 20', 2),
('Rua dos Bandeirantes', '500', 'Vila Mariana', 'São Paulo', 'SP', '04052030', 'Casa 3', 1),
('Rua da Consolação', '2000', 'Consolação', 'São Paulo', 'SP', '01301030', 'Apartamento 40', 1),
('Rua Carlos Gomes', '800', 'Centro', 'Campinas', 'SP', '13010121', 'Conjunto 15', 2),
('Rua Dom Pedro II', '150', 'Jardim Europa', 'São Paulo', 'SP', '01454010', 'Casa 2', 1),
('Rua XV de Novembro', '300', 'Centro', 'Curitiba', 'PR', '80020010', 'Sala 50', 2),
('Avenida Atlântica', '1000', 'Copacabana', 'Rio de Janeiro', 'RJ', '22010001', 'Apartamento 60', 1),
('Rua Amazonas', '200', 'Centro', 'Belo Horizonte', 'MG', '30130010', 'Loja 5', 2),
('Rua das Palmeiras', '50', 'Jardim das Flores', 'Osasco', 'SP', '06080030', 'Casa 4', 1);
GO

-- Inserindo 10 registros na tabela de Pessoas
INSERT INTO Pessoas (PSCDENDERECO, PSNOME, PSEMAIL, PSCGC, PSDTNASCIMENTO, PSDTCADASTRO)
VALUES
    (1, 'Ana Silva', 'ana.silva@gmail.com', '68928825016', '1990-15-02', '2022-10-01'),
    (2, 'Pedro Souza', 'pedro.souza@hotmail.com', '22234189020', '1995-21-05', '2022-05-02'),
    (3, 'Carla Santos', 'carla.santos@gmail.com', '90078721091', '1992-30-11', '2022-18-03'),
    (4, 'Lucas Oliveira', 'lucas.oliveira@yahoo.com', '87505213067', '1998-03-07', '2022-07-04'),
    (5, 'Maria Pereira', 'maria.pereira@gmail.com', '54260558072', '1985-10-12', '2022-02-05'),
    (6, 'Gustavo Lima', 'gustavo.lima@gmail.com', '40876865074', '1991-23-09', '2022-21-06'),
    (7, 'Juliana Almeida', 'juliana.almeida@yahoo.com', '30215621085', '1988-18-04', '2022-16-07'),
    (8, 'Rafaela Barbosa', 'rafaela.barbosa@hotmail.com', '95579455089', '1994-09-06', '2022-14-08'),
    (9, 'Fernando Costa', 'fernando.costa@gmail.com', '41581009097', '1986-27-08', '2022-28-09'),
    (10, 'Marcela Rodrigues', 'marcela.rodrigues@hotmail.com', '15242269049', '1993-05-03', '2022-22-10');
GO

INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (1, '2022-10-12', NULL, 1);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (2, '2022-15-11', NULL, 1);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (3, '2022-20-10', NULL, 0);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (4, '2022-25-09', NULL, 1);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (5, '2022-30-08', NULL, 0);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (6, '2022-05-07', NULL, 1);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (7, '2022-10-06', NULL, 0);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (8, '2022-15-05', NULL, 1);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (9, '2022-20-04', NULL, 0);
INSERT INTO Cliente (CLCDPESSOA, CLDTCADASTRO, CLDTALTERACAO, CLSTATUS) VALUES (10, '2022-25-03', NULL, 1);
GO

INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Mecânico de Caminhão', 'Responsável pela manutenção de caminhões', 4500.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Mecânico de Carro', 'Responsável pela manutenção de carros', 3500.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Gerente de Vendas', 'Responsável pela gestão da equipe de vendas', 8000.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Vendedor', 'Responsável por vender os produtos da empresa', 3000.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Motorista de Entrega', 'Responsável por fazer as entregas dos produtos', 3500.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Auxiliar de Produção', 'Responsável por auxiliar na produção dos produtos', 2500.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Engenheiro Mecânico', 'Responsável pela gestão e desenvolvimento dos projetos mecânicos', 10000.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Designer Automotivo', 'Responsável pelo design dos carros da empresa', 7000.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Analista de Sistemas', 'Responsável pela gestão e desenvolvimento dos sistemas da empresa', 9000.00);
INSERT INTO Cargo (CGNOME, CGDESCRICAO, CGMDSALARIAL) VALUES ('Analista Financeiro', 'Responsável pela gestão financeira da empresa', 8000.00);
GO

-- inserindo 20 registros na tabela Funcionarios

-- funcionario 1
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (2, 1, 3200.00, '2020-01-01', null, 1);

-- funcionario 2
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (3, 2, 4500.00, '2021-15-02', null, 1);

-- funcionario 3
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (4, 3, 2800.00, '2019-01-04', '2022-31-03', 0);

-- funcionario 4
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (5, 4, 3600.00, '2020-12-07', null, 1);

-- funcionario 5
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (6, 5, 4200.00, '2018-02-01', '2022-31-12', 0);

-- funcionario 6
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (7, 6, 3000.00, '2022-01-01', null, 1);

-- funcionario 7
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (8, 7, 4000.00, '2019-22-05', '2023-30-04', 0);

-- funcionario 8
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (9, 8, 2800.00, '2020-01-01', '2022-31-12', 0);

-- funcionario 9
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (10, 9, 4200.00, '2021-01-06', null, 1);

-- funcionario 10
INSERT INTO Funcionarios (FNCDPESSOA, FNCDCARGO, FNSALARIO, FNDTCONTRATACAO, FNDTDESLIGAMENTO, FNSTATUS)
VALUES (1, 10, 8200.00, '2021-01-05', null, 1);
GO

INSERT INTO Carros (CRMODELO, CRFABRICANTE, CRANO, CRPLACA, CRDTCADASTRO, CRINFADICIONAIS) VALUES
('Civic', 'Honda', '2020', 'ABC1234', '2022-01-02', 'Cor: Branco, Possui kit multimídia.'),
('Onix', 'Chevrolet', '2021', 'DEF5678', '2022-05-03', 'Cor: Vermelho, Único dono.'),
('Gol', 'Volkswagen', '2019', 'GHI9101', '2022-11-04', NULL),
('Corolla', 'Toyota', '2022', 'JKL2345', '2022-23-05', 'Cor: Prata, Possui câmera de ré.'),
('Hilux', 'Toyota', '2020', 'MNO6789', '2022-02-06', 'Cor: Azul, Possui tração 4x4.'),
('Ranger', 'Ford', '2021', 'PQR1234', '2022-09-07', NULL),
('HB20', 'Hyundai', '2021', 'STU5678', '2022-01-08', 'Cor: Preto, Possui bancos em couro.'),
('Toro', 'Fiat', '2022', 'VWX9101', '2022-07-09', 'Cor: Vermelho, Possui central multimídia.'),
('Renegade', 'Jeep', '2021', 'YZA2345', '2022-15-10', 'Cor: Branco, Possui teto solar.'),
('Compass', 'Jeep', '2022', 'BCB6789', '2022-02-11', 'Cor: Prata, Possui piloto automático.'),
('S10', 'Chevrolet', '2020', 'DEF1234', '2022-11-12', NULL),
('Amarok', 'Volkswagen', '2021', 'GHI5678', '2023-01-01', 'Cor: Azul, Possui tração 4x4.'),
('Tracker', 'Chevrolet', '2022', 'JKL9101', '2023-07-02', 'Cor: Preto, Possui sensor de estacionamento.'),
('Creta', 'Hyundai', '2021', 'MNO2345', '2023-15-03', NULL),
('Strada', 'Fiat', '2022', 'PQR6789', '2023-02-04', 'Cor: Branco, Possui protetor de caçamba.'),
('T-Cross', 'Volkswagen', '2020', 'STU1234', '2023-11-04', 'Cor: Vermelho, Possui rodas de liga leve.'),
('Cruze', 'Chevrolet', '2021', 'VWX5678', '2023-01-03', NULL),
('Kicks', 'Nissan', '2022', 'YZA9101', '2023-07-02', 'Cor: Cinza, Possui teto solar.'),
('City', 'Honda', '2021', 'BCB2345', '2023-15-04', 'Cor: Prata, Possui central multimídia.')
GO

INSERT INTO Servicos (SRNOME, SRDESCRICAO, SRVALOR, SRSTATUS, SRDTCADASTRO)
VALUES
('Troca de óleo', 'É efetuado a troca de óleo do motor do carro do cliente', 260.00, 1, '2022-10-02'),
('Balanceamento de rodas', 'Realização do balanceamento das rodas do carro', 80.00, 1, '2022-15-03'),
('Alinhamento de direção', 'Realização do alinhamento da direção do carro', 120.00, 1, '2022-20-04'),
('Revisão de suspensão', 'Revisão geral da suspensão do carro', 400.00, 1, '2022-10-05'),
('Troca de correia dentada', 'Troca da correia dentada do motor do carro', 700.00, 1, '2022-05-06'),
('Revisão de freios', 'Revisão geral do sistema de freios do carro', 280.00, 1, '2022-15-07'),
('Troca de pneus', 'Troca dos pneus do carro', 800.00, 1, '2022-10-08'),
('Higienização de ar condicionado', 'Limpeza e higienização do sistema de ar condicionado', 180.00, 1, '2022-05-09'),
('Polimento de pintura', 'Polimento e revitalização da pintura do carro', 450.00, 1, '2022-20-10'),
('Troca de filtro de ar', 'Troca do filtro de ar do motor do carro', 120.00, 1, '2022-15-11'),
('Revisão de motor', 'Revisão geral do motor do carro', 600.00, 1, '2022-10-12'),
('Reparo de motor de partida', 'Reparo ou substituição do motor de partida do carro', 500.00, 1, '2023-05-01'),
('Reparo de alternador', 'Reparo ou substituição do alternador do carro', 450.00, 1, '2023-20-02'),
('Revisão de sistema elétrico', 'Revisão geral do sistema elétrico do carro', 350.00, 1, '2023-10-03'),
('Troca de velas', 'Troca das velas do motor do carro', 150.00, 1, '2023-05-04');
GO

INSERT INTO CarroCliente (CCCDCARRO, CCCDCLIENTE, CCDTCADASTRO, CCSTATUS)
VALUES
(1, 2, '2022-01-02', 1),
(1, 1, '2022-06-03', 1),
(2, 3, '2022-05-03', 1),
(3, 4, '2022-11-04', 1),
(4, 5, '2022-23-05', 1),
(5, 6, '2022-02-06', 1),
(6, 7, '2022-09-07', 1),
(7, 8, '2022-01-08', 1),
(19, 9, '2023-15-04', 1),
(18, 10, '2023-07-02', 1),
(8, 1, '2022-07-09', 0)
GO

INSERT INTO Proposta (PPCDCARRO, PPCDCLIENTE, PPCDFUNCIONARIO, PPDTCADASTRO, PPSTATUS, PPVALOR)
VALUES
(18, 10, 1, '2023-07-02', 1, 200.00),
(19, 9, 2, '2023-15-04', 1, 800.00),
(1, 2, 4, '2022-06-03', 0, 950.00)
GO

INSERT INTO PropostaServico (PRCDPROPOSTA, PRCDSERVICO, PRVALOR)
VALUES
(1, 3, 120.00),
(1, 2, 80),
(2, 7, 800),
(3, 9, 450),
(3, 12, 500)
GO

INSERT INTO Processos (PCNOME, PCDESCRICAO, PCSTATUS, PCCDPROXPROCESSO)
VALUES
('FINALIZADO', 'Finaliza a esteira de processos', 1, null),
('CHECAGEM', 'Efetua a checagem do carra antes da finalização', 1, 1),
('EXECUÇÃO', 'Durante esse processo é executado todos os serviços solicitados', 1, 2),
('AVALIACAO', 'Durante esse processo é avaliado o passo a passo que deverá ser feito', 1, 3),
('APROVADO', 'Esse processo é o inicio da esteira, quando a proposta é aprovada', 1, 4)
GO

INSERT INTO Contrato (CTCDPROPOSTA, CTDTCADASTRO, CTDTINI, CTDTFINAL, CTTOTALHORAS, CTCDPROCESSO)
VALUES
(1, '2023-08-02', '2023-09-02', '2023-11-02', 12, 1),
(2, '2023-16-04', null, null, null, 5)
GO

COMMIT
--ROLLBACK