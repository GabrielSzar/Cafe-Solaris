const phone = document.body.querySelector("#numero_telefone");
const cpf = document.body.querySelector("#cpf");
const cep = document.body.querySelector("#cep");
phone.addEventListener("input", (e) => {
  let value = e.target.value;
  value = value.replace(/\D/g, "").slice(0, 11);
  value = value.replace(/^(\d{2})(\d)/g, "($1) $2");
  value = value.replace(/(\d)(\d{4})$/, "$1-$2");
  e.target.value = value;
});
cpf.addEventListener("input", (e) => {
  let value = e.target.value;
  value = value.replace(/\D/g, "").slice(0, 11);
  value = value.replace(/(\d{3})(\d)/, "$1.$2");
  value = value.replace(/(\d{3})(\d)/, "$1.$2");
  value = value.replace(/(\d{3})(\d{1,2})$/, "$1-$2");

  e.target.value = value;
});
cep.addEventListener("input", (e) => {
  let value = e.target.value;
  value = value.replace(/\D/g, "").slice(0, 8);
  value = value.replace(/^(\d{5})(\d)/, "$1-$2");
  e.target.value = value;
});
