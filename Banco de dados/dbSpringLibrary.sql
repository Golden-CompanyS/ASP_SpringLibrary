/* PADRONIZAÇÃO PARA EVITAR INCOERÊNCIAS ENTRE AS APLICAÇÕES
	TABELAS		: tb<NomeDaTabela> ...
	COLUNAS		: <nomeDaColuna><AbrevicaoDoNomeDaTabela> ...
    PROCEDURES	: sp<nomeDaProcedure>(...);
    VARIÁVEIS	: $<nomeDaVariavel>
    
    !! ATENTAR-SE AO CAPSLOCK !!
*/

SET SQL_SAFE_UPDATES = 0;
SET FOREIGN_KEY_CHECKS=0;

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
call spcadEdit('Arqueiro', 1134560987, 'arqueiro@contato.com.br');

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
CALL spcadAut('Lucinda Riley');

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
-- == -- == -- == -- Livro -- == -- == -- == -- == --
-- =============================================== --
CREATE TABLE tbLivro (
    ISBNLiv CHAR(13) PRIMARY KEY,
    titLivro VARCHAR(100) NOT NULL,
    titOriLiv VARCHAR(100),
    sinopLiv VARCHAR(1500) NOT NULL,
    imgLiv VARCHAR(500) NOT NULL,
	pratLiv SMALLINT NOT NULL,
	numPagLiv SMALLINT NOT NULL,
    numEdicaoLiv SMALLINT NOT NULL,
    anoLiv SMALLINT NOT NULL,
    precoLiv FLOAT(10,2) NOT NULL,
    qtdLiv INT DEFAULT(0),
    idEdit INT NOT NULL,
    FOREIGN KEY (idEdit)
        REFERENCES tbEditora (idEdit),
    idGen INT NOT NULL,
    FOREIGN KEY (idGen)
        REFERENCES tbGenero (idGen)
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
	$ISBNLiv char(13),
	$titLivro varchar(100),
	$titOriLiv varchar(100), 
	$sinopLiv varchar(1500), 
    $imgLiv varchar(500),
	$pratLiv smallint, 
	$numPagLiv smallint, 
	$numEdicaoLiv smallint, 
	$anoLiv smallint, 
    $precoLiv float(10,2),
    $qtdLiv int,
    $idAut int, 
	$idEdit int, 
	$idGen int
)
BEGIN
	IF NOT EXISTS (SELECT ISBNLiv FROM tbLivro WHERE ISBNLiv = $ISBNLiv) THEN
		INSERT INTO tbLivro VALUES
        ($ISBNLiv, $titLivro, $titOriLiv, $sinopLiv, $imgLiv, $pratLiv, $numPagLiv, $numEdicaoLiv, $anoLiv, $precoLiv, $qtdLiv, $idEdit, $idGen);
	END IF;
    IF NOT EXISTS (SELECT ISBNLiv FROM tbLivroAutor WHERE idAut = $idAut) THEN
        INSERT INTO tbLivroAutor
			VALUES ($ISBNLiv,$idAut);
	END IF;
END$$

