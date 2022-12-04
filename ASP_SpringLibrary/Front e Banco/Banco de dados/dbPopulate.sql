/* CÓDIGO PARA CORRIGIR ERRO NA INSERÇÃO DE EDITORAS SEM TELEFONE E EMAIL, MANTENDO O BANCO
alter table tbEditora
modify celEdit char(11);

alter table tbEditora
modify emailEdit varchar(50);
*/

/* tbEditora */
CALL spcadEdit("Seguinte", 1137073500, 'contato@seguinte.com.br');
CALL spcadEdit("BooKsa", 99999999999, "contato@booksa.com");
CALL spcadEdit("Primier", 45944886612, "primier.contato@gmail.com");
CALL spcadEdit("Darkside", 1136189809, 'vc@darksidebooks.com');
CALL spcadEdit("Intrínseca", 2132067400, 'contato@intrinseca.com.br');
CALL spcadEdit('Arqueiro', 1134560987, 'arqueiro@contato.com.br');
CALL spcadEdit('Harper Collins', 1124684221, 'vendas@harpercollins.com.br');
CALL spcadEdit('Faro Editorial', 1142080868, 'contato@faroeditorial.com.br');
CALL spcadEdit('Grupo C. das Letras - Suma', 2139937510, 'site@companhiadasletras.com.br');
CALL spcadEdit('Grupo Record - BestBolso', null, 'sac@record.com.br');
CALL spcadEdit('Grupo Record - Galera', null, 'sac@record.com.br');
CALL spcadEdit('Penguin', null, 'consumerservices@penguinrandomhouse.com');
CALL spcadEdit('Thomas Nelson', null, 'vendas@thomasnelson.com.br');
CALL spcadEdit('Grupo Record - Verus', null, 'sac@record.com.br');
CALL spcadEdit('Grupo Record - Bestseller', null, 'sac@record.com.br');
CALL spcadEdit('Astral Cultural', null, 'sac@astral.com.br');
CALL spcadEdit('Grupo C. das Letras - Paralela', 2139937510, 'site@companhiadasletras.com.br');

CALL spcheckAllEdit();

CALL spaltEdit(3, "Primier", 1137777777, "primier.contato@gmail.com");

CALL spcheckEditById(3);

/* tbGenero */
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

CALL spcheckAllGen();

CALL spaltGen(2, "Ficção Científica");

CALL spcheckGenById(2);

/* tbAutor */
CALL spcadAut("Ozcar Wailde");
CALL spcadAut("Lucy Foley");
CALL spcadAut("Mary Shelley");
CALL spcadAut('Lucinda Riley');
CALL spcadAut('C. S. Lewis');
CALL spcadAut('Augusto Alvarenga');
CALL spcadAut('Vinícius Grossos');
CALL spcadAut('Daniel Glattauer');
CALL spcadAut('Sophie Kinsella');
CALL spcadAut('Elayne Baeta');
CALL spcadAut('Sue Townsend');
CALL spcadAut('Tina Andrews');
CALL spcadAut('Sabaa Tahir');
CALL spcadAut('Viola Davis');
CALL spcadAut('Adam Silvera');
CALL spcadAut('Maya Eigenmann');
CALL spcadAut('Lia Louis');

CALL spcheckAllAut();

CALL spaltAut(1, "Oscar Wilde");

CALL spcheckAutById(1);

