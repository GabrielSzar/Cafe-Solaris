const currency_formatter = new Intl.NumberFormat("pt-BR", {
  style: "currency",
  currency: "BRL",
});

let products = [];
let categories = [];

async function render_products(products_list) {
  let grid = document.getElementById("products-grid");
  if (!grid) {
    return;
  }

  let card = await (await fetch("assets/components/product-card.html")).text();
  grid.innerHTML = "";

  if (products_list.length === 0) {
    grid.innerHTML = "<p>Nenhum produto encontrado.</p>";
    return;
  }

  for (let i = 0; i < products_list.length; i++) {
    let product = products_list[i];
    let card_element = document.createElement("div");
    card_element.innerHTML = card;

    let formatted_id = String(product.id).padStart(3, "0");
    card_element.querySelector("img").src = `assets/img/products/${formatted_id}.webp`;
    card_element.querySelector(".product-name").innerHTML = product.nome;
    card_element.querySelector(".tag").innerHTML = product.categoria;
    card_element.querySelector(".product-card-price").innerHTML = currency_formatter.format(
      Number(product.preco)
    );

    grid.appendChild(card_element);
  }
}

function filter_products(category, search) {
  let filtered_products = [];

  for (let i = 0; i < products.length; i++) {
    let product = products[i];
    let matches_category = true;
    let matches_search = true;

    if (category && category !== "no-filter" && category !== "todos") {
      if (product.categoria.toLowerCase() !== category.toLowerCase()) {
        matches_category = false;
      }
    }

    if (search && search.trim() !== "") {
      let term = search.toLowerCase().trim();
      let name = product.nome.toLowerCase();
      let description = product.descricao ? product.descricao.toLowerCase() : "";

      if (!name.includes(term) && !description.includes(term)) {
        matches_search = false;
      }
    }

    if (matches_category && matches_search) {
      filtered_products.push(product);
    }
  }

  return filtered_products;
}

function update_title(category, search) {
  let search_h2 = document.getElementById("search-h2");
  if (!search_h2) {
    return;
  }

  let has_category = category && category !== "no-filter" && category !== "todos";
  let has_search = search && search.trim() !== "";

  if (has_category && has_search) {
    search_h2.textContent = `Filtrando por "${category}" e busca "${search}"`;
  } else if (has_category) {
    search_h2.textContent = `Filtrando por ${category}`;
  } else if (has_search) {
    search_h2.textContent = `Resultados para "${search}"`;
  } else {
    search_h2.textContent = "";
  }
}

async function put_products(category_filter, search_filter) {
  let filtered = filter_products(category_filter, search_filter);
  update_title(category_filter, search_filter);
  await render_products(filtered);
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
  if (!cat_nav) {
    return;
  }
  cat_nav.replaceChildren();

  for (let i = 0; i < categories.length; i++) {
    let card_element = document.createElement("div");
    card_element.innerHTML = categories_card;
    card_element.querySelector(".category-nav").dataset.category =
      categories[i].categoria;
    let formatted_id = String(categories[i].id).padStart(3, "0");
    card_element.querySelector(".category-img").src =
      `assets/img/products/${formatted_id}.webp`;
    card_element.querySelector(".category-name").innerHTML = categories[i].categoria;

    let btn = card_element.querySelector("button");
    btn.addEventListener("click", async () => {
      let params = new URLSearchParams(window.location.search);
      let clicked_category = btn.dataset.category;

      if (params.get("categoria") === clicked_category) {
        params.delete("categoria");
      } else {
        params.set("categoria", clicked_category);
      }

      let query_string = params.toString();
      let new_url = query_string ? "menu.html?" + query_string : "menu.html";

      try {
        window.history.pushState({}, "", new_url);
        await apply_url_filters();
      } catch (e) {
        window.location.href = new_url;
      }
    });

    cat_nav.appendChild(card_element);
  }
}

async function apply_url_filters() {
  let params = new URLSearchParams(window.location.search);
  let category = params.get("categoria");
  let search = params.get("busca");

  let menu_input = document.querySelector("#search-menu input");
  if (menu_input) {
    menu_input.value = search ? search : "";
  }
  let nav_input = document.querySelector("#nav-search input");
  if (nav_input) {
    nav_input.value = search ? search : "";
  }

  update_title(category, search);
  let filtered_products = filter_products(category, search);
  await render_products(filtered_products);
}