call spcadLiv(
9786555980004,
'O Retrato de Dorian Gray', 'The Picture of Dorian Gray',
'Único romance de Oscar Wilde, O Retrato de Dorian Gray combina o apuro literário e estético de seu autor com uma trama sombria, 
pontuada por paixões, crimes e a brilhante e sarcástica verve wildeana. Publicado em 1890 na revista norte-americana Lippincott’s, 
o romance foi relançado em livro um ano depois em uma edição que censurou diversos trechos da obra. Dorian Gray primeiramente ofendeu 
uma geração vitoriana que encontrou na relação entre os amigos Dorian, o jovem retratado, Basil, o pintor apaixonado, e Henry, o lorde 
cínico, “o amor que não ousava dizer o seu nome”. Depois, fascinou leitores, críticos e artistas, que viram no enredo que remete ao mito 
de Fausto o Evangelho de um decadentismo que acredita em uma vida de arte, prazer e fascínio sensorial. Tudo isso em meio a um fim de 
século no qual a convenção e a moralidade corroíam qualquer prazer que a existência humana poderia desfrutar.',
'https://darkside.vteximg.com.br/arquivos/ids/176889-519-519/o-retrato-de-dorian-gray-0.png?v=637655004666100000',1,320,1,2021,30.00,200,
1,4,9);
call spcadLiv('9788594540188','Frankenstin',null,'Sinopse','linkImg',1,283,2,1991,39.99,300,3,4,7);
call spcadLiv('9788594540188','Frankenstin',null,'Sinopse','linkImg',1,283,2,1991,39.99,300,2,4,7);
-- Adicionando duas autoras em um livro;
call spCadLiv('9786555652956','Morte no internato','The Murders at Fleat House',
'Obra inédita da aclamada Lucinda Riley, Morte no internato é um romance policial com uma 
trama instigante e a escrita envolvente que se tornaram marca registrada da autora.',
'https://www.editoraarqueiro.com.br/media/livros_livro/9786555652956.png.200x300_q85_upscale.jpg',
4,384,1,2022,39.99,29,4,6,7);

DELIMITER $$
create procedure spaltLivro(
	$ISBNLiv char(13),
	$titLivro varchar(100),
	$titOriLiv varchar(100), 
	$sinopLiv varchar(1500), 
    $imgLiv varchar(500),
	$pratLiv smallint, 
	$numPagLiv smallint, 
	$numEdicaoLiv smallint, 
	$anoLiv smallint, 
    $precoLiv float(10,2),
    $qtdLiv int,
	$idAut int, 
	$idEdit int, 
	$idGen int)
	BEGIN
		UPDATE tbLivro SET
			titLivro = $titLivro, titOriLiv = $titOriLiv, sinopLiv = $sinopLiv, imgLiv = $imgLiv, pratLiv = $pratLiv,
            numPagLiv = $numPagLiv, numEdicaoLiv = $numEdicaoLiv, anoLiv = $anoLiv, precoLiv = $precoLiv, qtdLiv = $qtdLiv
            WHERE (ISBNLiv = $ISBNLiv);
		IF EXISTS(SELECT idAut FROM tbLivroAutor WHERE ISBNLiv = $ISBNLiv AND idAut = $idAut) THEN
			DELETE FROM tbLivroAutor WHERE(idAut = $idAut AND ISBNLiv = $ISBNLiv);
        ELSE
			INSERT INTO tbLivroAutor VALUES($ISBNLiv, $idAut);
        END IF;
    END
$$

call spaltLivro('9788594540188','Frankenstein',null,'Sinopse','linkImg',1,283,2,1991,39.99,300,2,4,7);
-- Retificando o nome do livro e retirando/recolocando a autora de ID 2

-- vwcheckAllLiv
create view vwcheckAllLiv as select
	lv.ISBNLiv as 'ISBN',
	titLivro as 'Título', 
    titOriLiv as 'Título original',
    sinopLiv as 'Sinopse',
    imgLiv as 'Link da imagem da capa',
    pratLiv as 'Prateleira',
    numPagLiv as 'Número de páginas',
    numEdicaoLiv as 'Número da edição',
    anoLiv as 'Ano de publicação',
	precoLiv as 'Preço',
    qtdLiv as 'Quantidade no estoque',
    nomGen as 'Gênero do livro',
	nomEdit as 'Nome da editora',
    celEdit as 'Telefone da editora',
    emailEdit as 'Email da editora'
    from tbLivro as lv
			inner join tbGenero as gen on lv.IdGen = gen.IdGen
            inner join tbEditora as edit on lv.IdEdit = edit.IdEdit;
            
select * from vwcheckAllLiv;

-- vwcheckAllAutInLiv - Ver livros e todos os seus autores
create view vwcheckAllAutInLiv as select
	lv.ISBNLiv as 'ISBN',
	titLivro as 'Título', 
	nomAut as 'Nome do autor'
    from tbAutor as aut
            inner join tbLivroAutor as lva on aut.idAut = lva.idAut
            inner join tbLivro as lv on lva.ISBNLiv = lv.ISBNLiv

