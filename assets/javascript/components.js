async function load_components() {
  const nav = document.getElementById("nav-container");
  const footer = document.getElementById("footer-container");

  const [nav_html, footer_html, login_html, cart_html] = await Promise.all([
    fetch("assets/components/nav.html").then((r) => r.text()),
    fetch("assets/components/footer.html").then((r) => r.text()),
    fetch("assets/components/login-modal.html").then((r) => r.text()),
    fetch("assets/components/cart-dialog.html").then((r) => r.text()),
  ]);

  if (nav) nav.innerHTML = nav_html;
  if (footer) footer.innerHTML = footer_html;
  document.body.insertAdjacentHTML("beforeend", login_html);
  document.body.insertAdjacentHTML("beforeend", cart_html);

  marcar_pagina_atual();
  atualizar_nav();
  if (typeof update_toggle_icon === "function") update_toggle_icon();
  if (typeof update_cart_count === "function") update_cart_count();

  const busca = new URLSearchParams(window.location.search).get("busca");
  const nav_input = document.querySelector("#nav-search input");
  if (busca && nav_input) nav_input.value = busca;
}

function marcar_pagina_atual() {
  const atual = window.location.pathname.split("/").pop() || "index.html";
  document.querySelectorAll(".header-nav a[href]").forEach((link) => {
    if (link.getAttribute("href") === atual) {
      link.setAttribute("aria-current", "page");
    }
  });
}

// Abrir/fechar diálogos e o menu do celular (funciona em qualquer navegador)
document.addEventListener("click", (e) => {
  const abrir = e.target.closest("[data-open-dialog]");
  if (abrir) {
    const dialog = document.getElementById(abrir.dataset.openDialog);
    if (dialog && !dialog.open) dialog.showModal();
    fechar_menu_mobile();
    return;
  }

  const fechar = e.target.closest("[data-close-dialog]");
  if (fechar) {
    fechar.closest("dialog")?.close();
    return;
  }

  if (e.target.closest("#nav-toggle")) {
    const painel = document.getElementById("nav-panel");
    const aberto = painel.classList.toggle("open");
    document.getElementById("nav-toggle").setAttribute("aria-expanded", String(aberto));
    return;
  }

  if (e.target.closest("#nav-panel a")) {
    fechar_menu_mobile();
  }
});

function fechar_menu_mobile() {
  const painel = document.getElementById("nav-panel");
  const botao = document.getElementById("nav-toggle");
  if (painel) painel.classList.remove("open");
  if (botao) botao.setAttribute("aria-expanded", "false");
}

addEventListener("DOMContentLoaded", async () => {
  await load_components();
});
