/* PADRONIZAÇÃO PARA EVITAR INCOERÊNCIAS ENTRE AS APLICAÇÕES
	TABELAS		: tb<NomeDaTabela> ...
	COLUNAS		: <nomeDaColuna><AbrevicaoDoNomeDaTabela> ...
    PROCEDURES	: sp<nomeDaProcedure>(...);
    VARIÁVEIS	: $<nomeDaVariavel>
    
    !! ATENTAR-SE AO CAPSLOCK !!
*/

SET SQL_SAFE_UPDATES = 0;

create user if not exists 'SpringLibrary'@'localhost' identified with mysql_native_password BY '12345678';
grant all privileges on dbSpringLibrary.* TO 'SpringLibrary'@'localhost' with grant option;

drop database if exists dbspringlibrary;
create database dbspringlibrary;
use dbspringlibrary;

-- =========================================== --
-- == -- == -- == -- Editora -- == -- == -- == --
-- =========================================== --
CREATE TABLE tbEditora(
	idEdit int primary key auto_increment,
    nomEdit varchar(30) not null unique, 
    celEdit bigint(11) not null,
    emailEdit varchar(30) not null
);

-- cadEditIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadEdit(
	$nomEdit varchar(30),
    $celEdit bigint(11),
    $emailEdit varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomEdit FROM tbEditora WHERE nomEdit = $nomEdit) THEN
		INSERT INTO tbEditora(nomEdit, celEdit, emailEdit) 
			VALUES ($nomEdit, $celEdit, $emailEdit);
	END IF;
END$$

CALL spcadEdit("Seguinte", 1137073500, 'contato@seguinte.com.br');
CALL spcadEdit("BooKsa", 99999999999, "contato@booksa.com");
CALL spcadEdit("Primier", 45944886612, "primier.contato@gmail.com");
CALL spcadEdit("Darkside", 1136189809, 'vc@darksidebooks.com');
CALL spcadEdit("Intrínseca", 2132067400, 'contato@intrinseca.com.br');

-- checkAllEdit
DELIMITER $$
CREATE PROCEDURE spcheckAllEdit()
BEGIN
	SELECT * FROM tbEditora;
END$$

CALL spcheckAllEdit();

-- altEdit
DELIMITER $$
CREATE PROCEDURE spaltEdit(
	$idEdit int,
	$nomEdit varchar(30),
    $celEdit bigint(11),
    $emailEdit varchar(30)
)
BEGIN
	UPDATE tbEditora SET nomEdit = $nomEdit, celEdit = $celEdit, emailEdit = $emailEdit WHERE idEdit = $idEdit;
END$$

CALL spaltEdit(3, "Primier", 1137777777, "primier.contato@gmail.com");

-- checkEditById
DELIMITER $$
CREATE PROCEDURE spcheckEditById(
	$idEdit int
)
BEGIN
	SELECT * FROM tbEditora WHERE idEdit = $idEdit;
END$$

CALL spcheckEditById(3);


-- ========================================== --
-- == -- == -- == -- Genero -- == -- == -- == --
-- ========================================== --
CREATE TABLE tbGenero(
	idGen int primary key auto_increment,
    nomGen varchar(30) not null
);

-- cadGenIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadGen(
	$nomGen varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomGen FROM tbGenero WHERE nomGen = $nomGen) THEN
		INSERT INTO tbGenero(nomGen) 
			VALUES ($nomGen);
	END IF;
END$$

CALL spcadGen("Fantasia");
CALL spcadGen("Fikisão-Cientifika");
CALL spcadGen("Distopia");
CALL spcadGen("Ação e Aventura");
CALL spcadGen("Ficção Policial");
CALL spcadGen("Horror");
CALL spcadGen("Thriller e Suspense");
CALL spcadGen("Ficção Histórica");
CALL spcadGen("Romance");
CALL spcadGen("Ficção feminina");
CALL spcadGen("LGBTQ+");
CALL spcadGen("Ficção Comtemporânea");
CALL spcadGen("Realismo Mágico");
CALL spcadGen("Graphic Novel");
CALL spcadGen("Conto");
CALL spcadGen("Young Adult");
CALL spcadGen("New Adult");
CALL spcadGen("Infantil");
CALL spcadGen("Memórias e Autobiografia");
CALL spcadGen("Biografia");
CALL spcadGen("Gastronomia");
CALL spcadGen("Arte e Fotografia");
CALL spcadGen("Autoajuda");
CALL spcadGen("História");
CALL spcadGen("Viajem");
CALL spcadGen("Crimes Reais");
CALL spcadGen("Humor");
CALL spcadGen("Ensaios");
CALL spcadGen("Guias");
CALL spcadGen("Religião e Espiritualidade");
CALL spcadGen("Humanidades e Ciências Sociais");
CALL spcadGen("Paternidade e Família");

