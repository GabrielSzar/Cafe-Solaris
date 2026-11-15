# Café Solaris ☕

Site de delivery de café com cardápio online, carrinho, pedidos e área do cliente, feito com HTML, CSS e JavaScript puros. Os dados ficam no navegador (localStorage), então o projeto roda sem servidor de banco de dados.

Também existe uma aplicação desktop em Windows Forms (C#) para gerenciar clientes, entregadores, produtos e pedidos em um banco MySQL. Ela está em [`Cafe-Solaris-Win-Forms/`](Cafe-Solaris-Win-Forms/README.md).

---

## Funcionalidades (site)

- **Página inicial:** apresentação do café, benefícios (preparo sob demanda, cancelamento sem custo, temperatura certa), destaques da Black Friday, passo a passo de como funciona e chamada para o cardápio.
- **Cardápio:** 63 produtos em 6 categorias, com busca por nome ou descrição e filtro por categoria.
- **Cadastro e login:** cadastro com validação de campos; login em pop-up na própria barra de navegação.
- **Carrinho:** adicionar produtos (exige login), alterar quantidades, remover itens e finalizar a compra.
- **Meus pedidos:** lista de pedidos com número, data, itens, total e status.
- **Área do cliente:** dados pessoais e endereço de entrega.
- **Modo claro e escuro:** botão na barra de navegação. A escolha fica salva no navegador.
- **Responsivo:** funciona em celular, tablet e desktop. Em telas menores, a barra vira um menu recolhível.

### Regras de formulário

- Telefone, CPF e CEP têm máscara de formatação e aceitam só números.
- O campo Número aceita somente dígitos.
- Cada campo tem limite de caracteres.
- A senha precisa ter no mínimo 6 caracteres.
- O CPF é validado pelos dígitos verificadores.
- E-mail e CPF não podem se repetir entre contas.

## Tecnologias

- HTML5, CSS3 (variáveis, Grid, Flexbox e media queries) e JavaScript (ES2020+)
- Font Awesome (ícones) e Google Fonts (Lato) via CDN
- localStorage para clientes, carrinho, pedidos e preferência de tema

## Estrutura

```
Cafe-Solaris/
├── index.html          # Página inicial
├── menu.html           # Cardápio
├── singin.html         # Cadastro
├── carrinho.html       # Carrinho de compras
├── pedidos.html        # Meus pedidos
├── usuario.html        # Área do cliente (dados pessoais e endereço)
├── assets/
│   ├── components/     # Trechos reutilizados: nav, rodapé, login, carrinho e cards
│   ├── css/            # Estilos de cada página (global.css tem o tema e a barra)
│   ├── img/            # Logo, banners e imagens dos produtos (products/001.webp…063.webp)
│   └── javascript/     # Lógica de cada página e funções compartilhadas
├── data/
│   ├── produtos.json   # Catálogo usado no cardápio, no carrinho e nos pedidos
│   └── cafe-solaris.sql# Dump do banco MySQL (estrutura e dados de exemplo)
├── Cafe-Solaris-Win-Forms/  # Aplicação desktop em C#
└── README.md
```

## Como rodar o site

Você precisa de um servidor local. Abrir o `index.html` direto no navegador (`file://`) não carrega o cardápio, porque os componentes e os produtos são lidos com `fetch`.

Com Node.js instalado, dentro da pasta do projeto:

```bash
npx live-server
```

Ou use qualquer servidor estático, como a extensão Live Server do VS Code.

## Como os dados são guardados

Tudo fica no `localStorage` do navegador. Cada navegador tem os próprios dados.

| Chave          | Conteúdo                                              |
| -------------- | ----------------------------------------------------- |
| `clientes`     | Contas cadastradas (com senha)                        |
| `usuario`      | Usuário logado (sem a senha)                          |
| `carrinho`     | Itens do carrinho do usuário logado                   |
| `pedidos`      | Pedidos feitos                                        |
| `itens_pedido` | Itens de cada pedido, com quantidade e preço unitário |
| `theme`        | Tema escolhido (`dark` ou `light`)                    |

Para limpar tudo, apague os dados do site pelas ferramentas de desenvolvedor do navegador.

## Parte desktop (Windows Forms)

Aplicação em C# (.NET Framework 4.7.2) com MySQL. O passo a passo completo está em [`Cafe-Solaris-Win-Forms/README.md`](Cafe-Solaris-Win-Forms/README.md). Resumo:

1. Instale o pacote **Newtonsoft.Json** pelo NuGet (ele não vem no projeto).
2. Rode `dados/ajustes-banco.sql` no MySQL uma vez.
3. Importe os JSON de exemplo nesta ordem: clientes → entregadores → produtos → pedidos → itens_pedido.
   A conexão está em `Conexao.cs` (banco `cafe_solaris`, porta 3306, usuário `root`). Ajuste a senha para o seu ambiente.

## Créditos

[@Guilherme Alves](https://github.com/guialcosta) [@Gabriel Souza](https://github.com/GabrielSzar) · [2026]
