# 📚 Gerenciamento de Biblioteca

## 📂 Descrição do Repositório
Este repositório contém o código-fonte do projeto de residência do Porto Digital, em parceria com a Ferreira Costa, voltado para o desenvolvimento de um microsserviço de gerenciamento de biblioteca.

Este projeto é uma aplicação ASP.NET Core para o gerenciamento de uma biblioteca. A aplicação fornece uma API para gerenciar usuários e livros, utilizando Entity Framework Core para interação com o banco de dados SQL Server.

## 👥 Membros da Equipe
- Adonis Vinicius Guedes da Silva
- Cicero Antonio Maciel Siqueira
- João Pedro Brito Ferreira da Silva
- Lucas Gabriel Correia do Nascimento
- Mariah
- Thiago Costa da Silva

## 🗂️ Estrutura do Projeto
O projeto é organizado da seguinte maneira:

- `📁 Data/`: Contém o contexto do banco de dados (`SistemaLivrosDBContex`).
- `📁 Repositorios/`: Contém as implementações dos repositórios (`UsuarioRepositorio` e `LivroRepositorio`).
- `📁 Repositorios/Interfaces/`: Contém as interfaces dos repositórios (`IUsuarioRepositorio` e `ILivroRepositorio`).

## ⚙️ Configuração e Execução

### 📋 Pré-requisitos
- .NET SDK
- SQL Server
- Ferramenta de linha de comando (Recomendado: Visual Studio, Visual Studio Code)

### 💾 Instalação
1. Clone o repositório para a sua máquina local:
   ```sh
   git clone https://github.com/seu-usuario/gerenciamento-de-biblioteca.git
   cd gerenciamento-de-biblioteca
   ```

2. Configure a string de conexão com o banco de dados no arquivo `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DataBase": "Server=seu_servidor;Database=sua_base_de_dados;User Id=seu_usuario;Password=sua_senha;"
     }
   }
   ```

### 🚀 Execução
1. Restaure as dependências do projeto:
   ```sh
   dotnet restore
   ```

2. Execute as migrações para criar o banco de dados:
   ```sh
   dotnet ef database update
   ```

3. Execute a aplicação:
   ```sh
   dotnet run
   ```
   
## 🛠️ Uso

### 🌐 Endpoints
A aplicação expõe os seguintes endpoints para gerenciar usuários e livros:

- `GET /api/usuarios`: Lista todos os usuários.
- `POST /api/usuarios`: Cria um novo usuário.
- `GET /api/livros`: Lista todos os livros.
- `POST /api/livros`: Cria um novo livro.

### 📜 Swagger
Para explorar e testar a API, você pode usar a interface do Swagger.

## 📂 Estrutura do Código

### `📄 Program.cs`
O arquivo `Program.cs` configura e inicializa a aplicação ASP.NET Core.

- Adiciona os controladores.
- Configura o Swagger para documentação da API.
- Configura o Entity Framework Core com SQL Server.
- Adiciona os repositórios como serviços Scoped.
- Configura o pipeline de solicitações HTTP.

## 📦 Dependências
- `Microsoft.EntityFrameworkCore.SqlServer`: Provedor do Entity Framework Core para SQL Server.
- `Swashbuckle.AspNetCore`: Biblioteca para integração do Swagger com o ASP.NET Core.

## ✨ Contribuições
Contribuições são bem-vindas! Por favor, abra um "issue" ou envie um "pull request".
