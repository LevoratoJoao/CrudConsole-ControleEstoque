--IDPROD, DESCRICAO, ESTOQUE, VALOR

Create table Produto (
idprod integer not null,
descricao varchar(100) not null,
estoque integer not null,
valor decimal(9,2) not null,
primary key (idprod)
);
INSERT INTO Produto VALUES (1,'Notebook Dell',10,4500);
INSERT INTO Produto VALUES (2,'Notebook Acer',15,4500);
INSERT INTO Produto VALUES (3,'Mouse',50,100);
INSERT INTO Produto VALUES (4,'Teclado',50,100);
INSERT INTO Produto VALUES (5,'Monitor',20,2000);

select*from Produto;