CALL spcadFunc("Leticia", "12345670325", "/Photos/imgFunc/d61d8a0b25028f787123bfff542d3051.png", "11987643239", 'Gerente', "leticiaresina@email.com", "$2a$10$UdE/dABUzjWipHLkC9cy8.TewWva7vGkon0zl1yKrej8.n0Uqz9CO", true);
CALL spcadFunc("Larissa", "34587595128", "/Photos/imgFunc/b96eee05bcc624dfa15a61c5c62e47cb.png", "11987643819", 'Gerente', "larii@email.com", "$2a$10$cVTPmbucXk6J5zC4plf5uOW/nwfbQNCUCpQ/hxl/Eh1KRt.mlCswC", true);
CALL spcadFunc("Gus", "48387121847", "/Photos/imgFunc/3ea38e723c590aabf186367e1eb7e6a1.png", "11958694851", 'Bibliotecário', "pearGus@email.com", "$2a$10$b7goyg40iN95uw9PKMtX2.700UGqpfpHs6V3L5feaI.Q2QAks09xa", true);
CALL spcadFunc("Taveira", "32593825201", "/Photos/imgFunc/e2bb3f9679fec6d4836fcf8abcc3eeac.png", "11987642312", 'Logístico', "taveira.mateus@email.com", "$2a$10$L169gxfwclPif1x6nh8qP.Sxwny6Q5DAtgRMqAe9oSR/1xhVdDUhO", true);
CALL spcadFunc("Erin", "12313821561", "/Photos/imgFunc/96a033ac6a432dcf1e701c9febfe4687.png", "11987643819", 'Logístico', "eriin@email.com", "$2a$10$uvkAzdQ/8aSmhSq7vMjj1up7fKx6yLSuzcWShGcNtlInU7LlHOdz.", true);
CALL spcadFunc("Wesley", "23238210228", "/Photos/imgFunc/b23f665210a1914cab61bc8eba4c9ae0.png", "11987643819", 'Caixa', "wes@email.com", "$2a$10$YP2EW/RL4nNsmcksie454.7r/K6wqAraDMhC5wTkoSm2byQo/Q6zW", true);

CALL spaltFunc(3, "Gustavo", "48387121847", "/Photos/imgFunc/3ea38e723c590aabf186367e1eb7e6a1.png", "11958694851", 'Bibliotecário', "novoEmaildoGus@email.com", "$2a$10$b7goyg40iN95uw9PKMtX2.700UGqpfpHs6V3L5feaI.Q2QAks09xa", true);
CALL spaltFunc(5, "Erin", "12313821561", "/Photos/imgFunc/96a033ac6a432dcf1e701c9febfe4687.png", "11987643819", 'Bibliotecário', "eriin@email.com", "$2a$10$uvkAzdQ/8aSmhSq7vMjj1up7fKx6yLSuzcWShGcNtlInU7LlHOdz.", true);

CALL checkFuncById(3);

SELECT * FROM vwCheckAllFuncs;

/* tbLivro */
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
	'https://darkside.vteximg.com.br/arquivos/ids/176889-519-519/o-retrato-de-dorian-gray-0.png?v=637655004666100000',
    1,320,1,2021,30.00,200,true,4,9, 1
);
call spinsertAutLiv(9786555980004, 1);

call spcadLiv('9788594540188','Frankenstin',null,'Sinopse','linkImg',1,283,2,1991,39.99,300,true,4,7, 2);
call spinsertAutLiv(9788594540188, 2);
call spinsertAutLiv(9788594540188, 3);

call spCadLiv('8579606179', 
		'Coleção Turma dos Vegetais: Batata', 
        'Coleção Turma dos Vegetais: Batata',
        'Como foram os ingleses os grandes responsáveis 
        pela difusão do consumo da batata, por muito tempo,
        no Brasil, ela foi chamada de batata inglesa. Depois ficou somente batata, 
        com o adjetivo "doce" diferenciando a outra espécie. Na versão tradicional ou doce, 
        a batata está presente na lista dos alimentos mais consumidos no mundo, graças à sua versatilidade.
        Frita, assada, cozida ou até crua, ela é encontrada em uma imensa variedade de pratos. Neste livro,
        você vai conhecer mais sobre suas propriedades e como preparar 18 deliciosas receitas com esse versátil alimento.',
        'https://m.media-amazon.com/images/I/51x1JKl5eEL._SY477_BO1,204,203,200_.jpg',
        100, 52, 1, 2022, 11.90, 29, true, 6, 8, 2);

call spCadLiv('8579606217',
		'Coleção Turma dos Vegetais: Brócolis',
		'Coleção Turma dos Vegetais: Brócolis',
        'Brócolis: Ele ficou famoso na Europa durante os anos do Império Romano. Porém, de lá para cá, 
        muitas descobertas foram feitas e ele caiu no gosto popular. Além de muito saboroso, consumir
        brócolis frescos e naturais com frequência blinda a saúde contra diversas doenças.
        Membro da numerosa família das Brassicas, esta hortaliça é uma das melhores fontes 
        de cálcio, que dá aquela proteção básica para os ossos. Fonte de vitamina C, 
        ele também melhora o sistema imunológico. Mas nada se compara ao seu poder de proteção
        contra o câncer, principalmente os casos em que a doença atinge pulmão, próstata ou bexiga. 
        Conheça mais sobre suas propriedades e como preparar 18 deliciosas receitas com esse poderoso alimento.',
        'https://m.media-amazon.com/images/I/51u8f9mLrfL._SY476_BO1,204,203,200_.jpg',
        100, 34, 4, 2022, 10.30, 152, true, 3, 5, 1);