select * from vwcheckAllAutInLiv;


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
/* Como a tabela tbLivroAutor é composta por foreign keys, FOREIGN_KEY_CHECKS deve ser
mudado para 0, desativando proibição quanto à alteração/exclusão destas */


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
	$nomCli varchar(100),
	$celCli varchar(11),
	$emailCli varchar(125),
	$senhaCli varchar(260),
	$CEP varchar(13),
	$numEndCli smallint,
	$compEndCli varchar(30),
	$CPFCli int,
	$dtNascCliF date)
begin
	if not exists (select CPFCli from tbCliFis where CPFCli = $CPFCli) then
		if not exists (select CEP from tbEndereco where CEP=$CEP) then
			insert into tbEndereco (CEP) values ($CEP);
		end if;
    	insert into tbCliente (nomCli, tipoCli, celCli, emailCli, senhaCli, CEP, numEndCli, compEndCli) values 
			 ($nomCli, false, $celCli, $emailCli, $senhaCli, $CEP, $numEndCli, $compEndCli);
		insert into tbCliFis (CPFCli, idCli, dtNascCliF) values
			($CPFCli, (select idCli from tbCliente order by idCli desc limit 1), $dtNascCliF);
    end if;
end $$

call spcadCliFis('Jesus Youssef', '1199209832', 'jesuscristo@gmail.com', 'senha', 06300187, 33, 'Casa', 459822213, '1990-12-25');
call spcadCliFis('Gabriel Bohm Santos', '1199209882', 'kamikat@gmail.com', 'senha', 06309687, 34, 'Casa', 459722213, '1996-04-02');
call spcadCliFis('Bianca Lula', '1199309833', 'thaigaloud@gmail.com', 'senha', 06200087, 22, 'Casa', 459893116, '1996-01-03');
call spcadCliFis('Thiago Sartori', '1199340822', 'tinownsthiago@gmail.com', 'senha', 06200087, 22, 'Casa', 459873176, '1999-05-06');

-- spUpdateCliFis
DELIMITER $$
create procedure spaltCliFis(
	$idCli smallint,
	$nomCli varchar(100),
	$celCli varchar(11),
	$emailCli varchar(125),
	$senhaCli varchar(260),
	$CEP varchar(13),
	$numEndCli smallint,
	$compEndCli varchar(30),
	$CPFCli int,
	$dtNascCliF date)
BEGIN
	if not exists (select CEP from tbEndereco where CEP=$CEP) then
		insert into tbEndereco (CEP) values ($CEP);
	end if;
	update tbCliFis set CPFCli=$CPFCli, dtNascCliF=$dtNascCliF where idCli=$idCli;
	update tbCliente set nomCli=$nomCli, celCli=$celCli, emailCli=$emailCli, senhaCli=$senhaCli, 
	CEP=$CEP, numEndCli=$numEndCli, compEndCli=$compEndCli where idCli=$idCli;
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
	$nomCli varchar(100),
	$celCli varchar(11),
	$emailCli varchar(125),
	$senhaCli varchar(260),
	$CEP varchar(13),
	$numEndCli smallint,
	$compEndCli varchar(30),
	$CNPJCli int(14),
	$fantaCliJ varchar(100),
	$represCliJ varchar(50))
begin
	if not exists (select CNPJCli from tbCliJur where CNPJCli = $CNPJCli) then
		if not exists (select CEP from tbEndereco where CEP=$CEP) then
			insert into tbEndereco (CEP) values ($CEP);
		end if;
    	insert into tbCliente (nomCli, tipoCli, celCli, emailCli, senhaCli, numEndCli, CEP, compEndCli) values 
			($nomCli, true, $celCli, $emailCli, $senhaCli, $numEndCli, $CEP, $compEndCli);
		insert into tbCliJur (CNPJCli, idCli, fantaCliJ, represCliJ) values
			($CNPJCli, (select idCli from tbCliente order by idCli desc limit 1), $fantaCliJ,  $represCliJ);
    end if;
end $$

