### README para BlazorBookStore

# BlazorBookStore

BlazorBookStore é uma aplicação simples de CRUD desenvolvida em **Blazor** para gerenciar uma coleção de livros. O projeto utiliza padrões de arquitetura limpa, injeção de dependência e Entity Framework Core para persistência de dados.

---

## Funcionalidades
- Adicionar, editar, deletar e visualizar livros.
- Classificar livros por categoria e editora.
- Layout responsivo com Bootstrap.
- Integração com banco de dados usando Entity Framework Core.
- Arquitetura modular separada em camadas.

---

## Estrutura do Projeto
A solução é dividida em múltiplos projetos para garantir modularidade e facilidade de manutenção:

1. **BlazorBookStore.Domain**
   - Contém as entidades principais (`Book`) e enums (`Category`, `Publisher`).
   - Define abstrações de repositório (`IBookRepository`).

2. **BlazorBookStore.Application**
   - Inclui as abstrações de serviço (`ILivroService`) e implementações (`LivroService`) para lógica de negócio.

3. **BlazorBookStore.Infrastructure**
   - Implementa a persistência de dados com o Entity Framework Core.
   - Contém o `AppDbContext`, implementações de repositórios (`BookRepository`) e configurações de banco de dados.

4. **BlazorBookStore.Blazor**
   - Aplicação frontend desenvolvida com Blazor.
   - Inclui componentes Razor para a interface de usuário (ex.: `Books.razor`, `BookForm.razor`).

5. **BlazorBookStore.CrossCutting**
   - Responsável por configurações de injeção de dependência e configurações globais da aplicação.

---

## Começando

### Pré-requisitos
- SDK do .NET 9.0 ou superior.
- SQL Server para o banco de dados.

### Instalação
1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/BlazorBookStore.git
   cd BlazorBookStore
   ```

2. Restaure as dependências:
   ```bash
   dotnet restore
   ```

3. Configure o banco de dados:
   - Atualize o arquivo `appsettings.json` no projeto `BlazorBookStore.Blazor` com a sua string de conexão do SQL Server.
   - Aplique as migrações:
     ```bash
     dotnet ef database update --project BlazorBookStore.Infrastructure
     ```

4. Execute a aplicação:
   ```bash
   dotnet run --project BlazorBookStore.Blazor
   ```

### Rotas Padrão
- `/` - Página Inicial
- `/books` - Visualizar todos os livros
- `/books/new` - Adicionar um novo livro
- `/books/edit/{id}` - Editar um livro existente

---

## Tecnologias Utilizadas
- **Blazor**: Para a interface do usuário.
- **Entity Framework Core**: Para a interação com o banco de dados.
- **Bootstrap**: Para design responsivo.
- **Injeção de Dependência**: Utilizando `Microsoft.Extensions.DependencyInjection`.

---

## Esquema do Banco de Dados
A aplicação utiliza a tabela `Books` com os seguintes campos:
- `LivroId` (Chave Primária, int)
- `Titulo` (nvarchar, tamanho máximo 150)
- `Autor` (nvarchar, tamanho máximo 200)
- `Lancamento` (datetime)
- `Capa` (nvarchar)
- `Editora` (int, enum)
- `Categoria` (int, enum)

---

## Contribuindo
Contribuições são bem-vindas! Sinta-se à vontade para fazer um fork do projeto e enviar pull requests.
