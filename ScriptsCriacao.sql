--criar banco
CREATE DATABASE programacao_do_zero;

--usar banco 
USE programacao_do_zero;

--criar tabela usuário
CREATE TABLE usuario (
   id INT NOT NULL AUTO_INCREMENT,
   nome VARCHAR(50) NOT NULL,
   sobrenome VARCHAR(150) NOT NULL,
   telefone VARCHAR(15) NOT NULL,
   email VARCHAR(50) NOT NULL,
   genero VARCHAR(20) NOT NULL,
   senha VARCHAR(30) NOT NULL,
   PRIMARY KEY (id)
);

-- criar tabela endereco
CREATE TABLE endereco (
   id INT NOT NULL auto_increment,
   rua VARCHAR(250) NOT NULL,
   numero VARCHAR(30) NOT NULL,
   bairro VARCHAR(150) NOT NULL,
   cidade VARCHAR(250) NOT NULL,
   complemento VARCHAR(150) NULL,
   cep VARCHAR(9) NOT NULL,
   estado VARCHAR(2) NOT NULL,
   PRIMARY KEY (id)
);

--alterar tabela endereco
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

--adicionar chave estrangerira
ALTER TABLE endereco 
ADD CONSTRAINT FK_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--inserir usuario
INSERT INTO usuario
(nome,sobrenome,telefone,email,genero, senha) 
 VALUES 
 ('Luciano', 'Vieira', '(38) 998704348', 'paulistano.luciano@icloud.com', 'Masculino', 'Planinhos151') 

 INSERT INTO usuario 
(nome, sobrenome, email, telefone, genero, senha)
VALUES
('gustavo', 'Agusto', 'guxta12@gmail.com', '11 99225544', 'Masculino', '123');

 --selecionar todos usuario 
 SELECT *  FROM usuario;

 --selecionar um usuario 

 SELECT * FROM usuario WHERE email = 'paulistano.luciano@icloud.com';

 --alterar usuario
 UPDATE usuario SET email ='guxta12@gmail.com' WHERE id = 3;

 -- excluir usuario
 DELETE FROM usuario WHERE id = 2