call spcadCliJur('Loud', '1136570927', 'loud@suporte.com.br', 'senha', '06210027', 10, 'Bloco 10', 463650010, 'LOUD GG', 'Thaiga');
call spcadCliJur
('Jornal BG News', '11958424397', 'bgnews@gmail.com', 'senha', '05089000', 678 , null, 233980686, 'MIDIAS BGNEWS', 'Madu Gaspar');

-- spUpdateCliJur
DELIMITER $$
	create procedure spautCliJur(
    $idCli smallint,
    $nomCli varchar(100),
    $celCli int,
    $emailCli varchar(125),
	$senhaCli varchar(260),
    $CEP int(13),
    $numEndCli smallint,
    $compEndCli varchar(30),
	$CNPJCli int(14),
	$fantaCliJ varchar(100),
    $represCliJ varchar(50))
BEGIN
	if not exists (select CEP from tbEndereco where CEP=$CEP) then
		insert into tbEndereco (CEP) values ($CEP);
	end if;
	update tbCliJur set CNPJCli=$CNPJCli, fantaCliJ=$fantaCliJ, represCliJ = $represCliJ where idCli=$idCli;

	update tbCliente set nomCli=$nomCli, celCli=$celCli, emailCli=$emailCli, senhaCli=$senhaCli, 
	CEP=$CEP, numEndCli=$numEndCli, compEndCli=$compEndCli where idCli=$idCli;
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


-- =============================================== --
-- == -- == -- == -- Funcionário -- == -- == -- == -- 
-- =============================================== --
create table tbFuncionario(
	idFunc int primary key auto_increment,
    nomFunc varchar(50) not null,
    CPFFunc int(11) not null,
    imgFunc varchar(256),
	cargoFunc varchar(30) not null,
    celFunc varchar(11) not null,
    emailFunc varchar(125) not null,
    senhaFunc varchar(260) not null
);

DELIMITER $$
create procedure spcadFunc(
	$nomFunc varchar(50),
	$CPFFunc int(11),
	$imgFunc varchar(256),
	$cargoFunc varchar(30),
	$celFunc varchar(11),
	$emailFunc varchar(125),
	$senhaFunc varchar(260))
BEGIN
	insert into tbFuncionario (nomFunc, CPFFunc, imgFunc, cargoFunc, celFunc, emailFunc, senhaFunc)
    values ($NomFunc, $CPFFunc, $imgFunc, $cargoFunc, $celFunc, $emailFunc, $senhaFunc);
END $$

call spcadFunc("Leticia", 1234567, "let.png", 'Gerente', 11987643239, "leticiaresina@email.com", "1234567");
call spcadFunc("Larissa", 3458759, "lari.png", 'Gerente', 11987643819, "larii@email.com", "1234567");
call spcadFunc("Gustavo", 4838712, "gus.png", 'Bibliotecário', 11958694851, "pearGus@email.com", "1234567");
call spcadFunc("Taveira", 3259382, "tavs.png", 'Logístico', 11987642312, "taveira.mateus@email.com", "1234567");
call spcadFunc("Erin", 1231382, "eri.png", 'Logístico', 11987643819, "eriin@email.com", "1234567");
call spcadFunc("Wesley", 232382, "wes.png", 'Caixa', 11987643819, "wes@email.com", "1234567");

-- spaltFunc
DELIMITER $$
create procedure spaltFunc(
    $idFunc int,
    $nomFunc varchar(50),
    $CPFFunc int,
    $imgFunc varchar(256),
    $cargoFunc varchar(30),
    $celFunc varchar(11),
    $emailFunc varchar(125),
    $senhaFunc varchar(260))
    BEGIN
         update tbFuncionario set nomFunc=$nomFunc, CPFFunc=$CPFFunc, imgFunc=$imgFunc, 
         cargoFunc=$cargoFunc, celFunc=$celFunc, emailFunc=$emailFunc, senhaFunc=$senhaFunc where idFunc=$idFunc;
    END
$$

call spaltFunc(3, "Gus", 4838712, "gus.png", 'Bibliotecário', 11958694851, "novoEmaildoGus@email.com", "1234567");
call spaltFunc(5, "Erin", 1231382, "eri.png", 'Bibliotecário', 11987643819, "eriin@email.com", "1234567");

