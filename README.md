# Introduction 
Esse projeto consiste em uma api com DDD + CQRS com front end em angular 9+.

# Getting Started
Esses são os passos para rodar a aplicação tanto backend quanto front end.
1.	Rodar a atualização do banco, na pasta raiz do projeto "~\TestDgBar" abra um terminal e rode o seguinte comando: "dotnet ef database update --project BarDg.Domain.Infra"
	Ele irar rodar todas as migrations e criar o banco de dados no localDB.
2.	Após rodar a migration basta rodar a api no visual studio ou ide da sua preferência. Se estiver tudo ok irá abrir o swagger no navegador.
3.  depois abra o código do front end no vscode que está localizado no seguinte diretótio: "~\TestDgBar\bardg-ui" no proprio terminal do vs code digite o seguinte comando "npm i"
	ele irá instalar todas as dependências do projeto.
4.	Depois de finalizado a instalação das dependências rode o comando "ng s". Ele irá subir a aplicação no "http://localhost:4200/login".
5.	Login e senha padrões: usuário: "admin@admin.com" senha: "admin"


# improvements
Tem muitos pontos a serem melhorados.
No backend utilizei DDD + CQRS, eu poderia quebrar mais as responsabilidades nos handles,
Seguindo o principio do SRP, abordar mais o Open Closed, o Solid como um todo.
Poderia aplicar mais clean code pra melhorar a leitura do código.
Com certeza fazer mais testes unitários.

No handle de criar a comanda(order) pra aplicar as promoções eu utilizei o pattern
https://www.dofactory.com/net/chain-of-responsibility-design-pattern

No front end, já deixo adiantado que é algo que tenho um conhecimento intermediário.
Então utilizei um create-app pra me gerar uma estrutura inicial, tive que remover algumas coisas que eu não utilizaria.
E então criei as telas/componentes o mais simples possivel e somente para funcionar o fluxo.
Tem praticamente nada de boas práticas de clean code ou do próprio angular.
Mas não deixei de fazer o desafio :)

Qualquer dúvida podemos conversar e eu explico minhas linhas de raciocinio etc..
