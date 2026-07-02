# AdoPet

O projeto AdoPet é uma aplicação de estudo desenvolvida em C# e .NET com o objetivo de praticar e reforçar conceitos de boas práticas de programação, arquitetura, refatoração, testes e design de software.

Ele foi criado como base para a formação “Boas práticas em C#” da Alura, com foco em transformar um projeto simples em uma solução mais limpa, legível, manutenível e alinhada com os princípios de desenvolvimento profissional.

## Objetivo do projeto

Este repositório serve como laboratório prático para estudar e aplicar:

- Clean Code e legibilidade de código
- Refatoração para melhorar estrutura e manutenção
- Princípios SOLID
- Padrões de projeto
- Testes automatizados e boas práticas de testes
- Organização e separação de responsabilidades
- Uso de APIs e clientes de linha de comando

A proposta é evoluir o código continuamente, melhorando sua qualidade sem perder o foco no aprendizado prático.

## Resumo dos objetivos do curso

Nesta formação, o objetivo é aprender a aplicar boas práticas e técnicas de refatoração, entender o que são padrões de projeto e aplicar testes automatizados. A ideia é aprimorar a legibilidade do código, identificar cenários ideais para refatoração e construir soluções mais concisas, robustas e fáceis de manter.

Também exploramos conceitos fundamentais como:

- Código limpo e manutenção simplificada
- Importância dos testes como proteção contra regressões
- Princípios do SOLID como base para sistemas flexíveis e escaláveis
- Design patterns como ferramentas para resolver problemas comuns com soluções comprovadas
- Boas práticas de organização, configuração e evolução de software

## Visão geral da solução

O projeto possui duas partes principais:

1. Uma API em ASP.NET Core para cadastrar e listar pets
2. Um cliente em console para importar dados de pets a partir de arquivos

Essa arquitetura permite exercitar tanto o desenvolvimento de serviços quanto o consumo de APIs e a criação de fluxos de importação em lote.

## Funcionalidades

### API Web

A API oferece endpoints para manipular pets:

- GET /pet/list — lista os pets cadastrados
- POST /pet/add — cadastra um novo pet

A aplicação utiliza:

- ASP.NET Core
- Entity Framework Core com banco em memória
- Swagger para documentação da API
- Serilog para logs

### Cliente em Console

O projeto console possibilita interagir com a API por meio de comandos:

- import — importa pets a partir de um arquivo
- list — exibe os pets cadastrados na API
- show — mostra o conteúdo de um arquivo de entrada
- help — exibe a ajuda dos comandos disponíveis

## Como executar

### 1. Executar a API

No diretório do projeto Alura.Adopet.API, execute:

```bash
dotnet run
```

A API ficará disponível em:

- http://localhost:5057
- https://localhost:7136

O Swagger pode ser acessado na raiz do projeto quando a aplicação estiver rodando.

### 2. Executar o cliente em console

Com a API em execução, utilize os seguintes comandos no diretório do projeto Alura.Adopet.Console:

```bash
dotnet run import lista.csv
dotnet run list
dotnet run show lista.csv
dotnet run help
```

## Estrutura do projeto

- Alura.Adopet.API — aplicação web com controllers, domínio, repositórios, serviços e configuração de logs
- Alura.Adopet.Console — aplicação de linha de comando para importar e consultar dados

## Observações importantes

- O projeto utiliza um banco de dados em memória, portanto os dados são perdidos quando a aplicação é encerrada.
- O foco principal não é apenas entregar funcionalidades, mas evoluir o código com qualidade e aprendizado contínuo.
- Este repositório é ideal para praticar refatoração, melhoria de design e aplicação de boas práticas em um cenário realista.