-- Ajustes no banco cafe_solaris, necessários para o importador de JSON.
-- Rode uma vez no MySQL (phpMyAdmin > SQL, ou linha de comando).

-- 1) O hash PBKDF2 gerado no Cliente.cs tem ~90 caracteres; a coluna tinha varchar(50).
ALTER TABLE clientes MODIFY senha VARCHAR(120);

-- 2) As tabelas estão em MyISAM, que não suporta transação (rollback).
--    InnoDB permite desfazer a importação inteira se algo falhar no meio.
ALTER TABLE clientes      ENGINE = InnoDB;
ALTER TABLE entregadores  ENGINE = InnoDB;
ALTER TABLE produtos      ENGINE = InnoDB;
ALTER TABLE pedidos       ENGINE = InnoDB;
ALTER TABLE itens_pedido  ENGINE = InnoDB;