call spCadLiv('6586019117',
'Coleção Turma dos Vegetais: Abobrinha',
'Coleção Turma dos Vegetais: Abobrinha',
'Rica em água e fibra, dois compostos que ajudam a digestão reduzindo o risco de constipação
 e vários distúrbios intestinais, a abobrinha é excelente para diabéticos. E por ser um alimento de
 baixa caloria, ajuda na saciedade, o que contribuir para a perda de peso a longo prazo. Além das fibras,
 por também conter potássio, ela diminui a pressão sanguínea, o colesterol e outros fatores de risco para doenças cardíacas.',
'https://m.media-amazon.com/images/I/51g9oDfHTyL._SY477_BO1,204,203,200_.jpg',
100, 30, 4, 2000, 9.90, 26, true, 4, 2, 5);

call spCadLiv(
	'9786555652956',
    'Morte no internato','The Murders at Fleat House',
	'Obra inédita da aclamada Lucinda Riley, Morte no internato é um romance policial com uma 
	trama instigante e a escrita envolvente que se tornaram marca registrada da autora.',
	'https://www.editoraarqueiro.com.br/media/livros_livro/9786555652956.png.200x300_q85_upscale.jpg',
	4,384,1,2022,39.99,29,true,6,7, 2
);
call spinsertAutLiv(9786555652956, 4);

call spCadLiv(
	'9780064471046',
    'The Lion, the Witch and the Wardrobe',null,
	"Four adventurous siblings—Peter, Susan, Edmund, and Lucy Pevensie—step through a wardrobe door and into the land of Narnia, a land frozen in eternal winter and enslaved by the power of the White Witch. But when almost all hope is lost, the return of the Great Lion, Aslan, signals a great change . . . and a great sacrifice. The Lion, the Witch and the Wardrobe is the second book in C. S. Lewis's classic fantasy series, which has been drawing readers of all ages into a magical land with unforgettable characters for over sixty years. This is a stand-alone read, but if you would like to explore more of the Narnian realm, pick up The Horse and His Boy, the third book in The Chronicles of Narnia.",
	'https://m.media-amazon.com/images/I/51sQcUYpM9L.jpg',
	5,224,1,2002,50.70,49,true,7,1,2);
call spinsertAutLiv(9780064471046, 5);

call spCadLiv(
	'8562409693',
    '1+1: A matemática do amor',null,
	"Lucas e Bernardo são dois garotos, melhores amigos um do outro. De repente, recebem a notícia de que Bernardo irá se mudar com a família para outro país. E percebem que não querem perder a valiosa amizade... Lucas tenta transformar cada dia que resta com o amigo na melhor experiência de suas vidas: escreve uma lista de coisas para fazer epretende cumprir uma por uma, em todos os detalhes. Então os meninos percebem que há algo mais forte entre eles... Um sentimento profundo, que não conseguem explicar e que torna todas aquelas experiências ainda mais intensas. Mas o que fazer com tudo isso quando se tem apenas 16 anos?",
	'https://m.media-amazon.com/images/I/81R3A6H34VL.jpg',
	4,256,1,2016,30.90,200,true,8,11,6);
call spinsertAutLiv(8562409693, 6);
call spinsertAutLiv(8562409693, 7);

