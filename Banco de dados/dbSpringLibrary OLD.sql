drop database if exists dbSpringLibrary;

create database dbSpringLibrary;
use dbSpringLibrary;

-- Usuário do banco 
-- usando user para acessar o banco
 
	create user if not exists 'SpringLibrary'@'localhost' identified with mysql_native_password BY '12345678';
	grant all privileges on dbSpringLibrary.* TO 'SpringLibrary'@'localhost' with grant option;

-- Criando tabelas 

create table Editora(
	IdEdit int primary key auto_increment,
    Nomdit varchar(30) not null, 
    TelEdit int(11) not null,
    EmailEdit varchar(30) not null
);

create table Genero(
	IdGen int primary key auto_increment,
    NomGen varchar(30) not null
);

create table Autor(
    IdAutor int primary key auto_increment,
    nomAutor varchar(30)
);

create table Produto(
	IdProd int primary key auto_increment,
    NomeProd varchar(100) not null,
    QtdProd smallint not null,
    Preco float(10,2) not null
);
 
 create table Livro(
	idLivro int primary key auto_increment, 
    nomLivro varchar(100) not null, 
    nomOriLiv varchar(100),
    ISBNLiv int(13) not null,
    pubLiv smallint not null,
    pagLiv smallint not null,
    anoLiv smallint not null, 
    IdEdit int not null,
    foreign key (IdEdit) references Editora (IdEdit),
    IdGen int not null, 
    foreign key (IdGen) references Genero (IdGen),
    IdProd int not null,
    foreign key (IdProd) references Produto (IdProd)
 );

create table Livro_Autor(
	IdLivro int, 
    IdAutor int,
    primary key (IdLivro, IdAutor),
    foreign key (IdLivro) references Livro (IdLivro),
    foreign key (IdAutor) references Autor (IdAutor)
);

create table Souvenir(
	IdSouv int primary key auto_increment,
    nomeSouv varchar(100) not null,
    tipoSouv varchar(50) not null,
    dimenSouv varchar(50) not null,
    IdProd int not null,
    foreign key (IdProd) references Produto (IdProd)
);
create table Endereco(
	IdEnde int primary key auto_increment,
    CEP int(13)
);

create table Cliente (
	IdCli int primary key auto_increment,
    nomCli varchar(50) not null,
    celCli int(11),
    emailCli varchar(50) not null,
	IdEnde int,
    foreign key (IdEnde) references Endereco(IdEnde),
    numEndCli smallint not null,
    compEndCli varchar(30)
);

create table Cargo(
	idCargo int primary key auto_increment,
    nomCargo varchar(30) not null
);

create table Funcionario(
	IdFunc int primary key auto_increment,
    nomFunc varchar(50) not null,
    CPFFunc int(11) not null,
    imgFunc varchar(30),
    idCargo int not null,
    foreign key (idCargo) references Cargo(idCargo),
    celFunc int(9) not null,
    emailFunc varchar(50) not null,
    senhaFunc varchar(50) not null
);
create table Delivery(
	IdDel int primary key auto_increment,
    -- IdNF int not null,
   -- foreign key (IdNF) references NotaFiscal (IdNF),
    statDel boolean not null,
    dtPrevDel datetime not null,
    dtFinDel datetime not null
);
create table NotaFiscal(
	IdNF int primary key auto_increment,
    valNF float(10,2) not null,
    delivNF boolean not null,
    dtNF datetime not null,
    pagNF varchar(10) not null,
    IdDel int null,
    foreign key(IdDel) references Delivery(IdDel),
    idFunc int not null,
    foreign key(idFunc) references Funcionario (IdFunc),
    IdCli int not null,
    foreign key (IdCli) references Cliente (IdCli)
);