-- checkAllGen
DELIMITER $$
CREATE PROCEDURE spcheckAllGen()
BEGIN
	SELECT * FROM tbGenero;
END$$

CALL spcheckAllGen();

-- altGen
DELIMITER $$
CREATE PROCEDURE spaltGen(
	$idGen int,
	$nomGen varchar(30)
)
BEGIN
	UPDATE tbGenero SET nomGen = $nomGen WHERE idGen = $idGen;
END$$

CALL spaltGen(2, "Ficção Científica");

-- checkGenById
DELIMITER $$
CREATE PROCEDURE spcheckGenById(
	$idGen int
)
BEGIN
	SELECT * FROM tbGenero WHERE idGen = $idGen;
END$$

CALL spcheckGenById(2);


-- ========================================= --
-- == -- == -- == -- Autor -- == -- == -- == --
-- ========================================= --
CREATE TABLE tbAutor(
	idAut int primary key auto_increment,
    nomAut varchar(30) not null
);

-- cadAutIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadAut(
	$nomAut varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomAut FROM tbAutor WHERE nomAut = $nomAut) THEN
		INSERT INTO tbAutor(nomAut) 
			VALUES ($nomAut);
	END IF;
END$$

CALL spcadAut("Ozcar Wailde");
CALL spcadAut("Lucy Foley");
CALL spcadAut("Mary Shelley");

-- checkAllAut
DELIMITER $$
CREATE PROCEDURE spcheckAllAut()
BEGIN
	SELECT * FROM tbAutor;
END$$

CALL spcheckAllAut();

-- altGen
DELIMITER $$
CREATE PROCEDURE spaltAut(
	$idAut int,
	$nomAut varchar(30)
)
BEGIN
	UPDATE tbAutor SET nomAut = $nomAut WHERE idAut = $idAut;
END$$

CALL spaltAut(1, "Oscar Wilde");

-- checkAutById
DELIMITER $$
CREATE PROCEDURE spcheckAutById(
	$idAut int
)
BEGIN
	SELECT * FROM tbAutor WHERE idAut = $idAut;
END$$

CALL spcheckAutById(1);

-- =============================================== --
-- == -- == -- == -- Produto  == -- == -- == -- == --
-- =============================================== --
create table tbProduto(
	idProd int primary key auto_increment,
    apelidProd varchar(50) not null unique,
    imgProd varchar(500) not null,
    qtdProd smallint not null,
    precoProd float(10,2) not null
);

-- Não existe sp que cadastra produtos, pois estes são cadastrados a partir de sp's de tabelas derivadas da tabela produto,
-- dependência esta que apenas permite sua criação posterior à da tabela produto;

-- checkAllProd
DELIMITER $$
CREATE PROCEDURE spcheckAllProd()
BEGIN
	SELECT * FROM tbProduto;
END$$

CALL spcheckAllProd();
-- Retornará vazio até que produtos seja cadastrados (ver linhas 233~234)

-- altProd
DELIMITER $$
CREATE PROCEDURE spaltProd(
	$idProd int,
	$apelidProd varchar(50),
    $imgProd varchar(100),
    $qtdProd smallint,
    $precoProd float(10,2)
)
BEGIN
	UPDATE tbProduto SET apelidProd = $apelidProd, imgProd = $imgProd, qtdProd = $qtdProd, precoProd = $precoProd WHERE idProd = $idProd;
END$$

-- Call não pode ser executado por não existirem produtos cadastrados (ver linhas 233~234)

-- checkProdById
DELIMITER $$
CREATE PROCEDURE spcheckProdById(
	$idProd int
)
BEGIN
	SELECT * FROM tbProduto WHERE idProd = $idProd;
END$$

CALL spcheckProdById(1);
-- Retornará vazio até que produtos seja cadastrados (ver linhas 233~234)

