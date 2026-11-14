// Carrinho: fica no localStorage, preso ao id do cliente logado.
// Só existe carrinho quando há um usuário salvo pelo cadastro (singin.js).

function get_usuario() {
  return JSON.parse(localStorage.getItem("usuario"));
}

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
  return valor.toLocaleString("pt-BR", { style: "currency", currency: "BRL" });
}

function data_atual() {
  let d = new Date();
  let p = (n) => String(n).padStart(2, "0");
  return `${d.getFullYear()}-${p(d.getMonth() + 1)}-${p(d.getDate())} ${p(d.getHours())}:${p(d.getMinutes())}:${p(d.getSeconds())}`;
}

function open_login() {
  let login = document.getElementById("login-dialog");
  if (login && !login.open) {
    login.showModal();
  }
}

function open_cart() {
  let usuario = get_usuario();
  if (!usuario) {
    open_login();
    return;
  }
  show_cart(get_cart(usuario));
  let cart_dialog = document.getElementById("cart-dialog");
  if (!cart_dialog.open) {
    cart_dialog.showModal();
  }
}

function show_cart(cart) {
  let items = document.getElementById("cart-items");
  let total = document.getElementById("cart-total-price");
  let buy = document.getElementById("cart-buy");

  items.innerHTML = "";
  if (cart.itens.length === 0) {
    items.innerHTML = "<p>Seu carrinho está vazio.</p>";
  }

  let sum = 0;
  for (let item of cart.itens) {
    let subtotal = item.preco * item.quantidade;
    sum += subtotal;

    let row = document.createElement("div");
    row.className = "cart-item";
    row.innerHTML =
      `<span>${item.quantidade}x ${item.nome}</span>` +
      `<span>${formatar_preco(subtotal)}</span>`;
    items.appendChild(row);
  }

  total.textContent = formatar_preco(sum);
  buy.disabled = cart.itens.length === 0;
}

function add_to_cart(product) {
  let usuario = get_usuario();
  if (!usuario) {
    open_login();
    return;
  }

  let cart = get_cart(usuario);
  let item = cart.itens.find((i) => i.id === product.id);

  if (item) {
    item.quantidade++;
  } else {
    cart.itens.push({
      id: product.id,
      nome: product.nome,
      preco: Number(product.preco),
      quantidade: 1,
    });
  }

  save_cart(cart);
}

async function comprar() {
  let usuario = get_usuario();
  if (!usuario) {
    return;
  }
  let cart = get_cart(usuario);
  if (cart.itens.length === 0) {
    return;
  }

  try {
    let pedido = await add_json_record("pedidos.json", (pedidos) => {
      let novo = {
        id: next_id(pedidos),
        cliente_id: usuario.id,
        entregador_id: null,
        data_pedido: data_atual(),
        status: "Recebido",
        observacoes: null,
        forma_pagamento: null,
        taxa_entrega: null,
      };
      pedidos.push(novo);
      return novo;
    });

    if (!pedido) {
      alert(
        "Este navegador não consegue gravar o pedido em data/. Use o Chrome ou o Edge. Seu carrinho foi mantido."
      );
      return;
    }

    await add_json_record("itens_pedido.json", (itens) => {
      for (let item of cart.itens) {
        itens.push({
          id: next_id(itens),
          pedido_id: pedido.id,
          produto_id: item.id,
          qtd: item.quantidade,
          preco_unitario: item.preco,
        });
      }
    });
  } catch (erro) {
    alert("Não foi possível salvar o pedido: " + erro.message);
    return;
  }

  save_cart({ id_usuario: usuario.id, itens: [] });
  show_cart(get_cart(usuario));
  alert("Pedido realizado!");
}

// botões do nav e do dialog existem depois que components.js carrega,
// então o clique é tratado no document
document.addEventListener("click", (e) => {
  if (e.target.closest("#cart-btn")) {
    open_cart();
  }
  if (e.target.closest("#cart-buy")) {
    comprar();
  }
});