create table ItemVenda(
	IdV int primary key auto_increment,
    idProd int not null,
    qtdIV int not null,
    valIV float(10,2) not null,
    idNF int not null,
    foreign key (idProd) references Produto(IdProd),
    foreign key (idNF) references NotaFiscal(IdNF)
);
create table ClienteFisico(
	IdCli int primary key auto_increment,
    foreign key (IdCli) references Cliente (IdCli),
    CPFCli int(11) not null, 
    dtNascCliF date not null
);

create table ClienteJuridico(
	IdCli int primary key auto_increment,
    foreign key (IdCli) references Cliente (IdCli),
    CNPJCli int(14) not null, 
    fantaCliJ varchar(50) not null,
    represCliJ varchar(30) not null 
);

-- Trigger de tirar do Estoque

DELIMITER $$
	create trigger tiraEstoque after insert 
    on ItemVenda for each row
    BEGIN
		update Produto set QtdProd = QtdProd - new.QtdIV
			where IdProd = new.IdProd;
    END
$$

-- Criando procedure "Tabela Genero"

DELIMITER $$
create procedure spInsertGenero(vNomGen varchar(30))
BEGIN
	insert into Genero (nomGen) values (vNomGen);
END $$

-- Testando com um gênero

call spInsertGenero ("Fantasia");

select * from Genero;

-- Populando tabela Gênero 

call spInsertGenero ("Ficção Científica");
call spInsertGenero ("Distopia");
call spInsertGenero ("Ação e Aventura");
call spInsertGenero ("Ficção Policial");
call spInsertGenero ("Horror");
call spInsertGenero ("Thriller e Suspense");
call spInsertGenero ("Ficção Histórica");
call spInsertGenero ("Romance");
call spInsertGenero ("Ficção feminina");
call spInsertGenero ("LGBTQ+");
call spInsertGenero ("Ficção Comtemporânea");
call spInsertGenero ("Realismo Mágico");
call spInsertGenero ("Graphic Novel");
call spInsertGenero ("Conto");
call spInsertGenero ("Young Adult");
call spInsertGenero ("New Adult");
call spInsertGenero ("Infantil");
call spInsertGenero ("Memórias e Autobiografia");
call spInsertGenero ("Biografia");
call spInsertGenero ("Gastronomia");
call spInsertGenero ("Arte e Fotografia");
call spInsertGenero ("Autoajuda");
call spInsertGenero ("História");
call spInsertGenero ("Viajem");
call spInsertGenero ("Crimes Reais");
call spInsertGenero ("Humor");
call spInsertGenero ("Ensaios");
call spInsertGenero ("Guias");
call spInsertGenero ("Religião e Espiritualidade");
call spInsertGenero ("Humanidades e Ciências Sociais");
call spInsertGenero ("Paternidade e Família");

select * from Genero;

-- Criando procedures "Insert"

-- Cargo

DELIMITER $$
create procedure spInsertCargo(vNomCargo varchar(30))
BEGIN
	insert into Cargo (nomCargo) values (vNomCargo);
END $$

call spInsertCargo ("Gerente");

select * from Cargo;

-- Populando Cargo

call spInsertCargo ('Bibliotecário');
call spInsertCargo ('Caixa');
call spInsertCargo ('Logístico');

select * from Cargo;

-- Funcionário

DELIMITER $$
create procedure spInsertFuncionario(vNomFunc varchar(50), vCPFFunc int(11), vimgFunc varchar(30),  vCargo varchar(30), vcelFunc int(9), vemailFunc varchar(50), vsenhaFunc varchar(50))
BEGIN
	insert into Funcionario (nomFunc, CPFFunc, imgFunc, idCargo, celFunc, emailFunc, senhaFunc)
    values (vNomFunc, vCPFFunc, vimgFunc, 
    (select idCargo from Cargo where nomCargo=vCargo),
    vcelFunc, vemailFunc, vsenhaFunc);
END $$

call spInsertFuncionario("Leticia", 1234567, "let.png", 'Gerente', 987643239, "leticiaresina@email.com", "1234567");
call spInsertFuncionario("Larissa", 3458759, "lari.png", 'Gerente', 987643819, "larii@email.com", "1234567");

