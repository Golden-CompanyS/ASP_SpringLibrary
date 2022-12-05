# Sistema ASP.Net Spring Library

![Logo_Tema_Claro](https://user-images.githubusercontent.com/80417466/204179176-1fa554bd-87bd-42e0-91bc-16cbea4c4591.png)

## Perfil do desenvolvedor e seus respectivos contribuintes:

| [<img src="https://avatars.githubusercontent.com/u/62896500?v=4" width=115><br><sub>Mateus Taveira</sub>](https://github.com/letyresina) | [<img src="https://avatars.githubusercontent.com/u/85740476?v=4" width=115><br><sub>Erin Rodrigues</sub>](https://github.com/LarissaSonoda) | [<img src="https://avatars.githubusercontent.com/u/82532010?v=4" width=115><br><sub>Gustavo Pereira</sub>](https://github.com/PereiraGus) 
| :---: | :---: | :---:

## Objetivo
O sistema tem como enfoque entrega do TCC que une os conhecimentos desde o Primeiro Ano do Ensino Médio integrado ao Desenvolvimento de sistemas na ETEC Professor Basilides de Godoy. Essa é a entrega final.

Esse sistema web é o principal para a empresa cliente fictícia, Spring Library, onde clientes e funcionários terão acesso. É alimentado através do banco Mysql, presente na pasta de scripts.

## Linguagens utilizadas
 | <img src="https://growiz.com.br/wp-content/uploads/2020/08/kisspng-c-programming-language-logo-microsoft-visual-stud-atlas-portfolio-5b899192d7c600.1628571115357423548838.png" width=150px /> | <img src="https://fabiobrandao.net.br/blog/wp-content/uploads/2018/09/aspnetmvc.png" width=200> | <img src="https://miro.medium.com/max/1400/1*DZyivhX9QpnKxovKyQjZEw.png" width=115 />  | <img src="https://www.freepnglogos.com/uploads/html5-logo-png/html5-logo-devextreme-multi-purpose-controls-html-javascript-3.png" width=295>
| :---: | :---: | :---:  | :---: 

## Plataforma de desenvolvimento

![image](https://user-images.githubusercontent.com/80417466/204288648-490a8bdb-f4a0-43aa-b72e-ba259aad94b0.png)

Visual Studio 2022.

## Manual para acesso ao sistema

Válido ressaltar que o sistema está hospedado localmente, portanto, o manual será em base disso.

O primeiro passo essencial é executar o banco de dados por completo, tanto o "dbSpringLibrary", que tem as ações do banco, quando o "dbPopulate" que popula o banco e o sistema. Depois disso, abra o app e siga o passo a passo abaixo:

#### Banco de Dados
1. Comece iniciando sua instância do Banco de Dados. Para isso, pressione `Windows + R` e procure por `services.msc`;
2. Na lista retornada, procure por `MySQL80` e, com o botão direito do mouse em cima, inicie-o.
3. Execute seu MySQL Workbench;
4. Abra sua conexão no localhost e os arquivos `dbSpringLibrary` e `dbPopulate` contidos no caminho `~/ASP_SpringLibrary/Front e Banco/Banco de dados/`;
5. Com ambos abertos, comece executando o primeiro, de forma que a execução se faça em blocos, demarcados pelos comentários de três linhas para evitar qualquer tipo de erro decorrente da criação simultânea de procedures e views;
6. Em seguida, execute o `dbPopulate` com um clique. Se você fez tudo corretamente, ele irá rodar sem erros.

#### Sistema
1. Abra o projeto no Visual Studio 2022;

2. Clique em executar e espere seu navegador compilar;

3. Na página Home, você pode explorar os livros cadastrados previamente sem necessidade fazer Login. Os livros também podem ser buscados através de pesquisa e de filtros na página Livros;

4. O usuário pode também acessar a parte Sobre, que conta um pouco mais sobre a empresa cliente Spring Library e onde ela se localiza, sem a necessidade de Login;

5. O usuário também pode acessar a página de contato, onde contém todas as informações para que o cliente entre o contato, na qual ele enviaria o e-mail através do formulário, inserindo seu nome, e-mail e mensagem, sem a necessidade de logar-se;

6. Se for o desejo, pode clicar em Login/Cadastre-se, nesta parte há duas soluções:
   6.1. Caso seja um cadastro, é somente voltado para clientes. Colocará suas informações e terá acesso ao sistema com nível de acesso voltado ao carrinho e funcionalidades como um cliente normal. Funcionários podem ser cadastrados apenas por outros funcionários.
   6.2 Caso seja um login, poderá ser de cliente, que irá inserir seu login e senha e ter, conforme citado anteriormente, funcionalidades como um cliente normal. Caso funcionário previamente cadastrado, terá acesso a parte de painel administrativo.

7. O cliente pode utilizar, agora logado, do carrinho para finalizar suas compras. Ressaltando que apenas se faz compra caso o cliente já tenha seu cadastro;

8. Caso finalize sua compra, colocará informações para pagamento e escolherá se é delivery ou retirada na loja;

9. Caso delivery, o cliente poderá acompanhar o andamento, e confirmar o recebimento.

10. Caso o usuário seja funcionário, como exemplo citaremos gerente, no painel administrativo poderá cadastrar funcionários, desativar funcionários, cadastrar livros ou desativar livros, dentre diversas outras operações, vide na tela. Quando solicitado cadastro, poderá preencher um formulário com as informações. Também pode realizar consultas;

11. Pode deslogar do sistema, em ambos os casos, com a opção de Sair da conta/Deslogar.

## Andamento do projeto

<p align = "center">
<img src="http://img.shields.io/static/v1?label=STATUS&message=CONCLUIDO&color=GREEN&style=for-the-badge"/>
</p>

## Copyright 

Copyright ©️ 2022 - Spring Library.
