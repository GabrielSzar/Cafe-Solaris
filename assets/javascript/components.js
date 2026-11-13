async function load_components() {
  let footer = document.getElementById("footer-container");
  let nav = document.getElementById("nav-container");
  let template_footer = await (await fetch("assets/components/footer.html")).text();
  let template_nav = await (await fetch("assets/components/nav.html")).text();
  let template_login = await (await fetch("assets/components/login-modal.html")).text();
  footer.innerHTML = template_footer;
  nav.innerHTML = template_nav;
  document.body.insertAdjacentHTML("beforeend", template_login);
}
addEventListener("DOMContentLoaded", async (e) =>  {
  await load_components();
});
