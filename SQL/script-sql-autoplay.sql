create schema autoplay;

use autoplay;

CREATE TABLE artista (
    id INT auto_increment PRIMARY KEY,
    nome VARCHAR(255),
    tipogeneromusical BIT(2),
    ativo BIT(1)
);

create table fornecedor(
id INT AUTO_INCREMENT PRIMARY KEY,
nome varchar(255),
cnpj varchar(14),
tipoFornecedor BIT(3),
ativo BIT(1)
);

create table produto(
id INT AUTO_INCREMENT PRIMARY KEY,
nome varchar(255),
descricao varchar(255),
ativo BIT(1),
dataCadastro datetime,
valor decimal(10,2),
idFornecedor int,
CONSTRAINT fk_produtos_fornecedores
    FOREIGN KEY (idFornecedor)
    REFERENCES FORNECEDORES (id)
);