addEventListener("DOMContentLoaded", async (e) => {
  ismenu = true;
  products = await (await fetch("data/produtos.json")).json();
  categories = await get_categories();

  await put_categories();

  await apply_url_filters(true);

  let menu_form = document.getElementById("search-menu");
  if (menu_form) {
    menu_form.addEventListener("submit", async (event) => {
      event.preventDefault();
      let input = menu_form.querySelector("input");
      let term = input ? input.value.trim() : "";

      let params = new URLSearchParams(window.location.search);
      if (term !== "") {
        params.set("busca", term);
      } else {
        params.delete("busca");
      }

      let query_string = params.toString();
      let new_url = query_string ? "menu.html?" + query_string : "menu.html";

      window.history.pushState({}, "", new_url);
      await apply_url_filters();
    });
  }
});

document.addEventListener("submit", async (event) => {
  if (
    event.target &&
    event.target.id === "nav-search" &&
    document.getElementById("search-menu")
  ) {
    event.preventDefault();
    let input = event.target.querySelector("input");
    let term = input ? input.value.trim() : "";

    let params = new URLSearchParams(window.location.search);
    if (term !== "") {
      params.set("busca", term);
    } else {
      params.delete("busca");
    }

    let query_string = params.toString();
    let new_url = query_string ? "menu.html?" + query_string : "menu.html";

    window.history.pushState({}, "", new_url);
    await apply_url_filters();
  }
});