-- teste com o nome do cargo
select Funcionario.nomFunc, Funcionario.emailFunc , Cargo.nomCargo from Funcionario inner join Cargo on Funcionario.idCargo=Cargo.idCargo ;

-- Procedure Editora 

DELIMITER $$
	create procedure spInsertEditora(vNomdit varchar(30), vTelEdit int(11), vEmailEdit varchar(30))
    BEGIN
	if not exists (select Nomdit from Editora where vNomdit=Nomdit) then
		insert into Editora (Nomdit, TelEdit, EmailEdit) values (vNomdit, vTelEdit, vEmailEdit);
	end if;
    END
$$

-- Testando

call spInsertEditora('Darkside', 1136189809, 'vc@darksidebooks.com');

select * from Editora; 

-- Populando com editoras pré definidas 

call spInsertEditora('Intrínseca', 2132067400, 'contato@intrinseca.com.br');

call spInsertEditora('Seguinte', 1137073500, 'contato@seguinte.com.br');

select * from Editora;

-- Procedure cliente físico 

DELIMITER $$
create procedure spInsertCliFisico(vnomCli varchar(50), vcelCli int, vemailCli varchar(50), vCEPCli varchar(11), vnumEndCli smallint, vcompEndCli varchar(30), vCPFCli int, vdtNascCliF date)
begin
	if not exists (select CPFCli from ClienteFisico where vCPFCli = CPFCli) then
		if not exists (select CEP from Endereco where CEP=vCEPCli) then
			insert into Endereco (CEP) values (vCEPCli);
		end if;
    	insert into Cliente (nomCli, celCli, emailCli, numEndCli, IdEnde, compEndCli) values (vnomCli, vcelCli, vemailCli, vnumEndCli, (select IdEnde from Endereco where CEP=vCEPCli), vcompEndCli);
		insert into ClienteFisico (CPFCli, dtNascCliF) values (vCPFCli, vdtNascCliF);
    end if;
end $$
 
 -- Testando 
SET SQL_SAFE_UPDATES = 0;

call spInsertCliFisico ('Jesus', 1199209832, 'jesuscristo@gmail.com', 06300187, 33, 'Casa', 459822213, '1990-12-25');
call spInsertCliFisico ('Kami', 1199209882, 'kamikat@gmail.com', 06309687, 34, 'Casa', 459722213, '1996-04-02');

call spInsertCliFisico ('Thaiga', 1199309833, 'thaigaloud@gmail.com', 06200087, 22, 'Casa', 459893116, '1996-01-03');

 call spInsertCliFisico ('Thiago Tinowns', 1199340822, 'tinownsthiago@gmail.com', 06200087, 22, 'Casa', 459873176, '1999-05-06');
 
 select * from ClienteFisico;
 select * from Cliente;
 
 -- Procedure cliente jurídico
 
 DELIMITER $$
create procedure spInsertCliJuridico(vnomCli varchar(50), vcelCli int, vemailCli varchar(50), vCEPCli varchar(11), vnumEndCli smallint, vcompEndCli varchar(30), vCNPJCli int, vfantaCliJ varchar(50), vrepresCliJ varchar(30))
begin
	if not exists (select CNPJCli from ClienteJuridico where vCNPJCli = CNPJCli) then
		insert into Cliente (nomCli, celCli, emailCli, IdEnde, numEndCli, compEndCli) values (vnomCli, vcelCli, vemailCli, (select IdEnde from Endereco where CEP=vCEPCli), vnumEndCli, vcompEndCli);
		insert into ClienteJuridico (CNPJCli, fantaCliJ, represCliJ) values (vCNPJCli, vfantaCliJ, vrepresCliJ);
    end if;
end $$

call spInsertCliJuridico ('Loud', 1136570927, 'loud@suporte.com.br', '06210027', 10, 'Bloco 10', 463650010, 'LOUD GG', 'Thaiga');