-- checkFuncById
DELIMITER $$
CREATE PROCEDURE checkFuncById(
	$idFunc int
)
BEGIN
	SELECT * FROM tbFuncionario WHERE idFunc = $idFunc;
END$$

call checkFuncById(3);

-- vwCheckAllFuncs
create view vwCheckAllFuncs as select 
	IdFunc as 'ID', 
    nomFunc as 'Nome',
    CPFFunc as 'CPF',
    imgFunc as 'Imagem',
    celFunc 'Telefone Celular',
	cargoFunc as 'Cargo',
    emailFunc as 'Email',
    senhaFunc as 'Senha'
		from tbFuncionario;

select * from vwCheckAllFuncs;


-- =============================================== --
-- == -- == -- == -- Venda -- == -- == -- == -- ==
-- =============================================== --

create table tbVenda(
	idVen int primary key auto_increment,
    valTotVen float(10,2),
    delivVen boolean not null,
    dtHoraVen datetime default(current_timestamp()),
    tipoPgtVen varchar(20) not null,
    idFunc int not null,
    foreign key (idFunc) references tbFuncionario(idFunc),
    IdCli int not null,
    foreign key (idCli) references tbCliente(idCli)
);

-- Tabela intermediária necessária para representar itens de uma venda
create table tbItemVenda(
    ISBNLiv char(13) not null,
	idVen int not null,
    qtdIV int not null,
    valTotIV float(10,2) not null,
    foreign key (ISBNLiv) references tbLivro(ISBNLiv),
    foreign key (idVen) references tbVenda(idVen)
);

create table tbDelivery(
	idDel int primary key auto_increment,
    idVen int not null,
    foreign key (idVen) references tbVenda (idVen),
    statDel boolean not null,
    dtPrevDel date not null,
    dtFinDel datetime
);

-- traltEstoqueLiv - Altera o estoque de livros com base no que foi vendido
DELIMITER $$
	create trigger traltEstoqueLiv before insert 
    on tbItemVenda for each row
    BEGIN
		update tbLivro set qtdLiv = old.qtdLiv - new.qtdIV
			where ISBNLiv = new.ISBNLiv;
    END
$$

-- spcomecVenda - Abre a venda.
DELIMITER $$
create procedure spcomecVenda(
    $tipoPgtVen varchar(20), 
    $idCli int,
    $idFunc int,
    $delivVen boolean,
    $dtPrevDel date)
begin
	insert into tbVenda (valTotVen, delivVen, dtHoraVen, tipoPgtVen, idFunc, idCli) values
		(null, $delivVen, default, $tipoPgtVen, $idFunc, $idCli);
	if $delivVen = true then
		insert into tbDelivery(idVen, statDel, dtPrevDel, dtFinDel) values
			((select idVen from tbVenda order by idVen desc limit 1), 0, $dtPrevDel, null);
		end if;
end$$

-- spputLivVenda - Coloca livros numa venda.
DELIMITER $$
create procedure spputLivVenda(
	$idVen int,
	$ISBNLiv char(13),
    $qtdIV int)
begin
	if not exists (select ISBNLiv from tbItemVenda where ISBNLiv = $ISBNLiv and idVen = $idVen) then
		insert into tbItemVenda values
			($ISBNLiv, $idVen, $qtdIV,
			(select precoLiv * $qtdIV from tbLivro where (ISBNLiv = $ISBNLiv)));
	else
		update tbItemVenda set qtdIV = qtdIV + $qtdIV,
			valTotIV = (select precoLiv * $qtdIV + valTotIV from tbLivro where (ISBNLiv = $ISBNLiv)) 
        where (ISBNLiv = $ISBNLiv and idVen = $idVen);
	end if;
    
	update tbVenda
		set valTotVen = 
        (select sum(valTotIV) from tbItemVenda where
				(idVen = $idVen))
		where idVen = $idVen;
end $$

