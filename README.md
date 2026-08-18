# 📦 Controle de Estoque

Sistema web de **controle de estoque** desenvolvido em **C# e ASP.NET Core**, criado com o objetivo de praticar conceitos de desenvolvimento backend, organização em camadas, acesso a dados e construção de aplicações web.

> 🚧 **Projeto em desenvolvimento / estudo**

## 🎯 Objetivo

O projeto tem como objetivo desenvolver uma aplicação de controle de estoque aplicando conceitos importantes do ecossistema .NET, como:

* C#
* ASP.NET Core
* Entity Framework Core
* CRUD
* Repository Pattern
* Service Layer
* Controllers
* Models
* Persistência de dados
* Organização em camadas
* Tratamento e validação de dados

## 🛠️ Tecnologias utilizadas

| Tecnologia                | Utilização                       |
| ------------------------- | -------------------------------- |
| **C#**                    | Linguagem principal              |
| **ASP.NET Core**          | Desenvolvimento da aplicação web |
| **Entity Framework Core** | Acesso e persistência de dados   |
| **HTML / CSS**            | Interface da aplicação           |
| **JavaScript**            | Interações no frontend           |
| **Git / GitHub**          | Controle de versão               |

## 🏗️ Estrutura do projeto

O projeto está organizado buscando separar as responsabilidades da aplicação:

```text
ControleEstoque/
│
├── Controller/
│   └── Controllers da aplicação
│
├── Data/
│   └── Configurações relacionadas aos dados
│
├── Models/
│   └── Entidades e modelos
│
├── Pages/
│   └── Páginas da aplicação
│
├── Repositorie/
│   └── Acesso e operações com dados
│
├── Service/
│   └── Regras e lógica da aplicação
│
├── wwwroot/
│   └── Arquivos estáticos
│
├── Program.cs
├── appsettings.json
└── ControleEstoque.csproj
```

## 📋 Funcionalidades

### Produtos

* [x] Cadastro de produtos
* [x] Consulta de produtos
* [ ] Edição de produtos
* [ ] Exclusão de produtos

### Estoque

* [ ] Entrada de produtos
* [ ] Saída de produtos
* [ ] Consulta do saldo em estoque
* [ ] Histórico de movimentações
* [ ] Controle de estoque mínimo

### Relatórios

* [ ] Relatório de estoque
* [ ] Relatório de movimentações
* [ ] Produtos abaixo do estoque mínimo

> A lista de funcionalidades será atualizada conforme o desenvolvimento do projeto.

## 🚀 Como executar o projeto

### Pré-requisitos

Antes de executar o projeto, é necessário ter instalado:

* [.NET SDK](https://dotnet.microsoft.com/download)
* [Visual Studio Code](https://code.visualstudio.com/) ou Visual Studio
* Git

### Clonar o repositório

```bash
git clone https://github.com/alesantos9372-ui/ControleEstoque.git
```

Entre na pasta:

```bash
cd ControleEstoque
```

### Restaurar as dependências

```bash
dotnet restore
```

### Executar a aplicação

```bash
dotnet run
```

Após iniciar a aplicação, acesse a URL apresentada pelo terminal.

## 🧠 Conceitos praticados

Este projeto faz parte dos meus estudos de desenvolvimento com C# e .NET.

Durante o desenvolvimento estou praticando:

* Sintaxe e fundamentos do C#
* Programação Orientada a Objetos
* ASP.NET Core
* Injeção de Dependência
* Entity Framework Core
* CRUD
* Repository Pattern
* Separação de responsabilidades
* Arquitetura em camadas
* APIs e aplicações web
* Git e GitHub

## 📚 Próximos passos

Algumas melhorias planejadas para o projeto:

* [ ] Implementar autenticação de usuários
* [ ] Melhorar validações
* [ ] Implementar DTOs
* [ ] Melhorar tratamento de exceções
* [ ] Implementar logging
* [ ] Criar testes unitários
* [ ] Melhorar a interface
* [ ] Adicionar documentação da API
* [ ] Criar dashboard de estoque
* [ ] Implementar filtros e paginação
* [ ] Adicionar controle de estoque mínimo
* [ ] Implementar histórico de movimentações

## 📌 Status

🟡 **Em desenvolvimento**

Este projeto está sendo desenvolvido como parte do meu processo de aprendizado em **C#, .NET e desenvolvimento de aplicações web**.

## 👨‍💻 Autor

**Alexandre dos Santos**

Projeto desenvolvido para estudos e prática de desenvolvimento de software com C# e .NET.

---

⭐ Se este projeto for útil para seus estudos, fique à vontade para acompanhar sua evolução.
