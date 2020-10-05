# Projeto

Teste levantando pela equipe romeva. Tem como objetivo construir uma RESTFul API com um CRUD:
Create (Criação), Read (Consulta), Update (Atualização) e Delete (Destruição), básicos de duas entidades categorias e produtos.

# Tecnologias
 - [C# CSharp ](https://docs.microsoft.com/pt-br/dotnet/csharp/)-
 Linguaguem de programação para construção da api.
 - [.NET Core 3.1](https://docs.microsoft.com/pt-br/dotnet/core/introduction)- 
 Framework que permite a Api rodar em multi-plataformas.
 - [mysql workbench 8.0](https://dev.mysql.com/doc/workbench/en/)-Banco de dados relacional utilizado para persistir os dados.
 - [Entity Framework 3.1](https://docs.microsoft.com/pt-br/ef/)-ORM utilizado para fazer a ligação entre a aplicação e o banco de dados.
 - [Swagger 3.0](https://swagger.io/docs/specification/about/,)-Framework utilizado para gerar a documentação da api.
 - [Mvc]()-Padrão de programação em camadas (Model,View,Controller)
 - [Docker Hub](https://hub.docker.com/repository/docker/rafaelalmeidadev/projetorafael)- O projeto foi hospedado na plataforma.
 - [Style Guide:](https://docs.microsoft.com/pt-br/dotnet/csharp/programming-guide/inside-a-program/coding-conventions) C# Style Guide.

# Como Rodar

## Passo-a-Passo

### Opção 01:
A api está hospedada na plataforma heroku: http://apirafaelalmeida.herokuapp.com/index.html 


### Opção 02:
A api esta hospeda em um servidor Azure: https://apirafaelalmeida.azurewebsites.net/

### Opção 03:
O Projeto está hospedado no git hub :
- Baixar o projeto; 
- Executar no vscode;

Tem uma imagem na api disponivel no Docker Hub :https://hub.docker.com/repository/docker/rafaelalmeidadev/projetorafael

Exemplo: Adicionar Categoria
```{json}
{
  "id": 0,
  "nome": "Categoria Teste"
}
```
Exemplo: Adicionar Produto
```{json}
{
  "id": 0,
  "nome": "Produto Teste",
  "preco": 1.0,
  "categoriaId": 4
}
```

 
