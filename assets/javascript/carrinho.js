addEventListener("DOMContentLoaded", () => renderizar_carrinho());
document.addEventListener("usuario-mudou", () => renderizar_carrinho());

function renderizar_carrinho() {
  const usuario = get_usuario();
  const aviso = document.getElementById("carrinho-aviso");
  const grid = document.getElementById("carrinho-grid");

  if (!usuario) {
    grid.hidden = true;
    aviso.hidden = false;
    mostrar_aviso_login(aviso, "Entre na sua conta para ver o carrinho.");
    return;
  }
  aviso.hidden = true;
  grid.hidden = false;

  const cart = get_cart(usuario);
  const lista = document.getElementById("carrinho-itens");

  if (cart.itens.length === 0) {
    lista.innerHTML = `
        <div class="empty-state">
            <p>Seu carrinho está vazio.</p>
            <a href="menu.html" class="btn-primary">Ver cardápio</a>
        </div>`;
  } else {
    lista.innerHTML = cart.itens
      .map(
        (item) => `
        <article class="carrinho-item">
            <img src="${imagem_produto(item.id)}" alt="${escapar_html(item.nome)}" loading="lazy" />
            <div class="carrinho-item-info">
                <h3>${escapar_html(item.nome)}</h3>
                <p>${formatar_preco(item.preco)} cada</p>
                <button type="button" class="link-btn" data-acao="remover" data-id="${item.id}">Remover</button>
            </div>
            <div class="carrinho-acoes">
                <div class="carrinho-qtd">
                    <button type="button" data-acao="menos" data-id="${item.id}" aria-label="Diminuir quantidade">−</button>
                    <span>${item.quantidade}</span>
                    <button type="button" data-acao="mais" data-id="${item.id}" aria-label="Aumentar quantidade">+</button>
                </div>
                <strong class="carrinho-subtotal">${formatar_preco(item.preco * item.quantidade)}</strong>
            </div>
        </article>`,
      )
      .join("");
  }

  document.getElementById("resumo-qtd").textContent = contar_itens(cart);
  document.getElementById("resumo-total").textContent = formatar_preco(total_carrinho(cart));
  document.getElementById("carrinho-comprar").disabled = cart.itens.length === 0;
  update_cart_count();
}

document.addEventListener("click", (e) => {
  const acao = e.target.closest("#carrinho-itens [data-acao]");
  if (acao) {
    const id = Number(acao.dataset.id);
    if (acao.dataset.acao === "mais") alterar_quantidade(id, 1);
    if (acao.dataset.acao === "menos") alterar_quantidade(id, -1);
    if (acao.dataset.acao === "remover") remover_item(id);
    renderizar_carrinho();
    return;
  }

  if (e.target.closest("#carrinho-comprar")) {
    if (comprar()) {
      alert("Pedido realizado! Você pode acompanhá-lo em Meus pedidos.");
      window.location.href = "pedidos.html";
    }
  }
});
