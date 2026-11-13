const fmt_moeda = new Intl.NumberFormat(`pt-BR`, {
  style: `currency`,
 currency: `BRL`  
});
async function read_products_json() {
  return await (await fetch("data/produtos.json")).json();
}

async function put_products(category_filter) {
  const products = await read_products_json();
  let grid = document.getElementById("products-grid");
  let card = await (await fetch("assets/components/product-card.html")).text();
  for (let i = 0; i < products.length; i++) {
    let temp = document.createElement("div");
    temp.innerHTML = card;
    temp.querySelector("img").src =
      `assets/img/products/${`${products[i].id}`.padStart(3, "0")}.webp`;
    temp.querySelector(".product-name").innerHTML = products[i].nome;
    temp.querySelector(".tag").innerHTML = products[i].categoria;
    temp.querySelector(".product-card-price").innerHTML =  fmt_moeda.format(Number(products[i].preco));
    grid.appendChild(temp);
  }
}
async function get_categories() {
  products = await read_products_json();
  let categories = [products[0]];
  for (let i = 1; i < products.length; i++) {
    if (!categories.some((c) => c.categoria === products[i].categoria)) {
      categories.push(products[i]);
    }
  }
  return categories;
}
async function put_categories() {
  let categories = await get_categories();
  let categories_card = await (await fetch("assets/components/category-card.html")).text();
  let cat_nav = document.querySelector("#categories");
  for (let i = 0; i < categories.length; i++) {
    let temp = document.createElement("div");
    temp.innerHTML = categories_card;
    temp.querySelector(".category-img").src =
      `assets/img/products/${`${categories[i].id}`.padStart(3, "0")}.webp`;
    temp.querySelector(".category-name").innerHTML = categories[i].categoria;
    cat_nav.appendChild(temp);
  }
}
addEventListener("DOMContentLoaded", async (e) => {
  await put_categories();
  await put_products("10"); 
})