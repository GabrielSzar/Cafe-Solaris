addEventListener("DOMContentLoaded", async (e) => {
  // Load data from JSON
  products = await (await fetch("data/produtos.json")).json();
  categories = await get_categories();

  // Render category buttons on screen
  await put_categories();

  // Apply URL filters (category and search) and render products
  await apply_url_filters();

  // Add submit event listener to menu search form
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

      try {
        window.history.pushState({}, "", new_url);
        await apply_url_filters();
      } catch (err) {
        window.location.href = new_url;
      }
    });
  }
});

// Update products list when user clicks browser back/forward buttons
window.addEventListener("popstate", async () => {
  await apply_url_filters();
});

// Intercept nav search submit when submitted inside menu page
document.addEventListener("submit", async (event) => {
  if (event.target && event.target.id === "nav-search" && document.getElementById("search-menu")) {
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

    try {
      window.history.pushState({}, "", new_url);
      await apply_url_filters();
    } catch (err) {
      window.location.href = new_url;
    }
  }
});
