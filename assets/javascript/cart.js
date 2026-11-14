function get_cart(usuario) {
  let cart = JSON.parse(localStorage.getItem("carrinho"));
  if (!cart || cart.id_usuario !== usuario.id) {
    cart = { id_usuario: usuario.id, itens: [] };
  }
  return cart;
}

function save_cart(cart) {
  localStorage.setItem("carrinho", JSON.stringify(cart));
}

function formatar_preco(valor) {
  return Number(valor).toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
}

function formatar_data(data) {
  let [dia, hora] = data.split(" ");
  let [ano, mes, d] = dia.split("-");
  return `${d}/${mes}/${ano} às ${hora.slice(0, 5)}`;
}

function data_atual() {
  let d = new Date();
  let p = (n) => String(n).padStart(2, "0");
  return `${d.getFullYear()}-${p(d.getMonth() + 1)}-${p(d.getDate())} ${p(d.getHours())}:${p(d.getMinutes())}:${p(d.getSeconds())}`;
}

function imagem_produto(id) {
  return `assets/img/products/${String(id).padStart(3, "0")}.webp`;
}

function contar_itens(cart) {
  return cart.itens.reduce((soma, i) => soma + i.quantidade, 0);
}

function total_carrinho(cart) {
  return cart.itens.reduce((soma, i) => soma + i.preco * i.quantidade, 0);
}

// Atualiza o contador do carrinho na barra de navegação
function update_cart_count() {
  const badge = document.getElementById("cart-count");
  if (!badge) return;
  const usuario = get_usuario();
  const total = usuario ? contar_itens(get_cart(usuario)) : 0;
  badge.textContent = total;
  badge.hidden = total === 0;
}

function abrir_dialog(id) {
  const dialog = document.getElementById(id);
  if (dialog && !dialog.open) dialog.showModal();
}

function open_login() {
  abrir_dialog("login-dialog");
}

// Lista de itens do carrinho rápido (diálogo)
function show_cart(cart) {
  const items = document.getElementById("cart-items");
  const total = document.getElementById("cart-total-price");
  const buy = document.getElementById("cart-buy");
  if (!items || !total || !buy) return;

  items.innerHTML = "";
  if (cart.itens.length === 0) {
    items.innerHTML = "<p>Seu carrinho está vazio.</p>";
  }

  for (let item of cart.itens) {
    let row = document.createElement("div");
    row.className = "cart-item";
    row.innerHTML =
      `<span>${item.quantidade}x ${escapar_html(item.nome)}</span>` +
      `<span>${formatar_preco(item.preco * item.quantidade)}</span>`;
    items.appendChild(row);
  }

  total.textContent = formatar_preco(total_carrinho(cart));
  buy.disabled = cart.itens.length === 0;
}

function add_to_cart(product) {
  const usuario = get_usuario();
  if (!usuario) {
    open_login();
    return;
  }

  const cart = get_cart(usuario);
  const item = cart.itens.find((i) => i.id === product.id);

  if (item) {
    if (item.quantidade < 99) item.quantidade++;
  } else {
    cart.itens.push({
      id: product.id,
      nome: product.nome,
      preco: Number(product.preco),
      quantidade: 1,
    });
  }

  save_cart(cart);
  update_cart_count();
  show_cart(cart);
  abrir_dialog("cart-dialog");
}

function alterar_quantidade(id, delta) {
  const usuario = get_usuario();
  if (!usuario) return;
  const cart = get_cart(usuario);
  const item = cart.itens.find((i) => i.id === id);
  if (!item) return;
  item.quantidade = Math.min(99, Math.max(1, item.quantidade + delta));
  save_cart(cart);
  update_cart_count();
}

function remover_item(id) {
  const usuario = get_usuario();
  if (!usuario) return;
  const cart = get_cart(usuario);
  cart.itens = cart.itens.filter((i) => i.id !== id);
  save_cart(cart);
  update_cart_count();
}

// Transforma o carrinho em pedido. Retorna true se o pedido foi criado.
function comprar() {
  const usuario = get_usuario();
  if (!usuario) return false;
  const cart = get_cart(usuario);
  if (cart.itens.length === 0) return false;

  const pedidos = get_lista("pedidos");
  const itens = get_lista("itens_pedido");

  const pedido = {
    id: next_id(pedidos),
    cliente_id: usuario.id,
    entregador_id: null,
    data_pedido: data_atual(),
    status: "Recebido",
    observacoes: null,
    forma_pagamento: null,
    taxa_entrega: null,
  };
  pedidos.push(pedido);

  for (let item of cart.itens) {
    itens.push({
      id: next_id(itens),
      pedido_id: pedido.id,
      produto_id: item.id,
      qtd: item.quantidade,
      preco_unitario: item.preco,
    });
  }

  save_lista("pedidos", pedidos);
  save_lista("itens_pedido", itens);
  save_cart({ id_usuario: usuario.id, itens: [] });
  update_cart_count();
  return true;
}

document.addEventListener("click", (e) => {
  if (e.target.closest("#cart-buy")) {
    const usuario = get_usuario();
    if (!usuario) return;
    if (comprar()) {
      show_cart(get_cart(usuario));
      alert("Pedido realizado! Você pode acompanhá-lo em Meus pedidos.");
    }
  }
});