select * from ClienteJuridico;
select * from Cliente;

-- Procedure Livro Produto

DELIMITER $$
	create procedure spInsertProdutoLivro(vNomLivro varchar(100),
    vQtdProd smallint,
    vPreco float (10,2),
    vNomOriLiv varchar(100),
    vISBNLiv int(13),
    vpubliLiv smallint, 
	vpagLiv smallint,
    vanoLiv smallint,
    vNomdit varchar(30),
    vTelEdit int(11),
    vEmailEdit varchar(30),
    vNomGen varchar(30),
    vNomAutor varchar(30))
	BEGIN
    if not exists (select nomLivro from Livro where nomLivro=vNomLivro) then
		if not exists (select Nomdit from Editora where Nomdit=vNomdit) then
			insert into Editora (Nomdit, TelEdit, EmailEdit) values (vNomdit, vTelEdit, vEmailEdit);
		end if;
		if not exists (select NomGen from Genero where NomGen=vNomGen) then 
			insert into Genero (NomGen) values (vNomGen);
		end if;
        if not exists (select NomeProd from Produto where NomeProd=vNomLivro) then 
			insert into Produto (NomeProd, QtdProd, Preco) values (vNomLivro, vQtdProd, vPreco);
		end if;
        if not exists (select nomAutor from Autor where nomAutor=vNomAutor) then
			insert into Autor (nomAutor) values (vNomAutor);
		end if;
        insert into Livro (nomLivro, 
			nomOriLiv,
            ISBNLiv,
            pubLiv, 
            pagLiv, 
            anoLiv,
            IdEdit,
            IdGen,
            IdProd) values (vNomLivro, vNomOriLiv, vISBNLiv, vpubliLiv, vpagLiv, vanoLiv, 
            (select IdEdit from Editora where Nomdit=vNomdit),
            (select IdGen from Genero where NomGen=vNomGen),
            (select IdProd from Produto where NomeProd=vNomLivro));   
            
            insert into livro_autor (IdLivro, IdAutor) values ((select IdLivro from Livro where nomLivro=vNomLivro), 
        (select IdAutor from Autor where nomAutor=vNomAutor));
		end if; 
    END
$$

-- Testando (funcionando caso exista um livro com mesmo novo - fazer apenas a procedure)

call spInsertProdutoLivro('O Retrato de Dorian Gray', 20, 30.00, 'The Picture of Dorian Gray', '1234567', 2, 300, 1890, 'Darkside', 1136189809, 
'vc@darksidebooks.com', 'Terror', 'Oscar Wilde');

call spInsertProdutoLivro('A Lista de Convidados', 100, 29.90, 'The Guest List', '12345276', 2, 304, 2019, 'Intrínseca', 2132067400, 
'contato@intrinseca.com.br', 'Terror', 'Lucy Foley');

call spInsertProdutoLivro('Frankenstein', 300, 40.00, 'Frankenstein', '235612', 2, 300, 1890, 'Darkside', 1136189809, 
'vc@darksidebooks.com', 'Terror',  'Mary Shelley');

select * from Livro; 

select * from Produto;

select * from Editora;

select * from Livro_Autor;

select * from Autor;

-- Testando caso não haja a editora pré cadastrada

call spInsertProdutoLivro('Morte no internato', 40, 50.00, 'The Murders at Fleat House', '1238761', 9, 384, 2022, 'Arqueiro', 1134560987, 
'arqueiro@contato.com.br', 'Ficção', 'Lucinda Riley');

select * from Editora;

-- Procedure Souvenir Produto

