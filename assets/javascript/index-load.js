addEventListener("DOMContentLoaded", async (e) => {
  products = await (await fetch("data/produtos.json")).json();
  await put_products("Esquenta black friday");
});

