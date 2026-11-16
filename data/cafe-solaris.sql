CREATE TABLE clientes (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    numero_telefone VARCHAR(20),
    email VARCHAR(100) UNIQUE,
    cpf VARCHAR(14) UNIQUE,
    cep VARCHAR(10),
    bairro VARCHAR(100),
    rua VARCHAR(150),
    numero VARCHAR(20),
    complemento_endereco VARCHAR(100),
    nome VARCHAR(100),
    senha VARCHAR(50)
);

CREATE TABLE entregadores (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    numero_telefone VARCHAR(20),
    cpf VARCHAR(14) UNIQUE,
    rg VARCHAR(20),
    cep VARCHAR(10),
    email VARCHAR(100) UNIQUE,
    nome VARCHAR(100)
);

CREATE TABLE itens_pedido (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    pedido_id INTEGER NOT NULL,
    produto_id INTEGER NOT NULL,
    qtd INTEGER NOT NULL,
    preco_unitario DECIMAL(10, 2) NOT NULL
);

CREATE INDEX idx_itens_pedido_pedido_id ON itens_pedido (pedido_id);
CREATE INDEX idx_itens_pedido_produto_id ON itens_pedido (produto_id);

CREATE TABLE pedidos (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    cliente_id INTEGER NOT NULL,
    entregador_id INTEGER,
    data_pedido TIMESTAMP,
    status VARCHAR(50),
    observacoes TEXT,
    forma_pagamento VARCHAR(50),
    taxa_entrega DECIMAL(10, 2)
);

CREATE INDEX idx_pedidos_cliente_id ON pedidos (cliente_id);
CREATE INDEX idx_pedidos_entregador_id ON pedidos (entregador_id);

CREATE TABLE produtos (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    preco DECIMAL(10, 2) NOT NULL,
    categoria VARCHAR(50) NOT NULL,
    descricao TEXT
);

CREATE TABLE usuarios (
    id INTEGER GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    usuario VARCHAR(100) NOT NULL UNIQUE,
    senha_hash CHAR(64) NOT NULL
);
