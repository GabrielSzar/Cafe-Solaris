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

  let order_card_template = await (
    await fetch("assets/components/order-card.html")
  ).text();
  let produtos = await (await fetch("data/produtos.json")).json();
  let itens = get_lista("itens_pedido");
  list.innerHTML = "";

  for (let pedido of pedidos) {
    let do_pedido = itens.filter((i) => i.pedido_id === pedido.id);
    let total = do_pedido.reduce(
      (soma, i) => soma + i.qtd * i.preco_unitario,
      0,
    );
    let linhas = do_pedido
      .map((i) => {
        let produto = produtos.find((p) => p.id === i.produto_id);
        let nome = produto ? produto.nome : `Produto ${i.produto_id}`;
        return `<strong>${i.qtd}x</strong> ${nome}`;
      })
      .join("<br>");

    let card_element = document.createElement("div");
    card_element.innerHTML = order_card_template;
    let card = card_element.firstElementChild;

    card.querySelector(".order-code").textContent = `Pedido #${String(
      pedido.id,
    ).padStart(4, "0")}`;

    let status_tag = card.querySelector(".order-status-tag");
    if (pedido.status === "Recebido") {
      status_tag.classList.add("status-received");
    }
    status_tag.innerHTML = `<i class="fa-solid fa-clock"></i> ${pedido.status}`;

    card.querySelector(".order-date").innerHTML =
      `<i class="fa-regular fa-calendar"></i> ${formatar_data(
        pedido.data_pedido,
      )}`;

    card.querySelector(".order-description").innerHTML = linhas;
    card.querySelector(".order-total-value").textContent =
      formatar_preco(total);

    list.appendChild(card);
  }
}

function formatar_data(data) {
  let [dia, hora] = data.split(" ");
  let [ano, mes, d] = dia.split("-");
  return `${d}/${mes}/${ano} às ${hora.slice(0, 5)}`;
}
