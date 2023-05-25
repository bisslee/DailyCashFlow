# Daily Cash Flow
Serviço que faça controle de lançamentos para teste

## Objetivo
Criar um sistema que faça controle do fluxo de caixa, com os seguintes serviços:
- Cadastrar um lançamento
- Obter o saldo mediante a uma especifica data

## Tecnologias
Para esse teste usamos o .net6, utilizando minimals APIs.
O gerenciador de bando de dados escolhido foi o SQL 

## Arquitetura proposta
![Desenho da Arquitetura](https://github.com/bisslee/DailyCashFlow/blob/master/Doc/Arquitetura.png?raw=true)

Neste diagrama, a seta indica a direção do fluxo de dados. Os usuários acessam o sistema através da Internet e o tráfego passa pelo firewall para proteção. Em seguida, o load balancer distribui as solicitações entre os contêineres do gateway e da API.

A escalabilidade é alcançada com o uso do orquestrador de contêineres, que gerencia dinamicamente o número de instâncias dos contêineres do gateway e da API com base na carga de trabalho. Isso permite que você dimensione verticalmente (aumentando a capacidade dos contêineres) ou horizontalmente (adicionando mais instâncias) conforme necessário.

Não foi adicionado autenticação, pode-se adicionar usando o firebase ou o MS Identity. 

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
