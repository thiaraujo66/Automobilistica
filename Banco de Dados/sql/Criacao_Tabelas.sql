CREATE TABLE Enderecos (
EDCDENDERECO int IDENTITY(1,1) PRIMARY KEY,
EDLOGRADOURO varchar(68) NOT NULL,
EDNUMERO varchar(50) NOT NULL,
EDBAIRRO varchar(50) NOT NULL,
EDCIDADE varchar(58) NOT NULL,
EDUF char(2) NOT NULL,
EDCEP varchar(8) NOT NULL,
EDCOMPLEMENTO varchar(50) NOT NULL,
EDTIPOENDERECO int NOT NULL
);
GO

CREATE TABLE Pessoas (
PSCDPESSOA int IDENTITY(1,1) PRIMARY KEY,
PSCDENDERECO int NOT NULL,
PSNOME varchar(255) NOT NULL,
PSEMAIL varchar(255) NOT NULL,
PSCGC varchar(15) NOT NULL,
PSDTNASCIMENTO smalldatetime NOT NULL,
PSDTCADASTRO smalldatetime NOT NULL,
CONSTRAINT FK_Pessoas_Enderecos
FOREIGN KEY (PSCDENDERECO)
REFERENCES Enderecos (EDCDENDERECO)
);
GO

CREATE TABLE Cargo (
CGCDCARGO int IDENTITY(1,1) PRIMARY KEY,
CGNOME varchar(50) NOT NULL,
CGDESCRICAO varchar(255) NOT NULL,
CGMDSALARIAL float NOT NULL
);
GO

CREATE TABLE Funcionarios (
FNCDFUNC int IDENTITY(1,1) PRIMARY KEY,
FNCDPESSOA int NOT NULL,
FNCDCARGO int NOT NULL,
FNSALARIO float NOT NULL,
FNDTCONTRATACAO smalldatetime NOT NULL,
FNDTDESLIGAMENTO smalldatetime,
FNSTATUS int DEFAULT(1)
CONSTRAINT FK_Funcionario_Pessoa
FOREIGN KEY (FNCDPESSOA)
REFERENCES Pessoas (PSCDPESSOA),
CONSTRAINT FK_Funcionario_Cargo
FOREIGN KEY (FNCDCARGO)
REFERENCES Cargo (CGCDCARGO),
);
GO

CREATE TABLE Carros (
CRCDCARRO int IDENTITY(1,1) PRIMARY KEY,
CRMODELO varchar(100) NOT NULL,
CRFABRICANTE varchar(100) NOT NULL,
CRANO int NOT NULL,
CRPLACA varchar(7) NOT NULL,
CRDTCADASTRO smalldatetime NOT NULL,
CRINFADICIONAIS varchar(255)
);
GO

CREATE TABLE Cliente (
CLCDCLIENTE int IDENTITY(1,1) PRIMARY KEY,
CLCDPESSOA int NOT NULL,
CLDTCADASTRO smalldatetime NOT NULL,
CLDTALTERACAO smalldatetime,
CLSTATUS bit DEFAULT(1),
CONSTRAINT FK_Cliente_Pessoas
FOREIGN KEY (CLCDPESSOA)
REFERENCES Pessoas (PSCDPESSOA)
);
GO
 
CREATE TABLE CarroCliente (
CCCDCARRO int NOT NULL,
CCCDCLIENTE int NOT NULL,
CCDTCADASTRO smalldatetime NOT NULL,
CCSTATUS bit DEFAULT(1),
CONSTRAINT FK_CarroCliente_Cliente
FOREIGN KEY (CCCDCLIENTE)
REFERENCES Cliente (CLCDCLIENTE),
CONSTRAINT FK_CarroCliente_Carro
FOREIGN KEY (CCCDCARRO)
REFERENCES Carros (CRCDCARRO),
PRIMARY KEY (CCCDCARRO, CCCDCLIENTE)
);
GO

CREATE TABLE Servicos (
SRCDSERVICO INT IDENTITY PRIMARY KEY,
SRNOME VARCHAR(255) NOT NULL,
SRDESCRICAO VARCHAR(255) NOT NULL,
SRVALOR float NOT NULL,
SRSTATUS BIT DEFAULT(1),
SRDTCADASTRO smalldatetime NOT NULL
);
GO

CREATE TABLE Proposta (
PPCDPROPOSTA int identity PRIMARY KEY,
PPCDCLIENTE int NOT NULL,
PPCDCARRO int NOT NULL,
PPCDFUNCIONARIO int NOT NULL,
PPVALOR float NOT NULL,
PPDTCADASTRO smalldatetime NOT NULL,
PPSTATUS int DEFAULT(1),
CONSTRAINT FK_Proposta_Cliente
FOREIGN KEY (PPCDCLIENTE)
REFERENCES Cliente (CLCDCLIENTE),
CONSTRAINT FK_Proposta_Carros
FOREIGN KEY (PPCDCARRO)
REFERENCES Carros (CRCDCARRO),
CONSTRAINT FK_Proposta_Funcionarios
FOREIGN KEY (PPCDFUNCIONARIO)
REFERENCES Funcionarios (FNCDFUNC)
);
GO

CREATE TABLE PropostaServico (
PRCDPROPOSTA INT NOT NULL,
PRCDSERVICO INT NOT NULL,
PRVALOR float NOT NULL,
CONSTRAINT FK_PropostaServico_Proposta
FOREIGN KEY (PRCDPROPOSTA)
REFERENCES Proposta (PPCDPROPOSTA),
CONSTRAINT FK_PropostaServico_Servico
FOREIGN KEY (PRCDSERVICO)
REFERENCES Servicos (SRCDSERVICO),
PRIMARY KEY (PRCDPROPOSTA, PRCDSERVICO)
);
GO

CREATE TABLE Processos (
PCCDPROCESSO INT IDENTITY PRIMARY KEY,
PCNOME VARCHAR(50) NOT NULL,
PCDESCRICAO VARCHAR(255) NOT NULL,
PCSTATUS BIT DEFAULT(1),
PCCDPROXPROCESSO INT,
CONSTRAINT FK_Auto_Relacionamento FOREIGN KEY (PCCDPROXPROCESSO)
REFERENCES Processos (PCCDPROCESSO)
)
GO

CREATE TABLE Contrato (
CTCDCONTRATO INT IDENTITY PRIMARY KEY,
CTCDPROPOSTA INT NOT NULL,
CTDTCADASTRO smalldatetime NOT NULL,
CTDTINI smalldatetime,
CTDTFINAL smalldatetime,
CTTOTALHORAS int DEFAULT(0),
CTCDPROCESSO INT NOT NULL,
CONSTRAINT FK_Proposta_Contrato FOREIGN KEY (CTCDPROPOSTA)
REFERENCES Proposta (PPCDPROPOSTA),
CONSTRAINT FK_Processo_Contrato FOREIGN KEY (CTCDPROCESSO)
REFERENCES Processos (PCCDPROCESSO)
);