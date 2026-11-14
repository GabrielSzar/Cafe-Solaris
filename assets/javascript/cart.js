let cart_key = "carrinho";

addEventListener("DOMContentLoaded", async (e) => {
  let dialog_html = await (
    await fetch("assets/components/cart-dialog.html")
  ).text();
  document.body.insertAdjacentHTML("beforeend", dialog_html);
});

function get_cart() {
  return JSON.parse(localStorage.getItem(cart_key)) || [];
}

function save_cart(cart) {
  localStorage.setItem(cart_key, JSON.stringify(cart));
}

function add_to_cart(product) {
  let cart = get_cart();
  let item = cart.find((i) => i.id === product.id);

  if (item) {
    item.quantidade++;
  } else {
    cart.push({
      id: product.id,
      nome: product.nome,
      preco: Number(product.preco),
      quantidade: 1,
    });
  }

  save_cart(cart);
  show_cart(cart);
}

function show_cart(cart) {
  let dialog = document.getElementById("cart-dialog");
  let items = document.getElementById("cart-items");
  let total = document.getElementById("cart-total-price");
  if (!dialog) {
    return;
  }

  items.innerHTML = "";
  let sum = 0;

  for (let i = 0; i < cart.length; i++) {
    let subtotal = cart[i].preco * cart[i].quantidade;
    sum += subtotal;

    let li = document.createElement("li");
    li.innerHTML =
      `<span>${cart[i].quantidade}x ${cart[i].nome}</span>` +
      `<span>${currency_formatter.format(subtotal)}</span>`;
    items.appendChild(li);
  }

  total.textContent = currency_formatter.format(sum);
}
document.querySelector("#cart-buy")
addEventListener("click", () => {
  cart = [];
});