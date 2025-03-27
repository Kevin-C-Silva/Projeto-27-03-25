create database dbSistema;
use dbSistema;

create table Usuario(
Id int primary key auto_increment,
Nome varchar(50) not null,
Email varchar(50) not null,
Senha varchar(50) not null
);

create table Produtos(
Id int primary key auto_increment,
Nome varchar(50) not null,
Descricao varchar(200) not null,
Preco decimal(5,2) not null
);