call spCadLiv(
	'8581051243',
    '@mor','Gut gegen Nordwind',
	"Num e-mail enviado por engano, começa um relacionamento virtual que testa as convicções de Leo Leike e Emmi Rothner. Leo Leike, ainda digerindo o fracasso de seu último relacionamento, responde de forma espirituosa a duas mensagens enviadas por engano por Emmi Rothner, casada. Inicialmente, ela só queria cancelar uma assinatura de revista. Depois, inclui Leo por engano entre os destinatários de um e-mail de boas festas. Na terceira troca de e-mails, o mal-entendido dá lugar à atração mútua, reforçada pelo fato de um nunca ter visto o outro. Nada como a curiosidade instigada por frases bem encadeadas chegando a intervalos regulares numa caixa postal eletrônica para que os dois se esqueçam dos possíveis impedimentos. A cada dia, Leo e Emmi se sentem mais impelidos a marcarem um encontro. Após trocas contínuas de mensagens, está claro para ambos que o marido dela e as feridas emocionais dele não serão obstáculos para que marquem um encontro. O único obstáculo real é a insegurança de ambos quanto à transformação da fantasia em realidade.",
	'https://m.media-amazon.com/images/I/51xFx2aO9hL.jpg',
	8,188,1,2013,24.90,250,true,9,9,2);
call spinsertAutLiv(8581051243, 8);

call spCadLiv(
	'8581051367',
    'Emmi & Léo','Alle sieben Wellen',
	"Em @mor, o escritor e jornalista austríaco Daniel Glattauer se utiliza dos princípios dos romances epistolares - trocas de cartas - com uma roupagem contemporânea: o contato virtual. Ao contar a fortuita atração mútua entre os jovens Leo Leike e Emmi Rothner por meio de conversas por e-mails e os sentimentos que desenvolvem um pelo outro, o autor utiliza pontos de vista alternados para contar uma inusitada história de amor. Emmi & Leo: a sétima onda é a sequência dessa história tão intrigante quanto inusitada e que surgiu por erro de endereçamento no envio de um email. Na atual etapa, Leo Leike retorna de Boston após uma longa ausência, e é recebido por uma caixa de emails lotada de notícias de Emmi Rothner. O sentimento dos dois não mudou, e eles reiniciam a troca de mensagens. Só que agora Leo está namorando a americana Pamela, e Emmi continua casada. A orgulhosa Emmi e o tímido Leo nunca estiveram tão próximos, e ao mesmo tempo tão distantes. Daniel Glattauer reconquista os leitores e a crítica internacional com seu peculiar olhar sobre as relações amorosas dos tempos atuais. A prova do fenômeno editorial da dupla de romances: @mor e Emmi & Leo foram traduzidos para quarenta idiomas e tiveram 64 montagens teatrais na Alemanha e Áustria.",
	'https://m.media-amazon.com/images/I/41dMWeuNu+L.jpg',
	8,168,1,2013,16.00,250,true,9,9,2);
call spinsertAutLiv(8581051367, 8);

call spCadLiv(
	'8501076740',
    'Samantha Sweet: A executiva do lar','The Undomestic Goddess',
	"Em SAMANTHA SWEET, EXECUTIVA DO LAR, Sophie Kinsella faz uma divertida crítica à pressa ― e às pressões ― da vida moderna. Com ironia e leveza, a autora mostra porque é considerada uma das principais vozes da nova geração literária na terra do velho bardo. Sucesso de público e crítica, a trama já teve os direitos comprados pela Universal.Samantha Sweet está prestes a se tornar sócia da firma de advocacia onde trabalha. Isso se ela não tivesse cometido a maior mancada de sua trajetória profissional. Um erro tão absurdamente grave, que custará à empresa milhões de libras. Completamente baratinada pelo furo, ela surta. Pega o primeiro trem para fora da cidade e vai parar na entrevista de emprego mais equivocada de sua vida. Sua natureza competitiva logo é ativada e ela decide que será contratada, sem se preocupar com o cargo.Assim, nossa heroína ganha um novo plano de carreira: como empregada doméstica de uma socialite deslumbrada. Sem nem ao menos saber como ligar o ferro de passar. Ou para que diabos serve metade dos aparelhos de uma cozinha. Mas talvez ela não seja tão incapaz como doméstica quanto imagina. Talvez, com alguma ajuda, ela possa até fingir. Será que seus patrões descobrirão que sua empregada é de fato uma advogada de alto nível? Será que a antiga vida de Samantha irá alcançá-la? E, mesmo que isso aconteça... será que ela vai a querer de volta? SAMANTHA SWEET, EXECUTIVA DO LAR é a história de uma mulher que precisa diminuir o ritmo. Encontrar-se. Apaixonar-se.",
	'https://m.media-amazon.com/images/I/71NLtDNjP6S.jpg',
	5,512,7,2007,34.49,360,true,10,9,3);
