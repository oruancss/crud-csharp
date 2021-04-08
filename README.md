# CRUD C#

CRUD (Create, read, update and delete) feito por mim em C#.<br/>
Projeto feito unicamente para portfólio e estudos.

### Como usar?

1. Faça o download do projeto.
2. Tenha o <strong><a href="https://www.apachefriends.org/pt_br/index.html" target="_blank">xampp</a></strong> instalado.
3. No phpMyAdmin, crie um banco de dados chamado "cad_user".
4. Insira o seguinte código no SQL do banco criado e depois é só executar o CRUD.exe e usar.<br/>

<code>
CREATE TABLE `cadastrados` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(50) NOT NULL,
  `sobrenome` VARCHAR(50) NOT NULL,
  `email` VARCHAR(50) NOT NULL,
  `telefone` VARCHAR(13) NOT NULL,
  PRIMARY KEY (`id`)
);
</code>
