addEventListener("DOMContentLoaded", () => renderizar_pedidos());
document.addEventListener("usuario-mudou", () => renderizar_pedidos());

async function renderizar_pedidos() {
  const usuario = get_usuario();
  const aviso = document.getElementById("pedidos-aviso");
  const card = document.getElementById("pedidos-card");
  const lista = document.getElementById("orders-list");

  if (!usuario) {
    card.hidden = true;
    aviso.hidden = false;
    mostrar_aviso_login(aviso, "Entre na sua conta para ver seus pedidos.");
    return;
  }
  aviso.hidden = true;
  card.hidden = false;

  const pedidos = get_lista("pedidos")
    .filter((p) => p.cliente_id === usuario.id)
    .reverse();

  if (pedidos.length === 0) {
    lista.innerHTML = `
        <div class="empty-state">
            <p>Você ainda não fez nenhum pedido.</p>
            <a href="menu.html" class="btn-primary">Ver cardápio</a>
        </div>`;
    return;
  }

  const [template, produtos] = await Promise.all([
    fetch("assets/components/order-card.html").then((r) => r.text()),
    fetch("data/produtos.json").then((r) => r.json()),
  ]);
  const itens = get_lista("itens_pedido");

  lista.innerHTML = "";
  for (const pedido of pedidos) {
    const do_pedido = itens.filter((i) => i.pedido_id === pedido.id);
    const total = do_pedido.reduce((soma, i) => soma + i.qtd * i.preco_unitario, 0);
    const linhas = do_pedido
      .map((i) => {
        const produto = produtos.find((p) => p.id === i.produto_id);
        const nome = produto ? produto.nome : `Produto ${i.produto_id}`;
        return `<strong>${i.qtd}x</strong> ${escapar_html(nome)}`;
      })
      .join("<br>");

    const wrapper = document.createElement("div");
    wrapper.innerHTML = template;
    const card_pedido = wrapper.querySelector(".order-item-card");

    card_pedido.querySelector(".order-code").textContent =
      `Pedido #${String(pedido.id).padStart(4, "0")}`;

    const status = card_pedido.querySelector(".order-status-tag");
    if (pedido.status === "Recebido") {
      status.classList.add("status-received");
    }
    status.innerHTML = `<i class="fa-solid fa-clock"></i> ${escapar_html(pedido.status)}`;

    card_pedido.querySelector(".order-date").innerHTML =
      `<i class="fa-regular fa-calendar"></i> ${formatar_data(pedido.data_pedido)}`;
    card_pedido.querySelector(".order-description").innerHTML = linhas;
    card_pedido.querySelector(".order-total-value").textContent = formatar_preco(total);

    lista.appendChild(card_pedido);
  }
}
