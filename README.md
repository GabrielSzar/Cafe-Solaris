# Café Solaris - Projeto de Integração Interdisciplinar

## Introdução

Um projeto de delivery de café: no site o cliente navega pelo cardápio, adiciona produtos no carrinho, e finaliza a compra. no windows forms, é possivel ver os pedidos, produtos, entregadores e os usuarios, podendo editar e importar dados atraves de um arquivo json.

---

# Frontend

O frontend é um site estático feito com HTML5, CSS3 e JavaScript puro, sem frameworks. O cabeçalho, o rodapé e o modal de login são carregados via JavaScript (`components.js`), e os cards de produtos são montados a partir de `data/produtos.json`.

### Funcionalidades

- **Responsividade:** o menu vira um botão recolhível em telas de até 860px, o carrinho vira uma gaveta na parte inferior em telas de até 600px e as grades de produtos e categorias se ajustam ao tamanho da tela.
- **Máscaras nos formulários:** telefone no formato (00) 00000-0000, CPF no formato 000.000.000-00 e CEP no formato 00000-000. Esses campos aceitam apenas dígitos.
- **Modo claro e escuro:** alternado pelo botão no cabeçalho. A escolha fica salva no `localStorage` (chave `theme`).
- **Busca e filtragem no menu:** a busca usa o parâmetro `busca` na URL e a filtragem por categoria usa o parâmetro `categoria`. Os dois podem ser combinados.
- **Produtos com base no JSON:** o cardápio é montado a partir de `data/produtos.json`, com categoria, descrição, preço e imagem de cada item.

### Armazenamento

Cadastro, login, carrinho e pedidos são guardados no `localStorage` do navegador. O site não grava nem altera nenhum arquivo JSON. Os arquivos em `data/` são somente leitura para o site.

| Chave          | Conteúdo                            |
| -------------- | ----------------------------------- |
| `clientes`     | Cadastros feitos no site            |
| `usuario`      | Usuário logado                      |
| `carrinho`     | Itens do carrinho do usuário logado |
| `pedidos`      | Pedidos finalizados                 |
| `itens_pedido` | Itens dos pedidos finalizados       |
| `theme`        | Tema escolhido (`light` ou `dark`)  |

Para ver os dados salvos, use as ferramentas de desenvolvedor do navegador na aba Application (Chrome) ou Armazenamento (Firefox).

### Como rodar

O site precisa ser aberto por um servidor HTTP. Abrir o `index.html` diretamente pelo sistema de arquivos não funciona, porque o site carrega os componentes e os JSON com `fetch`.

1. Instale o [Node.js](https://nodejs.org).
2. Na pasta raiz do projeto, execute:

```bash
npx live-server
```

3. O navegador abre automaticamente o site em `http://127.0.0.1:8080`.

> [!WARNING]
> Os Jsons não são salvos no front. A branch `File_Sys_API` mostra uma versão que usa a File System Access API do JavaScript para editar os arquivos JSON diretamente no computador. Para mais informações sobre essa versão, consulte essa branch.

---

# Backend

O backend é uma aplicação desktop feita em C# com Windows Forms (.NET Framework 4.7.2). Ela conecta ao MySQL com o pacote MySql.Data.

### Funcionalidades

- **Login:** a aplicação pede usuário e senha antes de abrir. Novos usuários são criados pelo botão Cadastrar na própria tela de login.
- **Visualização e edição com DataGridView:** cada aba mostra uma tabela do banco (clientes, entregadores, produtos, pedidos e itens do pedido) em um DataGridView.
- **Importação de JSON:** cada aba tem um botão para importar um arquivo JSON da tabela correspondente. A importação valida os campos, checa chaves estrangeiras e duplicidades antes de gravar.
- **Integração com MySQL:** a conexão fica em `Conexao.cs`, apontando para `127.0.0.1:3306`, com o banco `cafe_solaris`. Na importação, as senhas dos clientes são convertidas em hash antes de serem gravadas.

> [!WARNING]
> A aplicação Windows Forms não se conecta automaticamente ao site. O site guarda seus dados no `localStorage` do navegador, e os arquivos da pasta `data/` servem apenas como fonte para importação no MySQL. Não existe sincronização entre o site e o banco, e levar dados de um para o outro é um passo manual.

### Como rodar

1. Instale o MySQL Server 8 (ou um pacote como XAMPP ou Laragon que já inclua o MySQL).
2. Crie o banco de dados:

```sql
CREATE DATABASE cafe_solaris;
```

3. Importe a estrutura e os dados de exemplo a partir do arquivo `data/cafe-solaris.sql`, pelo phpMyAdmin ou pelo terminal:

```bash
mysql -u root -p cafe_solaris < data/cafe-solaris.sql
```

4. Abra `Cafe-Solaris-Win-Forms/Cafe-Solaris/Cafe-Solaris.sln` no Visual Studio, com o workload de desenvolvimento para desktop em .NET e o .NET Framework 4.7.2.
5. Restaure os pacotes NuGet e instale o **Newtonsoft.Json**, que é usado pelo importador mas não está listado em `packages.config`.
6. Em `Conexao.cs`, ajuste usuário e senha do MySQL caso o seu ambiente seja diferente do padrão do projeto (`root` sem senha).
7. Execute o projeto, crie um usuário pelo botão Cadastrar na tela de login e entre.
8. Para importar os dados de `data/`, use o botão de importação de cada aba na seguinte ordem: `clientes`, `entregadores`, `produtos`, `pedidos` e `itens_pedido`.

## Créditos

- Backend: [Guilherme Alves](https://github.com/guialcosta)
- Frontend: [Gabriel Souza](https://github.com/GabrielSzar)
