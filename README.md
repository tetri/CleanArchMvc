# CleanArchMvc

![Build Status](https://img.shields.io/github/actions/workflow/status/tetri/CleanArchMvc/build-and-test.yml?branch=dotnet9.0)
![License](https://img.shields.io/github/license/tetri/CleanArchMvc?branch=dotnet9.0)
![Last Commit](https://img.shields.io/github/last-commit/tetri/CleanArchMvc?branch=dotnet9.0)

## Sobre o Projeto

O **CleanArchMvc** é uma aplicação de exemplo que implementa os princípios da arquitetura limpa (Clean Architecture) em um projeto ASP.NET Core MVC. O objetivo é demonstrar como estruturar um projeto de forma modular, separando responsabilidades e facilitando a manutenção e evolução do código.

## Funcionalidades

- Cadastro de produtos e categorias.
- Validação de dados no domínio.
- Persistência de dados com Entity Framework Core.
- Interface amigável com ASP.NET Core MVC.
- Testes unitários para as camadas de domínio e aplicação.

## Tecnologias Utilizadas

- **ASP.NET Core MVC**: Framework para construção de aplicações web.
- **Entity Framework Core**: ORM para acesso ao banco de dados.
- **SQLite**: Banco de dados leve para persistência.
- **XUnit**: Framework para testes unitários.
- **FluentValidation**: Biblioteca para validação de regras de negócio.

## Estrutura do Projeto

O projeto segue a arquitetura limpa, com as seguintes camadas:

1. **Domain**: Contém as entidades e regras de negócio.
2. **Application**: Contém os casos de uso e interfaces de aplicação.
3. **Infrastructure**: Implementa os repositórios e acesso ao banco de dados.
4. **Presentation**: Contém a interface do usuário (MVC).

## Como Executar

1. Clone o repositório:
    ```bash
    git clone https://github.com/tetri/CleanArchMvc.git
    cd CleanArchMvc
    ```

2. Restaure as dependências:
    ```bash
    dotnet restore
    ```

3. Execute as migrações do banco de dados:
    ```bash
    dotnet ef database update
    ```

4. Inicie a aplicação:
    ```bash
    dotnet run
    ```

5. Acesse no navegador: `http://localhost:5000`

## Testes

Para executar os testes, utilize o comando:
```bash
dotnet test
```

## Contribuição

Contribuições são bem-vindas! Siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature:
    ```bash
    git checkout -b minha-feature
    ```
3. Faça o commit das alterações:
    ```bash
    git commit -m "Minha nova feature"
    ```
4. Envie para o repositório remoto:
    ```bash
    git push origin minha-feature
    ```
5. Abra um Pull Request.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

## Contato

- **Autor**: Tetri Mesquita
- **Email**: contato@tetri.net
- **GitHub**: [tetri](https://github.com/tetri)