call spinsertAutLiv(8501076740, 9);

call spCadLiv(
	'6559810429',
    'Oxe, baby',null,
	'“Arraste uma cadeira e, se der, me leia”. É assim – despretensiosa, em um convite silencioso mas urgente – que Elayne introduz o leitor a Oxe, baby, seu primeiro livro de poesia. E é também nesse mesmo ritmo que são conduzidas as próximas páginas, em que, entre metáforas com casulos, morcegos e borboletas, a autora conta um pouco de si e de suas experiências como uma menina que ama meninas.

Nascida e criada em Salvador, Elayne Baeta reuniu, ao longo de sua trajetória, alguns arranhões. Mas foram eles – doloridos – que a fizeram apurar seu senso crítico e firmar-se hoje como uma das vozes mais influentes da literatura jovem adulta LGBTQ+ no Brasil, desafiando o conservadorismo, a intolerância e o preconceito que ainda existem no país.

Multifacetada, indo além da escrita, Elayne dedica-se também a podcasts e trabalhos como ilustradora, além de ser uma figura popular nas redes sociais: no auge de seus vinte e poucos anos acumula no Instagram mais de 40 mil seguidores e, no Twitter, 35 mil. Já na literatura, Elayne Baeta faz o que lhe cabe, e concede a personagens e existências por vezes marginalizadas um novo caminho. Uma outra chance.',
	'https://m.media-amazon.com/images/I/71FbbQUcBsL.jpg',
	5,224,3,2021,51.70,98,true,11,11,2);
call spinsertAutLiv(6559810429, 10);

call spCadLiv(
	'0141399643',
    'The Woman who Went to Bed for a Year',null,
	"What happens when a duvet day turns into a duvet year?

Sue Townsend, the bestselling author of the Adrian Mole series, returns with The Woman Who Went to Bed for a Year, a funny and touching novel about what happens when someone stops being the person everyone wants them to be.

The day her twins leave home, Eva climbs into bed and stays there. For seventeen years she's wanted to yell at the world, 'Stop! I want to get off'. Finally, this is her chance.

Her husband Brian, an astronomer having an unsatisfactory affair, is upset. Who will cook his dinner? Eva, he complains, is attention seeking. But word of Eva's defiance spreads.

Legions of fans, believing she is protesting, gather in the street. While Alexander the white van man brings tea, toast and sympathy. And from this odd but comforting place Eva begins to see both herself and the world very, very differently. . .

Bestselling author Sue Townsend has been Britain's favourite comic writer for over three decades.

'Laugh-out-loud . . . a teeming world of characters whose foibles and misunderstandings provide glorious amusement. Something deeper and darker than comedy' Sunday Times",
	'https://m.media-amazon.com/images/I/91+X7tkQd-L.jpg',
	1,464,1,2012,55.62,12,true,12,27,3);
call spinsertAutLiv(0141399643, 11);

call spCadLiv(
	'6555113820',
    'Charlotte Sophia: Um romance','Charlotte Sophia: Myth, Madness, and the Moor',
	"O reinado. A loucura. O segredo.
Antes de se tornar rainha da Inglaterra, Charlotte Sophia de Mecklemburgo-Strelitz era princesa da Alemanha. Mas, apesar do status de nobreza, ela guardava um grande segredo: a sua ascendência africana
Com a família real falida, a única opção da princesa é esconder quem realmente é e desistir do verdadeiro amor em busca de conseguir um casamento vantajoso com o rei da Inglaterra, George III, para então ascender ao trono e se tornar a nova rainha consorte. O que Charlotte não esperava era que o trauma, a loucura e a mentira que permeiam o reinado pudessem pesar tanto em sua vida.
Em Charlotte Sophia: Um romance, a autora Tina Andrews usa uma escrita assertiva para revelar todas as camadas de uma vida na corte repleta de ressentimentos, traições e angústias. Recheado com a coragem da mulher que, por décadas, enfrentou o preconceito da monarquia inglesa, Andrews apresenta os cenários de intriga aristocrática, adultério e as disfunções familiares que moldaram Charlotte Sophia desde sua vida como princesa da Alemanha até ocupar o trono ao lado do rei George III como rainha da Inglaterra.",
	'https://m.media-amazon.com/images/I/816vOnOODtL.jpg',
	2,464,1,2022,52.42,30,true,13,8,1);
