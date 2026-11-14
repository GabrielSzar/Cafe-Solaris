// Máscaras de formatação: o usuário digita só números e a máscara é aplicada
function formatar_telefone(valor) {
  const d = somente_digitos(valor).slice(0, 11);
  if (d.length === 0) return "";
  if (d.length <= 2) return `(${d}`;
  if (d.length <= 6) return `(${d.slice(0, 2)}) ${d.slice(2)}`;
  if (d.length <= 10) return `(${d.slice(0, 2)}) ${d.slice(2, 6)}-${d.slice(6)}`;
  return `(${d.slice(0, 2)}) ${d.slice(2, 7)}-${d.slice(7)}`;
}

function formatar_cpf(valor) {
  const d = somente_digitos(valor).slice(0, 11);
  let r = d.slice(0, 3);
  if (d.length > 3) r += "." + d.slice(3, 6);
  if (d.length > 6) r += "." + d.slice(6, 9);
  if (d.length > 9) r += "-" + d.slice(9, 11);
  return r;
}

function formatar_cep(valor) {
  const d = somente_digitos(valor).slice(0, 8);
  return d.length > 5 ? `${d.slice(0, 5)}-${d.slice(5)}` : d;
}

// Confere os dígitos verificadores do CPF
function cpf_valido(cpf) {
  const d = somente_digitos(cpf);
  if (d.length !== 11 || /^(\d)\1{10}$/.test(d)) return false;
  for (let t = 9; t < 11; t++) {
    let soma = 0;
    for (let i = 0; i < t; i++) {
      soma += Number(d[i]) * (t + 1 - i);
    }
    const digito = ((soma * 10) % 11) % 10;
    if (Number(d[t]) !== digito) return false;
  }
  return true;
}

document.addEventListener("input", (e) => {
  const campo = e.target;
  if (!(campo instanceof HTMLInputElement)) return;

  switch (campo.dataset.mask) {
    case "telefone":
      campo.value = formatar_telefone(campo.value);
      break;
    case "cpf":
      campo.value = formatar_cpf(campo.value);
      break;
    case "cep":
      campo.value = formatar_cep(campo.value);
      break;
  }

  if (campo.hasAttribute("data-apenas-numeros")) {
    campo.value = somente_digitos(campo.value);
  }
});