-- =============================================== --
-- == -- == -- == -- Livro -- == -- == -- == -- == --
-- =============================================== --
CREATE TABLE tbLivro (
    ISBNLiv CHAR(13) PRIMARY KEY,
    titLivro VARCHAR(100) NOT NULL,
    titOriLiv VARCHAR(100),
    sinopLiv VARCHAR(1500) NOT NULL,
    pratLiv SMALLINT NOT NULL,
	numPagLiv SMALLINT NOT NULL,
    numImpresLiv SMALLINT NOT NULL,
    anoLiv SMALLINT NOT NULL,
    idEdit INT NOT NULL,
    FOREIGN KEY (idEdit)
        REFERENCES tbEditora (idEdit),
    idGen INT NOT NULL,
    FOREIGN KEY (idGen)
        REFERENCES tbGenero (idGen),
    idProd INT NOT NULL,
    FOREIGN KEY (idProd)
        REFERENCES tbProduto (idProd)
);

-- Tabela necessária para intermediar a relação entre livros e seu(s) atore(s)
CREATE TABLE tbLivroAutor (
	ISBNLiv char(13),
    idAut INT,
    FOREIGN KEY (ISBNLiv)
        REFERENCES tbLivro (ISBNLiv),
    FOREIGN KEY (idAut)
        REFERENCES tbAutor (idAut)
);

-- cadLivIfNotExists
DELIMITER $$
CREATE PROCEDURE spcadLiv(
    $apelidProd varchar(50),
    $imgProd varchar(500),
	$qtdProd smallint,
	$precoProd float(10,2),
	$ISBNLiv char(13),
	$titLivro varchar(100),
	$titOriLiv varchar(100), 
	$sinopLiv varchar(1500), 
	$pratLiv smallint, 
	$numPagLiv smallint, 
	$numImpresLiv smallint, 
	$anoLiv smallint, 
    $idAut int, 
	$idEdit int, 
	$idGen int
)
BEGIN
	IF NOT EXISTS (SELECT apelidProd FROM tbProduto WHERE apelidProd = $apelidProd) THEN
		INSERT INTO tbProduto(apelidProd, imgProd, qtdProd, precoProd) 
			VALUES ($apelidProd, $apelidProd, $qtdProd, $precoProd);
		INSERT INTO tbLivro
			VALUES ($ISBNLiv, $titLivro, $titOriLiv, $sinopLiv, $pratLiv, $numPagLiv, $numImpresLiv, $anoLiv, $idEdit, $idGen,
            (SELECT idProd from tbProduto ORDER BY idProd DESC LIMIT 1));
		INSERT INTO tbLivroAutor
			VALUES ((SELECT ISBNLiv from tbLivro ORDER BY ISBNLiv DESC LIMIT 1),$idAut);
	END IF;
END$$

