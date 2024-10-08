# AnimesProtech
  Projeto de desafio técnico para testar e implementar conceitos de arquitetura limpa em uma API Restfull com a finalidade de gerenciar animes
## Funcionalidades
- Cadastro de animes.
- Listagem de animes com filtros de nome, resumo e diretor.
- Atualização de animes.
- Exclusão de animes.
- Cadastro de diretor.
- Listagem de diretores com filtros de nome e por ID.
- Atualização de diretor.


## Como Executar a Aplicação
1. **Clone o repositório.**
2. **Criar variável de ambiente AnimesProtechUser e AnimesProtechPassword com o usuário e senha criado para acessar o banco.**
3. **Abra o terminal na pasta do projeto.**
4. **Execute o comando cd Infraestructure**
5. **Execute o comando dotnet ef database update -c ProtechAnimesContext para criar o banco de dados**
6. **Execute o comando cd ..**
7. **Execute o comando dotnet run --project API**
8. **Acesse http://localhost:5216/swagger/index.html** 

## Tecnologias Utilizadas
- **ASP.NET Core**: Framework para construção de aplicações web.
- **MediatR**: Biblioteca para implementar o padrão Mediator, permitindo um design desacoplado.
- **Entity Framework Core**: ORM para acesso a dados em bancos de dados relacionais.
- **MySQL**: Sistema de gerenciamento de banco de dados relacional utilizado para armazenar os dados da aplicação.

   
## Links Úteis

- [Documentação do ASP.NET Core](https://docs.microsoft.com/aspnet/core/?view=aspnetcore-8.0)
- [Documentação do MediatR](https://github.com/jbogard/MediatR)
- [Documentação do Entity Framework Core](https://docs.microsoft.com/ef/core/)
- [Documentação do MySQL](https://dev.mysql.com/doc/)
