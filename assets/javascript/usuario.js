addEventListener("DOMContentLoaded", () => {
  let usuario = get_usuario();
  if (!usuario) {
    window.location.replace("index.html");
    return;
  }

  for (let el of document.querySelectorAll("[data-campo]")) {
    let valor = usuario[el.dataset.campo];
    el.textContent = valor ? valor : "Não informado";
  }

  document.querySelector(".logout-link").addEventListener("click", (e) => {
    e.preventDefault();
    logout_usuario();
    window.location.href = "index.html";
  });
});
