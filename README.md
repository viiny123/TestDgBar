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
