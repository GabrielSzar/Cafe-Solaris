const fmt_moeda = new Intl.NumberFormat(`pt-BR`, {
  style: `currency`,
  currency: `BRL`,
});
let products = [];
let categories = [];

async function put_products(category_filter, search_filter) {
  const nofilter =
    category_filter == "no-filter" || category_filter == undefined;
  let grid = document.getElementById("products-grid");
  let card = await (await fetch("assets/components/product-card.html")).text();
  let title = document.createElement("h2");
  title.textContent =
    nofilter === false ? `filtrando por ${category_filter}` : "";
  grid.replaceChildren();
  document.body
    .querySelector("main")
    .querySelector("h2")
    .replaceWith(title);
  for (let i = 0; i < products.length; i++) {
    if (products[i].categoria === category_filter || nofilter) {
      let temp = document.createElement("div");
      temp.innerHTML = card;
      temp.querySelector("img").src =
        `assets/img/products/${`${products[i].id}`.padStart(3, "0")}.webp`;
      temp.querySelector(".product-name").innerHTML = products[i].nome;
      temp.querySelector(".tag").innerHTML = products[i].categoria;
      temp.querySelector(".product-card-price").innerHTML = fmt_moeda.format(
        Number(products[i].preco),
      );
      grid.appendChild(temp);
    }
  }
}
async function get_categories() {
  let categories = [products[0]];
  for (let i = 1; i < products.length; i++) {
    if (!categories.some((c) => c.categoria === products[i].categoria)) {
      categories.push(products[i]);
    }
  }
  return categories;
}
async function put_categories() {
  let categories_card = await (
    await fetch("assets/components/category-card.html")
  ).text();
  let cat_nav = document.querySelector("#categories");
  cat_nav.replaceChildren();
  for (let i = 0; i < categories.length; i++) {
    let temp = document.createElement("div");
    temp.innerHTML = categories_card;
    temp.querySelector(".category-nav").dataset.category =
      categories[i].categoria;
    temp.querySelector(".category-img").src =
      `assets/img/products/${`${categories[i].id}`.padStart(3, "0")}.webp`;
    temp.querySelector(".category-name").innerHTML = categories[i].categoria;
    let btn = temp.querySelector("button");
    btn.addEventListener("click", async () => {
      put_products(btn.dataset.category);
    });
    cat_nav.appendChild(temp);
  }
}