DELIMITER $$
	create procedure spInsertProdutoSouvenir(vnomeSouv varchar(100),
    vtipoSouv varchar(50),
    vdimenSouv varchar(50),
    vQtdProd smallint,
    vPreco float(10,2))
    begin
		if not exists(select nomeSouv from Souvenir where nomeSouv=vnomeSouv) then 
			insert into Produto (NomeProd, QtdProd, Preco) values (vnomeSouv, vQtdProd, vPreco);
			insert into Souvenir (nomeSouv, tipoSouv, dimenSouv, IdProd) values (vnomeSouv, vtipoSouv, vdimenSouv, 
            (select IdProd from Produto where NomeProd=vnomeSouv));
        end if;
    end
$$

-- testando inserção de souvenir

call spInsertProdutoSouvenir('bottom pain gaming', 'broche', '5x5', 30, 12.00);

select * from Produto;

select * from Souvenir;

-- Testando 

call spInsertVenda(true, 'PAGO', 'Kami', 'Leticia', 2, '2022-09-19 10:50:00', '2022-11-11 22:30:00', 20.00, 'Frankenstein', 1 );

-- Procedure Venda

DELIMITER $$
	create procedure spInsertVenda(vDelivNF boolean,
    vPagNF varchar(10), 
    vNomeCli varchar(50),
    vNomeFunc varchar(50),
    vStatDel tinyint(1),
    vdtPrevDel datetime,
    vdtFinDel datetime,
    vValNF float(10,2),
    vNomeProd varchar(30),
    vQtdIV int)
    begin
		If vDelivNF=true then
			insert into Delivery (statDel, dtPrevDel, dtFinDel) values (vStatDel, vdtPrevDel, vdtFinDel);
			
            insert into NotaFiscal (valNF, delivNF, dtNF, pagNF, IdDel, idFunc, IdCli) values (
			vvalNF, true, (select current_timestamp()), 
            vPagNF, 
            (select IdDel from Delivery where statDel=vStatDel and dtPrevDel=vdtPrevDel and dtFinDel=vdtFinDel), 
            (select IdFunc from Funcionario where nomFunc=vNomeFunc),
            (select IdCli from Cliente where nomCli=vNomeCli));
            
            insert into ItemVenda (idProd, qtdIV, valIV, idNF) values (
            (select IdProd from Produto where NomeProd=vNomeProd),
            vQtdIV, (select(select Preco from Produto where NomeProd=vNomeProd)*vQtdIV),
            (select IdNF From NotaFiscal where valNF=vValNF
            and dtNF=(select current_timestamp())
            and idFunc=(select IdFunc from Funcionario where nomFunc=vNomeFunc)
            and idCli=(select IdCli from Cliente where nomCli=vNomeCli)));
            
            end if;
            
		 if vDelivNF=false then 
			insert into NotaFiscal (valNF, delivNF, dtNF, pagNF, IdDel, idFunc, IdCli) values
            (vvalNF, false, (select current_timestamp()), 
            vPagNF, (select IdDel from Delivery where statDel=vStatDel 
            and dtPrevDel=vdtPrevDel and dtFinDel=vdtFinDel), 
            (select IdFunc from Funcionario where nomFunc=vNomeFunc),
            (select IdCli from Cliente where nomCli=vNomeCli));
            
             insert into ItemVenda (idProd, qtdIV, valIV, idNF) values (
            (select IdProd from Produto where NomeProd=vNomeProd),
            vQtdIV, (select(select Preco from Produto where NomeProd=vNomeProd)*vQtdIV),
            (select IdNF From NotaFiscal where valNF=vValNF
            and dtNF=(select current_timestamp())
            and idFunc=(select IdFunc from Funcionario where nomFunc=vNomeFunc)
            and idCli=(select IdCli from Cliente where nomCli=vNomeCli)));
        end if;
    end
$$

-- TESTES COM DELIVERY 

call spInsertVenda(true, 'PAGO', 'Kami', 'Larissa', 1, '2022-09-19 10:40:00', '2022-11-11 22:20:00', 20.00, 'Frankenstein', 1 );