call spinsertAutLiv(6555113820, 12);

call spCadLiv(
	'6559240770',
    'Toda a minha ira','All My Rage',
	"Lahore, Paquistão. Passado. Misbah é uma sonhadora e contadora de histórias, recém-casada com Toufiq em um casamento arranjado. Depois de ter a vida abalada por uma tragédia, eles emigram para os Estados Unidos e abrem o Clouds’ Rest Inn Motel, com a esperança de um recomeço.
Juniper, Califórnia. Presente. Salahudin e Noor são mais que melhores amigos; eles são família. Crescendo como párias numa cidadezinha em pleno deserto de Mojave, eles entendem um ao outro como ninguém mais consegue. Até a Briga, que destrói o vínculo entre eles com a fúria de uma explosão.
Agora, Sal luta para administrar o motel da família conforme a saúde de sua mãe, Misbah, se deteriora e seu pai se perde no alcoolismo. Noor, por sua vez, anda numa corda bamba angustiante, trabalhando na loja de bebidas de seu tio violento enquanto esconde o fato de que está se candidatando em várias universidades para poder escapar dele ― e de Juniper ― para sempre.
Quando as tentativas de Sal de salvar o motel saem de controle, ele e Noor precisam se perguntar quanto vale a amizade entre eles ― e o que é preciso para derrotar os monstros do passado e também os do presente.
Um romance juvenil contemporâneo brilhante, inesquecível e comovente sobre família e perdão, amor e perda, em uma história arrebatadora que atravessa gerações e continentes.",
	'https://m.media-amazon.com/images/I/718rcouaSCL.jpg',
	3,364,1,2022,45.24,250,true,14,12,1);
call spinsertAutLiv(6559240770, 13);

call spCadLiv(
	'6557121383',
    'Em busca de mim','Finding Me',
	"A internacionalmente aclamada atriz Viola Davis narra em sua biografia, Em busca de mim, tudo o que viveu desde a infância difícil até o estrelato. Nesta biografia você vai conhecer uma garotinha chamada Viola, que fugia de seu passado até tomar a transformadora decisão de parar de fugir para sempre.
Em busca de mim conta a minha história, de um apartamento caindo aos pedaços na cidade de Central Falls, em Rhode Island, para os palcos de Nova York e além. Este é o caminho que percorri em busca de propósito e força, mas também para me fazer ser ouvida em um mundo que não me percebia.
Enquanto escrevia Em busca de mim, pensei no quanto nossas histórias nem sempre recebem a devida atenção. São reinventadas para serem encaixadas em um mundo louco, competitivo e crítico. Escrevi este livro para aqueles que se sentem excluídos, que estão em busca de uma forma de entender e superar um passado complicado e encontrar autoaceitação no lugar da vergonha.
Escrevi para quem precisa se lembrar de que a vida só vale a pena ser vivida se a encararmos com honestidade radical e coragem de abandonar as máscaras e apenas ser... você.
Em busca de mim é uma reflexão profunda, uma promessa e uma declaração de amor a mim mesma. Espero que minha história o inspire a revolucionar sua vida de forma criativa e a redescobrir quem você era antes que o mundo tentasse defini-lo.",
	'https://m.media-amazon.com/images/I/91J7EVQy1jL.jpg',
	3,266,3,2022,29.99,150,true,15,19,3);
call spinsertAutLiv(6557121383, 14);

