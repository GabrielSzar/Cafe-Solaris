addEventListener("DOMContentLoaded", async (e) => {
  ismenu = false;
  products = await (await fetch("data/produtos.json")).json();
  await put_products("Esquenta black friday");
});