-- spdelLivVenda - Retira livros de uma venda.
DELIMITER $$
create procedure spdelLivVenda(
	$idVen int,
	$ISBNLiv char(13))
begin
	if exists (select ISBNLiv from tbItemVenda where ISBNLiv = $ISBNLiv and idVen = $idVen) then
		delete from tbItemVenda where idVen = $idVen and ISBNLiv = $ISBNLiv;
	end if;
    
	update tbVenda
		set valTotVen = 
        (select sum(valTotIV) from tbItemVenda where
				(idVen = $idVen))
		where idVen = $idVen;
end $$

-- spaltStatusDeliv - Altera o status do delivery
DELIMITER $$
create procedure spaltStatusDeliv(
	$idDel int,
	$statDel tinyint(1))
begin
	if $statDel = 2 then
		update tbDelivery set statDel = $statDel, dtFinDel = current_timestamp where idDel = $idDel;
	else
		update tbDelivery set statDel = $statDel where idDel = $idDel;
    end if;
end $$

/* Abrindo vendas, colocando, tirando produtos e alterando o status de delivery delas
---=== SEMPRE SETAR SET FOREIGN_KEY_CHECKS=0 ANTES DE RODAR OS TESTES ===---*/
call spcomecVenda("Dinheiro", 1, 3, false, null);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555652956",1);

call spcomecVenda("Transferência", 2, 3, true, '2022-10-24');
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555652956",1);
call spaltStatusDeliv((select idDel from tbDelivery order by idVen desc limit 1),2)

call spcomecVenda("Crédito", 3, 6, true, '2022-10-26');
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spdelLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004");
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9788594540188",1);
call spaltStatusDeliv((select idDel from tbDelivery order by idVen desc limit 1),1);

-- vwcheckAllVenda - Ver todas as vendas
create view vwcheckAllVenda as select 
	idVen as 'ID',
    dtHoraVen as 'Data e hora',
	tbCliente.NomCli as 'Nome do cliente',
    tbFuncionario.NomFunc as 'Funcionário responsável',
    tipoPgtVen as 'Situação de pagamento', 
    valTotVen as 'Valor total',
	delivVen as 'É Delivery?'
		From tbVenda
			inner join tbFuncionario on tbVenda.idFunc = tbFuncionario.idFunc
            inner join tbCliente on tbVenda.idCli = tbCliente.idCli;
     
select * from vwcheckAllVenda;

-- spcheckAllItemVenda - Ver todas os itens de uma venda
DELIMITER $$
create procedure spcheckAllItemVenda($idVen int)
begin
	select 
	tbVenda.idVen as 'ID da venda',
	tbVenda.idVen as 'ID do produto',
	tbLivro.ISBNLiv as 'ISBN',
	tbLivro.titLivro as 'Título',
    tbLivro.precoLiv as 'Preço unitário',
    tbItemVenda.qtdIV as 'Quantidade',
    tbItemVenda.valTotIV as 'Preço'
		from tbVenda
			inner join tbItemVenda on tbVenda.idVen = tbItemVenda.idVen
            inner join tbLivro on tbItemVenda.ISBNLiv = tbLivro.ISBNLiv
		where(tbVenda.idVen = $idVen);
end$$
     
call spcheckAllItemVenda(2);

-- vwcheckAllDeliv - Ver todas as vendas com delivery e sua situação
create view vwcheckAllDeliv as select 
	tbVenda.idVen as 'ID',
    dtHoraVen as 'Data e hora',
	tbCliente.NomCli as 'Nome do cliente',
    tbFuncionario.NomFunc as 'Funcionário responsável',
    tipoPgtVen as 'Situação de pagamento', 
    valTotVen as 'Valor total',
    statDel as 'Status do delivery',
    dtPrevDel as 'Previsão de entrega',
    dtFinDel as 'Data de entrega'
		From tbVenda
			inner join tbFuncionario on tbVenda.idFunc = tbFuncionario.idFunc
            inner join tbCliente on tbVenda.idCli = tbCliente.idCli
            inner join tbDelivery on tbVenda.idVen = tbDelivery.idVen;
            
select * from vwcheckAllDeliv;