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
CREATE PROCEDURE spcadEditIfNotExists(
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

CALL spcadEditIfNotExists("Seguinte", 1137073500, 'contato@seguinte.com.br');
CALL spcadEditIfNotExists("BooKsa", 99999999999, "contato@booksa.com");
CALL spcadEditIfNotExists("Primier", 45944886612, "primier.contato@gmail.com");
CALL spcadEditIfNotExists("Darkside", 1136189809, 'vc@darksidebooks.com');
CALL spcadEditIfNotExists("Intrínseca", 2132067400, 'contato@intrinseca.com.br');

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
CREATE PROCEDURE spcadGenIfNotExists(
	$nomGen varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomGen FROM tbGenero WHERE nomGen = $nomGen) THEN
		INSERT INTO tbGenero(nomGen) 
			VALUES ($nomGen);
	END IF;
END$$

CALL spcadGenIfNotExists("Fantasia");
CALL spcadGenIfNotExists("Fikisão-Cientifika");
CALL spcadGenIfNotExists("Distopia");
CALL spcadGenIfNotExists("Ação e Aventura");
CALL spcadGenIfNotExists("Ficção Policial");
CALL spcadGenIfNotExists("Horror");
CALL spcadGenIfNotExists("Thriller e Suspense");
CALL spcadGenIfNotExists("Ficção Histórica");
CALL spcadGenIfNotExists("Romance");
CALL spcadGenIfNotExists("Ficção feminina");
CALL spcadGenIfNotExists("LGBTQ+");
CALL spcadGenIfNotExists("Ficção Comtemporânea");
CALL spcadGenIfNotExists("Realismo Mágico");
CALL spcadGenIfNotExists("Graphic Novel");
CALL spcadGenIfNotExists("Conto");
CALL spcadGenIfNotExists("Young Adult");
CALL spcadGenIfNotExists("New Adult");
CALL spcadGenIfNotExists("Infantil");
CALL spcadGenIfNotExists("Memórias e Autobiografia");
CALL spcadGenIfNotExists("Biografia");
CALL spcadGenIfNotExists("Gastronomia");
CALL spcadGenIfNotExists("Arte e Fotografia");
CALL spcadGenIfNotExists("Autoajuda");
CALL spcadGenIfNotExists("História");
CALL spcadGenIfNotExists("Viajem");
CALL spcadGenIfNotExists("Crimes Reais");
CALL spcadGenIfNotExists("Humor");
CALL spcadGenIfNotExists("Ensaios");
CALL spcadGenIfNotExists("Guias");
CALL spcadGenIfNotExists("Religião e Espiritualidade");
CALL spcadGenIfNotExists("Humanidades e Ciências Sociais");
CALL spcadGenIfNotExists("Paternidade e Família");

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
CREATE PROCEDURE spcadAutIfNotExists(
	$nomAut varchar(30)
)
BEGIN
	IF NOT EXISTS (SELECT nomAut FROM tbAutor WHERE nomAut = $nomAut) THEN
		INSERT INTO tbAutor(nomAut) 
			VALUES ($nomAut);
	END IF;
END$$

CALL spcadAutIfNotExists("Ozcar Wailde");
CALL spcadAutIfNotExists("Lucy Foley");
CALL spcadAutIfNotExists("Mary Shelley");

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
CREATE PROCEDURE spcadLivIfNotExists(
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

call spcadLivIfNotExists('O Retratat-Darkside',
'https://darkside.vteximg.com.br/arquivos/ids/176889-519-519/o-retrato-de-dorian-gray-0.png?v=637655004666100000',200,30.00,9786555980004,
'O Retrato de Dorian Gray', 'The Picture of Dorian Gray',
'Único romance de Oscar Wilde, O Retrato de Dorian Gray combina o apuro literário e estético de seu autor com uma trama sombria, 
pontuada por paixões, crimes e a brilhante e sarcástica verve wildeana. Publicado em 1890 na revista norte-americana Lippincott’s, 
o romance foi relançado em livro um ano depois em uma edição que censurou diversos trechos da obra. Dorian Gray primeiramente ofendeu 
uma geração vitoriana que encontrou na relação entre os amigos Dorian, o jovem retratado, Basil, o pintor apaixonado, e Henry, o lorde 
cínico, “o amor que não ousava dizer o seu nome”. Depois, fascinou leitores, críticos e artistas, que viram no enredo que remete ao mito 
de Fausto o Evangelho de um decadentismo que acredita em uma vida de arte, prazer e fascínio sensorial. Tudo isso em meio a um fim de 
século no qual a convenção e a moralidade corroíam qualquer prazer que a existência humana poderia desfrutar.',1,320,1,2021,1,4,9);

call spcadLivIfNotExists('Frankenste-Darkside','link',300,40.00,'9869387875698','Frankenstein',null,'Sinopse',1,283,2,1991,3,4,7);