// Página do cliente: mostra os dados do usuário logado (localStorage)

addEventListener("DOMContentLoaded", () => {
  let usuario = get_usuario();
  if (!usuario) {
    window.location.replace("index.html");
    return;
  }

  for (let el of document.querySelectorAll("[data-campo]")) {
    let valor = usuario[el.dataset.campo];
    el.textContent = valor ? valor : "Não informado";
  }

  document.querySelector(".logout-link").addEventListener("click", () => {
    logout_usuario();
  });

  mostrar_pedidos(usuario);
});

async function mostrar_pedidos(usuario) {
  let list = document.getElementById("orders-list");
  let pedidos = get_lista("pedidos")
    .filter((p) => p.cliente_id === usuario.id)
    .reverse();

  if (pedidos.length === 0) {
    list.innerHTML = "<p>Você ainda não fez nenhum pedido.</p>";
    return;
  }

  let produtos = await (await fetch("data/produtos.json")).json();
  let itens = get_lista("itens_pedido");
  list.innerHTML = "";

  for (let pedido of pedidos) {
    let do_pedido = itens.filter((i) => i.pedido_id === pedido.id);
    let total = do_pedido.reduce((soma, i) => soma + i.qtd * i.preco_unitario, 0);
    let linhas = do_pedido
      .map((i) => {
        let produto = produtos.find((p) => p.id === i.produto_id);
        let nome = produto ? produto.nome : `Produto ${i.produto_id}`;
        return `<strong>${i.qtd}x</strong> ${nome}`;
      })
      .join("<br>");

    let card = document.createElement("div");
    card.className = "order-item-card";
    card.innerHTML = `
      <div class="order-info-col">
        <div class="order-header-line">
          <span class="order-code">Pedido #${String(pedido.id).padStart(4, "0")}</span>
          <span class="order-status-tag ${pedido.status === "Recebido" ? "status-received" : ""}">
            <i class="fa-solid fa-clock"></i>
            ${pedido.status}
          </span>
        </div>
        <span class="order-date">
          <i class="fa-regular fa-calendar"></i>
          ${formatar_data(pedido.data_pedido)}
        </span>
        <p class="order-description">${linhas}</p>
      </div>
      <div class="order-price-col">
        <span class="order-total-label">Total do Pedido</span>
        <span class="order-total-value">${formatar_preco(total)}</span>
        <a href="menu.html" class="btn-order-details">
          <span>Pedir novamente</span>
          <i class="fa-solid fa-arrow-right"></i>
        </a>
      </div>`;
    list.appendChild(card);
  }
}

// "2026-11-09 20:13:00" -> "09/11/2026 às 20:13"
function formatar_data(data) {
  let [dia, hora] = data.split(" ");
  let [ano, mes, d] = dia.split("-");
  return `${d}/${mes}/${ano} às ${hora.slice(0, 5)}`;
}
