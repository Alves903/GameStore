# GameStore

Projeto desenvolvido em C# com o objetivo de criar um sistema de gerenciamento para uma loja de jogos.

O sistema funciona pelo Console e permite realizar o cadastro de jogos e clientes, registrar vendas, controlar o estoque e registrar pedidos de jogos feitos pelos clientes.

## Funcionalidades

- Cadastro de jogos
- Listagem e pesquisa de jogos
- Exclusão de jogos
- Controle de estoque
- Listagem de jogos com estoque baixo
- Cadastro de clientes
- Listagem e pesquisa de clientes
- Exclusão de clientes
- Registro de vendas
- Cálculo do valor total da venda
- Atualização do estoque após uma venda
- Relatório de vendas e faturamento
- Registro de pedidos de jogos
- Salvamento dos dados em JSON
- Carregamento dos dados salvos

## Conceitos utilizados

Durante o desenvolvimento foram utilizados conceitos de Programação Orientada a Objetos, como:

- Classes e objetos
- Encapsulamento
- Herança
- Polimorfismo
- Interfaces
- Métodos e propriedades
- Listas
- Tratamento de exceções
- Manipulação de arquivos
- Serialização em JSON

## Tecnologias

- C#
- .NET Framework 4.7.2
- Visual Studio
- JSON

## Estrutura do sistema

O sistema possui as principais entidades:

- **Produto** - classe base dos produtos da loja
- **Jogo** - representa os jogos disponíveis
- **Cliente** - armazena os dados dos clientes
- **Venda** - registra as vendas realizadas
- **SolicitacaoJogo** - registra pedidos de jogos feitos pelos clientes

## Execução

Para executar o projeto:

1. Clone ou baixe este repositório.
2. Abra a solução `GameStore.slnx` no Visual Studio.
3. Compile o projeto.
4. Execute o programa.
5. Utilize o menu exibido no Console.

## Autor

Lukas Alves Gonçalves

Projeto desenvolvido durante o curso Técnico em Desenvolvimento de Sistemas - SENAI.