call spInsertVenda(true, 'PAGO', 'Loud', 'Leticia', 1, '2022-09-19 10:50:00', '2022-11-11 22:50:00', 20.00, 'Frankenstein', 1 );

select * from Funcionario;

select * from NotaFiscal;

select * from Delivery;

select * from ItemVenda;

-- TESTES SEM DELIVERY 

call spInsertVenda(false, 'PAGO', 'Kami', 'Leticia', null, null, null, 30.00, 'O Retrato de Dorian Gray', 1 );

select * from Funcionario;

select * from NotaFiscal;

select * from Delivery;

select * from ItemVenda;

-- Procedures de update

-- Livro

DELIMITER $$
	create procedure spUpdateLivro(
		vidLivro int,
		vNomLivro varchar(100),
        vIdProd int,
		vQtdProd smallint,
		vPreco float (10,2),
		vNomOriLiv varchar(100),
		vISBNLiv int(13),
		vpubliLiv smallint, 
		vpagLiv smallint,
		vanoLiv smallint,
		vIdEdit int,
		vNomdit varchar(30),
		vTelEdit int(11),
		vEmailEdit varchar(30),
        vIdGen int,
		vNomGen varchar(30),
        vIdAutor int, 
		vNomAutor varchar(30))
	BEGIN
		update Livro set NomLivro = vNomLivro, NomOriLiv = vNomOriLiv, ISBNLiv = vISBNLiv, publiLiv = vpubliLiv, pagLiv = vpagLiv, anoLiv = vanoLiv where (idLivro = vidLivro);
        update Editora set Nomdit = vNomdit, TelEdit = vTelEdit, EmailEdit = vEmailEdit where (IdEdit = vIdEdit);
        update Autor set NomAutor = vNomAutor where (IdAutor = vIdAutor);
        update Genero set NomGen = vNomGen where (IdGen = vIdGen);
        update Produto set QtdProd = vQtdProd, Preco = vPreco where (IdProd = vIdProd);
    END
$$

-- Testes

-- call spUpdateLivro

-- Souvenir

DELIMITER $$
	create procedure spUpdateSouvenir(
        vIdSouv int,
        vnomeSouv varchar(100),
		vtipoSouv varchar(50),
		vdimenSouv varchar(50),
		vIdProd int, 
		vQtdProd smallint,
		vPreco float(10,2))
	BEGIN
		update Souvenir set nomeSouv = vnomeSouv, tipoSouv = vtipoSouv, dimenSouv = vdimenSouv;
        update Produto set QtdProd = vQtdProd, Preco = vPreco where (IdProd = vIdProd);
    END
$$

-- Testes

-- call spUpdateSouvenir 

-- Cliente físico 

DELIMITER $$
	create procedure spUpdateCliFisico(
    vIDCli smallint,
    vCPFCli int,
    vdtNascCliF date,
    vnomCli varchar(50),
    vcelCli int,
    vemailCli varchar(50),
    vCEP int,
    vnumEndCli smallint,
    vcompEndCli varchar(30))
    BEGIN
		if not exists (select CEP from Endereco where CEP=vCEP) then
			insert into Endereco (CEP) values (vCEP);
        end if;
		update ClienteFisico set CPFCli=vCPFCli, dtNascCliF=vdtNascCliF where IdCli=vIDCli;
        
        update Cliente set nomCli=vnomCli, celCli=vcelCli, emailCli=vemailCli, IdEnde=(select IdEnde from Endereco 
        where CEP=vCEP), numEndCli=vnumEndCli, compEndCli=vcompEndCli where IdCli=vIDCli;
        
    END
$$

-- Testes 

-- call spUpdateCliFisico

-- Cliente Juridico 