call spCadLiv(
	'6555603518',
    'O primeiro a morrer no final','The first to die at the end',
	"Em Os dois morrem no final, obra que já vendeu mais de 100 mil exemplares no Brasil, acompanhamos a história emocionante de Mateo e Rufus, dois jovens que decidem compartilhar seus últimos momentos e viver uma vida inteira em um único dia. Agora, Adam Silvera retorna com maestria ao universo que conquistou fãs no mundo inteiro, em uma trama que se passa sete anos antes do primeiro livro.
Na noite de 30 de julho de 2010, as pessoas se reúnem em diversas cidades dos Estados Unidos para a inauguração da Central da Morte, um serviço controverso capaz de informar se seus usuários terão um encontro prematuro com a morte ao longo das próximas 24 horas.
Orion Pagan espera há anos que alguém lhe diga quando vai morrer. Só assim ele conseguirá aproveitar um pouco a vida, sem o temor de não saber quando a doença grave que tem no coração o fará partir dessa para a melhor.
Receber uma ligação da Central da Morte é a última coisa que Valentino Prince deseja. Após deixar o Arizona e se mudar para Nova York, ele mal pode esperar para viver esse novo capítulo de sua história e realizar seus sonhos.
Sob as luzes da Times Square, Orion e Valentino se conhecem, e a conexão entre eles é imediata. Mas, á meia-noite, a primeira ligação da Central da Morte anuncia que um dos dois vai morrer em breve. Embora não saibam como ― ou quando ― o dia vai terminar, eles só têm uma certeza: querem ficar juntos até o fim.",
	'https://m.media-amazon.com/images/I/51vz37k-LGL.jpg',
	4,544,1,2022,53.13,79,true,5,11,3);
call spinsertAutLiv(6555603518, 15);

call spCadLiv(
	'6555662646',
    'A raiva não educa. A calma educa.',null,
	"“FOI NA BUSCA DE OUTRAS FORMAS [DE EDUCAÇÃO] QUE CONHECI A MAYA E A EDUCAÇÃO RESPEITOSA. [...] NESTE LIVRO, MAYA FALA COMO SE ELA ESTIVESSE SENTADA NA SUA FRENTE, TOMANDO UMA XÍCARA DE CAFÉ, TE OUVINDO SEM JULGAMENTOS, E FALANDO: ‘EU TE ENTENDO, DEIXA TE CONTAR UMA COISA...’”
Paola Carosella, chef de cozinha, empresária e mãe da Fran
MAYA EIGENMANN, pedagoga e educadora parental, convida você a repensar tudo o que sabe sobre educar crianças, mostrando que esse processo não precisa (nem deve) ser autoritário, constrangedor e ameaçador. Na educação respeitosa, proposta pela autora, considera-se as necessidades e os sentimentos da criança, sem deixar de colocar os limites necessários na criação dela. Isso significa que o objetivo é desenvolver o respeito da criança e do adolescente, e não a obediência, pura e simplesmente.
Ao longo do livro, você perceberá que a educação respeitosa, na verdade, não tem como foco principal as crianças, e sim os adultos, porque, para Maya, somos nós que precisamos ser reeducados com respeito e amor para que possamos propagar uma educação saudável às futuras gerações.",
	'https://m.media-amazon.com/images/I/71SvgvNLrPL.jpg',
	6,176,1,2022,29.99,239,true,16,32,3);
call spinsertAutLiv(6555662646, 16);

call spCadLiv(
	'8584392831',
    'Oito horas perfeitas','Eight perfect hours',
	"Uma história de amor emocionante, cheia de encontros e desencontros, que fará você acreditar no poder do destino.
Qualquer coisa poderia ter acontecido naquele dia. Mas Noelle nunca imaginou que uma nevasca fecharia a estrada e ela passaria a noite parada no trânsito, sozinha, sem comida, água ou um carregador de celular. E sequer pensou que, de repente, estaria sentada no carro do charmoso Sam, um norte-americano em uma breve visita à Inglaterra, tendo a melhor conversa de sua vida ― por oito horas perfeitas. Mas Sam está a caminho do aeroporto e ambos sabem que, no dia seguinte, seus caminhos se separarão para sempre. Mas e se o destino reservar um plano diferente para eles?",
	'https://m.media-amazon.com/images/I/71v1P3X7WEL.jpg',
	5,304,1,2022,29.99,99,true,17,9,3);
call spinsertAutLiv(8584392831, 17);

