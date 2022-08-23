# Desafio Dev .Net Backend
Este documento descreve o desafio que será utilizado para avaliar os candidatos à vaga de backend na D&D. Caso você tenha chegado aqui por acaso, sinta-se à vontade em realizar o teste, e logo após, contar um pouco mais sobre você através do email (erica.gavazzi@dedtechsolutions.com.br)

# O  Desafio
A equipe D&D levantou a necessidade de construção de um ferramenta de tarefas, onde o cliente acessará um link e informará as tarefas à serem feitas. A medida que a pessoa for realizando a tarefa, a mesma irá excluir a tarefa para tirar da lista e dar sequência para as próximas.

Você será o responsável por criar essa API que faça um CRUD das tarefas, ou seja:

- Crie um projeto WebAPI; 

- Crie uma base de dados com os dados informados abaixo;

- Faça um CRUD de tarefas. Será necessário gerar 5 endpoints para atender à esta finalidade:
  - Listar todas as tarefas
  - Buscar uma tarefa em especifico;
  - Criar uma tarefa nova;
  - Excluir uma tarefa;
  - Editar uma tarefa;

**O que não fazer:**
Vamos manter o desafio simples, ou seja, não crie tarefas diferentes para cada usuário ou coisas do gênero. A ideia é saber se você consegue criar uma API seguindo boas práticas e que faça persistência no banco de dados.

## O que seria uma tarefa:
Toda tarefa possui:

- Id (identificador único da tarefa);
- Titulo
- Descrição
- Data de Criação 
- Data de Atualização 

## Requisitos técnicos (para vaga de C#):
- Utilizar a base de dados Sql Server;
- Construir a API com dotnet core 3.1 ou versões superiores.
- Utilizar o Entity Framework para a camada de persistência;
- Adotar as melhores práticas do mercado para construção de APIs (Neste momento não importa adicionar complexidade extra/desnecessária);

## Diferenciais:
- Instalar e configurar o swagger;
- Aplicar o padrão RESTful para o desenvolvimento da API;

## O que será avaliado:
- **Organização do código**: Como você organiza os arquivos que compõem a solução;
- **Estruturação do código**: Como você estrutura o código e a solução do projeto (arquitetura adotada, etc);
- **Criatividade/Inovação:** Capacidade de sugerir melhorias no contexto descrito no desafio;
- **Nomenclatura/padrões:** A nomenclatura e padrões adotados para as propriedades, atributos, endpoints e nome do projeto;
- **Utilização do Git:** O readme do repositório e a descrição dos commit deverão ser claros e de fácil entendimento;

## Entrega:
O candidato deverá criar um fork deste projeto, e a partir deste fork, realizar o desenvolvimento. Favor utilizar o "Readme" do seu fork para descrever as dificuldades técnicas encontradas, como você as superou e, principalmente, como subir o projeto. Ao finalizar, você deverá responder para o e-mail que te enviou esse desafio, com o link do seu fork.
## Para Rodar:
Baixar do git a aplicação.
Criar o database e alterar a connectionstring no arquivo appsettings.json campo ConnectionString