DELIMITER $$
	create procedure spUpdateCliJuridico(
    vIDCli smallint,
    vCNPJCli int,
    vfantaCliJ varchar(50),
    vrepresCliJ varchar(30),
    vnomCli varchar(50),
    vcelCli int,
    vemailCli varchar(50),
    vCEP int,
    vnumEndCli smallint,
    vcompEndCli varchar(30))
    BEGIN 
    
		update ClienteJuridico set CNPJCli=vCNPJCli, fantaCliJ=vfantaCliJ, represCliJ=vrepresCliJ where IdCli=vIDCli;
        
        update Cliente set nomCli=vnomCli, celCli=vcelCli, emailCli=vemailCli, IdEnde=(select IdEnde from Endereco 
        where CEP=vCEP), numEndCli=vnumEndCli, compEndCli=vcompEndCli where IdCli=vIDCli;
    END
$$

-- Testes 

-- call spUpdateCliJuridico

-- Funcionário 

DELIMITER $$
	create procedure spUpdateFuncionario(vIDFunc int,
    vnomFunc varchar(50),
    vCPFFunc int,
    vimgFunc varchar(30),
    vIdCargo int,
    vcelFunc int,
    vemailFunc varchar(50),
    vsenhaFunc varchar(50))
    BEGIN
         update Funcionario set nomFunc=vnomFunc, CPFFunc=vCPFFunc, imgFunc=vimgFunc, 
         idCargo=vIdCargo, celFunc=vcelFunc, emailFunc=vemailFunc, senhaFunc=vsenhaFunc where IdFunc=vIDFunc;
    END
$$

-- Testes 

-- call spUpdateFuncionario

-- Delivery

DELIMITER $$
	create procedure spUpdateDelivery()
    BEGIN
    
    END
$$

-- Testes 

-- call spUpdateDelivery

-- Views 

-- View para mostrar funcionário cargo

create View vwSelectFuncionarioCargo as select 
	Funcionario.IdFunc as 'Id', 
    Funcionario.nomFunc as 'Nome do funcionário',
    Funcionario.CPFFunc as 'CPF do funcionário',
    Funcionario.imgFunc as 'Imagem do funcionário',
    Funcionario.celFunc 'Telefone Celular',
    Funcionario.emailFunc as 'Email do funcionário',
    Funcionario.senhaFunc as 'Senha do funcionário',
    Cargo.nomCargo as 'Cargo do funcionário'
		from Funcionario 
				inner join Cargo on Funcionario.idCargo=Cargo.idCargo;

-- Testando 

select * from vwSelectFuncionarioCargo;

-- View para mostrar livro e suas informações

create view vwSelectLivro as select
	lv.nomLivro as 'Nome do livro', 
    lv.nomOriLiv as 'Nome original do livro',
    lv.ISBNLiv as 'ISBN',
    lv.pubLiv as 'Edição do livro', 
    lv.pagLiv as 'Quantidade de páginas do livro', 
    lv.anoLiv as 'Ano de publicação',
    gen.NomGen as 'Gênero do livro',
    aut.NomAutor as 'Nome do autor',
	edit.Nomdit as 'Nome da editora',
    edit.TelEdit as 'Telefone da editora',
    edit.EmailEdit as 'Email da editora',
    prod.Preco as 'Preço do livro',
    prod.QtdProd as 'Quantidade no estoque'
    from Livro as lv
			inner join Genero as gen on lv.IdGen = gen.IdGen
            inner join Produto as prod on lv.IdProd = prod.IdProd
            inner join Editora as edit on lv.IdEdit = edit.IdEdit
            inner join Livro_Autor as lva on lv.IdLivro = lva.IdLivro
            inner join Autor as aut on lva.IdAutor = aut.IdAutor;
            
-- Testando 

select * from vwSelectLivro;

-- Procedure para mostrar souvenir e suas informações

create view vwSelectSouvenir as select
	Souvenir.nomeSouv as 'Souvenir',
    Souvenir.tipoSouv as 'Tipo do Souvenir', 
    Souvenir.dimenSouv as 'Dimensão do Souvenir', 
    Produto.Preco as 'Preço do Souvenir',
	Produto.QtdProd as 'Quantidade no estoque'
	from Souvenir 
			inner join Produto on Souvenir.IdProd = Produto.IdProd;

