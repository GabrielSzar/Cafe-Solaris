addEventListener("DOMContentLoaded", async (e) => {
  products = await (await fetch("data/produtos.json")).json();
  categories = await get_categories();
  await put_products();
  await put_categories();
});
