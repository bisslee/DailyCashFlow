# Daily Cash Flow
Serviço que faça controle de lançamentos para teste

## Objetivo
Criar um sistema que faça controle do fluxo de caixa, com os seguintes serviços:
- Cadastrar um lançamento
- Obter o saldo mediante a uma especifica data

## Tecnologias
Para esse teste usamos o .net6, utilizando minimals APIs.
O gerenciador de bando de dados escolhido foi o SQL 

## Desenho do Sistema
![Diagrama Geral](https://github.com/bisslee/DailyCashFlow/blob/master/Doc/Diagrama-geral.png?raw=true)

## Descrição
Dado o objetivo simples da aplicação, o sistema Biss.CashFlow foi dividido em 3 camadas:
- App: Responsavel expor os endpoints
- Service: Responsavel pelas regras de negocio
- Data: Responsavel pela persistencia dos dados

### Comunicação
Entre as camadas optei por usar Injeção de dependencia, para que as camadas não fiquem acopladas, e para que seja possivel a troca de implementação de uma camada sem que as outras camadas sejam afetadas.

## Instalação

### Requisitos
Para rodar o projeto é necessario ter o .net7 instalado, e acesso à uma instância do SQL Server.

### Empacotamento
Para empacotar o projeto, basta rodar o comando abaixo na raiz do projeto:
```
dotnet publish -c Release
```

Isso criará uma versão compilada otimizada da sua aplicação na pasta:
```
bin/Release/net7.0/publish. 
```

### Configuração
Adicione no arquivo appsettings.json as configurações de conexão com o banco de dados:
```
  "ConnectionStrings": {
    "Default": ""
  },
```

### `Gerando o banco de dados`
Para gerar o banco de dados, basta rodar o comando abaixo na raiz do projeto:
```
dotnet ef database update
```

## Utilizando o Docker
Caso queira rodar o projeto em um container docker, basta rodar o comando abaixo na raiz do projeto:
```
docker build -t biss-daily-cash-flow .
```

e rode como:

```
docker run -p 8080:80 biss-daily-cash-flow
```

# Duvidas
Para duvidas, sugestões ou criticas, entre em contato comigo pelo email:
```
ivana@biss.com.br ou
bisslee@gmail.com
```

### Obrigado pela oportunidade!