-- Testando 

select * from vwSelectSouvenir;

-- Views para clientes

-- Cliente físico 

create view vwSelectCliFisico as select
	Cliente.nomCli as 'Nome do cliente', 
    Cliente.celCli as 'Celular do cliente',
    Cliente.emailCli as 'Email do cliente', 
    Endereco.CEP as 'CEP',
    Cliente.numEndCli as 'Número do endereço', 
    Cliente.compEndCli as 'Complemento', 
    ClienteFisico.CPFCli as 'CPF', 
    ClienteFisico.dtNascCliF as 'Data de nascimento'
		from Cliente 
				inner join Endereco on Cliente.IdEnde = Endereco.IdEnde
                inner join ClienteFisico on Cliente.IdCli = ClienteFisico.IdCli;
			
-- Testando

select * from vwSelectCliFisico

-- Cliente Jurídico 

create view vwSelectCliJur as select
	Cliente.nomCli as 'Nome do cliente', 
    Cliente.celCli as 'Celular do cliente',
    Cliente.emailCli as 'Email do cliente', 
    Endereco.CEP as 'CEP',
    Cliente.numEndCli as 'Número do endereço', 
    Cliente.compEndCli as 'Complemento', 
    ClienteJuridico.CNPJCli as 'CNPJ', 
    ClienteJuridico.fantaCliJ as 'Nome fantasia',
    ClienteJuridico.represCliJ as 'Representante da empresa'
    from Cliente 
				inner join Endereco on Cliente.IdEnde = Endereco.IdEnde
                inner join ClienteJuridico on Cliente.IdCli = ClienteJuridico.IdCli;
                
-- Testando

select * from vwSelectCliJur;

-- Views para ver as vendas 

-- Sem delivery

create view vwSelectVendas as select 
	Cliente.NomCli as 'Nome do cliente',
    Funcionario.NomFunc as 'Funcionário responsável',
	Produto.NomeProd as 'Nome do Produto',
    NotaFiscal.PagNF as 'Situação de pagamento', 
    ItemVenda.QtdIV as 'Quantidade de compra', 
    ItemVenda.valIV as 'Valor total com a quantidade',
	NotaFiscal.DelivNF as 'Situação Delivery'
		From NotaFiscal
			inner join Funcionario on NotaFiscal.idFunc = Funcionario.IdFunc
            inner join Cliente on NotaFiscal.IdCli = Cliente.IdCli
            inner join ItemVenda on NotaFiscal.idNF = ItemVenda.IdNF
            inner join Produto on ItemVenda.idProd = Produto.idProd;
            
-- testando

select * from vwSelectVendas;

-- Com delivery
    
create view vwSelectVendaDel as select 
	Cliente.NomCli as 'Nome do cliente',
    Funcionario.NomFunc as 'Funcionário responsável',
	Produto.NomeProd as 'Nome do Produto',
    NotaFiscal.PagNF as 'Situação de pagamento', 
    ItemVenda.QtdIV as 'Quantidade de compra', 
    ItemVenda.valIV as 'Valor total com a quantidade',
	NotaFiscal.DelivNF as 'Situação Delivery',
    Delivery.StatDel as 'Status do Delivery', 
    Delivery.dtPrevDel as 'Data de previsão de entrega',
    Delivery.dtFinDel as 'Data final do delivery'
		From NotaFiscal
			inner join Funcionario on NotaFiscal.idFunc = Funcionario.IdFunc
            inner join Cliente on NotaFiscal.IdCli = Cliente.IdCli
            inner join Delivery on NotaFiscal.IdDel = Delivery.IdDel
            inner join ItemVenda on NotaFiscal.idNF = ItemVenda.IdNF
            inner join Produto on ItemVenda.idProd = Produto.idProd;
    
-- Testando

select * from vwSelectVendaDel;