call spcadLiv('O Retratat-Darkside',
'https://darkside.vteximg.com.br/arquivos/ids/176889-519-519/o-retrato-de-dorian-gray-0.png?v=637655004666100000',200,30.00,9786555980004,
'O Retrato de Dorian Gray', 'The Picture of Dorian Gray',
'Único romance de Oscar Wilde, O Retrato de Dorian Gray combina o apuro literário e estético de seu autor com uma trama sombria, 
pontuada por paixões, crimes e a brilhante e sarcástica verve wildeana. Publicado em 1890 na revista norte-americana Lippincott’s, 
o romance foi relançado em livro um ano depois em uma edição que censurou diversos trechos da obra. Dorian Gray primeiramente ofendeu 
uma geração vitoriana que encontrou na relação entre os amigos Dorian, o jovem retratado, Basil, o pintor apaixonado, e Henry, o lorde 
cínico, “o amor que não ousava dizer o seu nome”. Depois, fascinou leitores, críticos e artistas, que viram no enredo que remete ao mito 
de Fausto o Evangelho de um decadentismo que acredita em uma vida de arte, prazer e fascínio sensorial. Tudo isso em meio a um fim de 
século no qual a convenção e a moralidade corroíam qualquer prazer que a existência humana poderia desfrutar.',1,320,1,2021,1,4,9);

call spcadLiv('Frankenste-Darkside','link',300,40.00,'9869387875698','Frankenstein',null,'Sinopse',1,283,2,1991,3,4,7);

-- =============================================== --
-- == -- == -- == -- Endereço -- == -- == -- == -- ==
-- =============================================== --
create table tbEndereco(
    CEP int(13) primary key
);
-- A tabela endereço não terá qualquer atividade de CRUD por si só, sendo 100% manipulada por operações vinculadas às telas de cliente

-- =============================================== --
-- == -- == -- == -- Cliente -- == -- == -- == -- ==
-- =============================================== --
CREATE TABLE tbCliente (
	idCli int primary key auto_increment,
    nomCli varchar(100) not null,
    tipoCli boolean not null, -- FALSE para FÍSICO  ///  TRUE para JURÍDICO
	celCli varchar(11),
    emailCli varchar(125) not null,
    senhaCli varchar(260) not null,
	CEP int(13),
    foreign key (CEP) references tbEndereco(CEP),
    numEndCli smallint not null,
    compEndCli varchar(30)
);

-- vwSelectAllCli
create view vwcheckAllCli as select
	idCli as 'ID',
	nomCli as 'Nome', 
    celCli as 'Celular',
    emailCli as 'Email', 
	senhaCli as 'Senha',
    CEP as 'CEP',
    numEndCli as 'Número do endereço', 
    compEndCli as 'Complemento' 
		from tbCliente;
        
select * from vwcheckAllCli;
-- Retornará vazio até que clientes físicos ou jurídicos sejam cadastrados

-- spCheckCliByUsername
DELIMITER $$
CREATE PROCEDURE spcheckCliByName($vnomCli varchar(20))
BEGIN
	select * from tbCliente WHERE(nomCli = $vnomCli);
END$$

call spcheckCliByName("Gabriel Bohm Santos");
call spcheckCliByName("Gus Rodrigues");
call spcheckCliByName("Bianca Lula");
call spcheckCliByName("Thiago Sartori");
-- Retornará vazio até que clientes físicos ou jurídicos sejam cadastrados


-- =============================================== --
-- == -- == -- == -- Cliente Físico -- == -- == -- ==
-- =============================================== --
create table tbCliFis(
	CPFCli int(11) primary key,
	idCli int unique,
    foreign key (idCli) references tbCliente (idCli),
    dtNascCliF date not null
);

-- spInsertCliFis
DELIMITER $$
create procedure spcadCliFis(
vnomCli varchar(100),
vcelCli varchar(11),
vemailCli varchar(125),
vsenhaCli varchar(260),
vCEP varchar(13),
vnumEndCli smallint,
vcompEndCli varchar(30),
vCPFCli int,
vdtNascCliF date)
begin
	if not exists (select CPFCli from tbCliFis where vCPFCli = CPFCli) then
		if not exists (select CEP from tbEndereco where CEP=vCEP) then
			insert into tbEndereco (CEP) values (vCEP);
		end if;
    	insert into tbCliente (nomCli, tipoCli, celCli, emailCli, senhaCli, CEP, numEndCli, compEndCli) values 
			 (vnomCli, false, vcelCli, vemailCli, vsenhaCli, vCEP, vnumEndCli, vcompEndCli);
		insert into tbCliFis (CPFCli, idCli, dtNascCliF) values
			(vCPFCli, (select idCli from tbCliente order by idCli desc limit 1), vdtNascCliF);
    end if;
end $$

call spcadCliFis('Jesus Youssef', '1199209832', 'jesuscristo@gmail.com', 'senha', 06300187, 33, 'Casa', 459822213, '1990-12-25');
call spcadCliFis('Gabriel Bohm Santos', '1199209882', 'kamikat@gmail.com', 'senha', 06309687, 34, 'Casa', 459722213, '1996-04-02');
call spcadCliFis('Bianca Lula', '1199309833', 'thaigaloud@gmail.com', 'senha', 06200087, 22, 'Casa', 459893116, '1996-01-03');
call spcadCliFis('Thiago Sartori', '1199340822', 'tinownsthiago@gmail.com', 'senha', 06200087, 22, 'Casa', 459873176, '1999-05-06');

-- spUpdateCliFis
DELIMITER $$
	create procedure spaltCliFis(
    vidCli smallint,
    vnomCli varchar(100),
    vcelCli varchar(11),
    vemailCli varchar(125),
	vsenhaCli varchar(260),
    vCEP int(13),
    vnumEndCli smallint,
    vcompEndCli varchar(30),
	vCPFCli int(11),
	vdtNascCliF date)
BEGIN
	if not exists (select CEP from tbEndereco where CEP=vCEP) then
		insert into tbEndereco (CEP) values (vCEP);
	end if;
	update tbCliFis set CPFCli=vCPFCli, dtNascCliF=vdtNascCliF where idCli=vidCli;

	update tbCliente set nomCli=vnomCli, celCli=vcelCli, emailCli=vemailCli, senhaCli=vsenhaCli,  
	CEP=vCEP, numEndCli=vnumEndCli, compEndCli=vcompEndCli where idCli=vidCli;
END$$

call spaltCliFis(2, 'Gus Rodrigues', '1194320943', 'gusthienx@gmail.com', 'senha', 06300187, 33, 'Casa', 93872213, '1990-12-25');

-- vwCheckCliFis
create view vwcheckCliFis as select
	tbCliente.idCli as 'ID',
	nomCli as 'Nome', 
    celCli as 'Celular',
    emailCli as 'Email', 
	senhaCli as 'Senha',
    CEP as 'CEP',
    numEndCli as 'Número do endereço', 
    compEndCli as 'Complemento', 
    CPFCli as 'CPF', 
    dtNascCliF as 'Data de nascimento'
		from tbCliente 
                inner join tbCliFis on tbCliente.idCli = tbCliFis.idCli;

select * from vwcheckCliFis;

-- =============================================== --
-- == -- == -- == -- Cliente Jurídico -- == -- == -- 
-- =============================================== --
create table tbCliJur(
	CNPJCli int(14) primary key, 
	idCli int unique,
    foreign key (idCli) references tbCliente (idCli),
    fantaCliJ varchar(100) not null,
    represCliJ varchar(50) not null 
);

-- spInsertCliJur
DELIMITER $$
create procedure spcadCliJur(
vnomCli varchar(100),
vcelCli varchar(11),
vemailCli varchar(125),
vsenhaCli varchar(260),
vCEP varchar(13),
vnumEndCli smallint,
vcompEndCli varchar(30),
vCNPJCli int(14),
vfantaCliJ varchar(100),
vrepresCliJ varchar(50))
begin
	if not exists (select CNPJCli from tbCliJur where vCNPJCli = CNPJCli) then
		if not exists (select CEP from tbEndereco where CEP=vCEP) then
			insert into tbEndereco (CEP) values (vCEP);
		end if;
    	insert into tbCliente (nomCli, tipoCli, celCli, emailCli, senhaCli, numEndCli, CEP, compEndCli) values 
			(vnomCli, true, vcelCli, vemailCli, vsenhaCli, vnumEndCli, vCEP, vcompEndCli);
		insert into tbCliJur (CNPJCli, idCli, fantaCliJ, represCliJ) values
			(vCNPJCli, (select idCli from tbCliente order by idCli desc limit 1), vfantaCliJ,  vrepresCliJ);
    end if;
end $$

call spcadCliJur('Loud', '1136570927', 'loud@suporte.com.br', 'senha', '06210027', 10, 'Bloco 10', 463650010, 'LOUD GG', 'Thaiga');
call spcadCliJur
('Jornal BG News', '11958424397', 'bgnews@gmail.com', 'senha', '05089000', 678 , null, 233980686, 'MIDIAS BGNEWS', 'Madu Gaspar');

-- spUpdateCliJur
DELIMITER $$
	create procedure spautCliJur(
    vidCli smallint,
    vnomCli varchar(100),
    vcelCli int,
    vemailCli varchar(125),
	vsenhaCli varchar(260),
    vCEP int(13),
    vnumEndCli smallint,
    vcompEndCli varchar(30),
	vCNPJCli int(14),
	vfantaCliJ varchar(100),
    vrepresCliJ varchar(50))
BEGIN
	if not exists (select CEP from tbEndereco where CEP=vCEP) then
		insert into tbEndereco (CEP) values (vCEP);
	end if;
	update tbCliJur set CNPJCli=vCNPJCli, fantaCliJ=vfantaCliJ, represCliJ = vrepresCliJ where idCli=vidCli;

	update tbCliente set nomCli=vnomCli, celCli=vcelCli, emailCli=vemailCli, senhaCli=vsenhaCli, 
	CEP=vCEP, numEndCli=vnumEndCli, compEndCli=vcompEndCli where idCli=vidCli;
END$$

call spautCliJur(5, 'Loud e-sports', '1136570927', 'loud@suporte.com.br', 'senha', '06239487', 124, 'Casa', 463650010, 'LOUD GG', 'Playhard');

-- vwCheckCliFis
create view vwcheckCliJur as select
	tbCliente.idCli as 'ID',
	nomCli as 'Nome', 
    celCli as 'Celular',
    emailCli as 'Email', 
	senhaCli as 'Senha',
    CEP as 'CEP',
    numEndCli as 'Número do endereço', 
    compEndCli as 'Complemento', 
    CNPJCli as 'CNPJ', 
    fantaCliJ as 'Data de nascimento',
    represCliJ as 'Nome do representante'
		from tbCliente 
                inner join tbCliJur on tbCliente.idCli = tbCliJur.idCli;
                
select * from vwcheckCliJur;