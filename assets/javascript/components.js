async function load_components() {
  let footer = document.getElementById("footer-container");
  let nav = document.getElementById("nav-container");
  let template_footer = await (
    await fetch("assets/components/footer.html")
  ).text();
  let template_nav = await (await fetch("assets/components/nav.html")).text();
  let template_login = await (
    await fetch("assets/components/login-modal.html")
  ).text();
  let cart_dialog = await (
    await fetch("assets/components/cart-dialog.html")
  ).text();
  footer.innerHTML = template_footer;
  nav.innerHTML = template_nav;
  atualizar_nav();
  if (typeof update_toggle_icon === "function") {
    update_toggle_icon();
  }

  document.body.insertAdjacentHTML("beforeend", template_login);
  document.body.insertAdjacentHTML("beforeend", cart_dialog);
  let params = new URLSearchParams(window.location.search);
  let search = params.get("busca");
  if (search) {
    let nav_input = document.querySelector("#nav-search input");
    if (nav_input) {
      nav_input.value = search;
    }
  }
}

addEventListener("DOMContentLoaded", async (e) => {
  await load_components();
});

document.addEventListener("click", (e) => {
  const toggleBtn = e.target.closest("#nav-toggle-btn");
  if (toggleBtn) {
    const nav = document.querySelector(".header-nav");
    if (nav) {
      nav.classList.toggle("nav-open");
      const isOpen = nav.classList.contains("nav-open");
      toggleBtn.setAttribute("aria-expanded", String(isOpen));
      toggleBtn.innerHTML = isOpen
        ? '<i class="fa-solid fa-xmark"></i>'
        : '<i class="fa-solid fa-bars"></i>';
    }
    return;
  }

  const nav = document.querySelector(".header-nav");
  if (nav && nav.classList.contains("nav-open")) {
    if (
      !nav.contains(e.target) ||
      e.target.closest(".mobile-menu-link") ||
      e.target.closest("#account-area a") ||
      e.target.closest("#account-area button")
    ) {
      nav.classList.remove("nav-open");
      const toggle = document.getElementById("nav-toggle-btn");
      if (toggle) {
        toggle.setAttribute("aria-expanded", "false");
        toggle.innerHTML = '<i class="fa-solid fa-bars"></i>';
      }
    }
  }
});

window.addEventListener("resize", () => {
  if (window.innerWidth > 860) {
    const nav = document.querySelector(".header-nav");
    if (nav && nav.classList.contains("nav-open")) {
      nav.classList.remove("nav-open");
      const toggle = document.getElementById("nav-toggle-btn");
      if (toggle) {
        toggle.setAttribute("aria-expanded", "false");
        toggle.innerHTML = '<i class="fa-solid fa-bars"></i>';
      }
    }
  }
});