call spCadLiv(
	'655560302X',
    'Os dois morrem no final','They Both Die at the End',
	"No dia 5 de setembro, pouco depois da meia-noite, Mateo Torrez e Rufus Emeterio recebem uma ligação da Central da Morte. A notícia é devastadora: eles vão morrer naquele mesmo dia.
Os dois não se conhecem, mas, por motivos diferentes, estão à procura de um amigo com quem compartilhar os últimos momentos, uma conexão verdadeira que ajude a diminuir um pouco a angústia e a solidão que sentem. Por sorte, existe um aplicativo para isso, e é graças a ele que Rufus e Mateo vão se encontrar para uma última grande aventura: viver uma vida inteira em um único dia.
Uma história sensível e emocionante, Os dois morrem no final nos lembra o que significa estar vivo. Com seu olhar único, Adam Silvera mostra que cada segundo importa, e mesmo que não haja vida sem morte, nem amor sem perda, tudo pode mudar em 24 horas.",
	'https://m.media-amazon.com/images/I/51P4vYRr7XL.jpg',
	4,416,1,2021,29.99,200,true,5,11,3);
call spinsertAutLiv('655560302X', 15);

-- Retificando o nome do livro e retirando/recolocando a autora de ID 2
call spaltLivro('9788594540188','Frankenstein',null,'Sinopse','https://darkside.vteximg.com.br/arquivos/ids/173999-519-519/94-frankenstein-ou-o-prometeu-moderno-2.png?v=637558414029330000',1,283,2,1991,39.99,300,0,2,4,7);

select * from vwcheckAllLiv;

select * from vwcheckAllAutInLiv;

/* tbCliFis */
call spcadCliFis('Jesus Youssef', '1199209832', 'jesuscristo@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06300187", 33, 'Casa', 45982221311, '1990-12-25');
call spcadCliFis('Gabriel Bohm Santos', '1199209882', 'kamikat@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06309687", 34, 'Casa', 45226661311, '1996-04-02');
call spcadCliFis('Bianca Lula', '1199309833', 'thaigaloud@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06200087", 22, 'Casa', 45982221333, '1996-01-03');
call spcadCliFis('Thiago Sartori', '1199340822', 'tinownsthiago@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06200087", 22, 'Casa', 45912632311, '1999-05-06');

call spaltCliFis(2, 'Gus Rodrigues', '1194320943', 'gusthienx@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', "06300187", 33, 'Casa', 45982221222, '1990-12-25');

select * from vwcheckCliFis;

/* tbCliJur */
call spcadCliJur('Loud', '1136570927', 'loud@suporte.com.br', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '06210027', 10, 'Bloco 10', "01345846258741", 'LOUD GG', 'Thaiga');
call spcadCliJur('Jornal BG News', '11958424397', 'bgnews@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '05089000', 678 , null, "15485248562154", 'MIDIAS BGNEWS', 'Madu Gaspar');

call spautCliJur(5, 'Loud e-sports', '11365709287', 'loud@suporte.com.br', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '06239487', 124, 'Casa', "01345846258741", 'LOUD GG', 'Playhard');
call spautCliJur(6, 'Jornal BG News', '11958424397', 'bgnews@gmail.com', '$2a$10$EBgbnvn9BIFBmoUIDvxVmOTkqqevLcqPrCyLSltl1vCtmXG8clLka', '05089000', 678 , null, "15485248562154", 'MIDIAS BGNEWS', 'Madu Gaspar');

select * from vwcheckCliJur;

/* tbCliente */
call spcheckCliByName("Gabriel Bohm Santos");
call spcheckCliByName("Gus Rodrigues");
call spcheckCliByName("Bianca Lula");
call spcheckCliByName("Thiago Sartori");

select * from vwcheckAllCli;

/* tbVenda */
-- Abrindo vendas, colocando, tirando produtos e alterando o status de delivery delas
-- SEMPRE SETAR SET FOREIGN_KEY_CHECKS=0 ANTES DE RODAR OS TESTES --
call spcomecVenda("Dinheiro", 1, false, null);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555652956",1);

call spcomecVenda("Transferência", 2, true, '2022-10-24');
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555652956",1);
call spaltStatusDeliv((select idDel from tbDelivery order by idVen desc limit 1),2);

call spcomecVenda("Crédito", 3, true, '2022-10-26');
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004",1);
call spdelLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9786555980004");
call spputLivVenda((select idVen from tbVenda order by idVen desc limit 1),"9788594540188",1);
call spaltStatusDeliv((select idDel from tbDelivery order by idVen desc limit 1),1);

select * from vwcheckAllVenda;

call spcheckAllItemVenda(2);

select * from vwcheckAllDeliv;
