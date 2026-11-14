addEventListener("DOMContentLoaded", () => {
  const form = document.querySelector(".singin-form");

  form.addEventListener("submit", (e) => {
    e.preventDefault();

    const dados = Object.fromEntries(new FormData(form));
    for (const campo in dados) {
      dados[campo] = String(dados[campo]).trim();
    }

    const erro = validar_cadastro(dados);
    if (erro) {
      alert(erro);
      return;
    }

    const clientes = get_lista("clientes");
    const email = dados.email.toLowerCase();
    const cpf = somente_digitos(dados.cpf);
    if (clientes.some((c) => c.email.toLowerCase() === email || somente_digitos(c.cpf) === cpf)) {
      alert("Já existe uma conta com este e-mail ou CPF.");
      return;
    }

    const novo = { id: next_id(clientes), ...dados, email };
    clientes.push(novo);
    save_lista("clientes", clientes);
    login_usuario(novo);

    alert("Conta criada com sucesso!");
    window.location.href = "menu.html";
  });
});

function validar_cadastro(d) {
  if (d.nome.split(/\s+/).length < 2) {
    return "Informe seu nome completo (nome e sobrenome).";
  }
  if (!/^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(d.email)) {
    return "Informe um e-mail válido.";
  }
  if (d.senha.length < 6) {
    return "A senha precisa ter no mínimo 6 caracteres.";
  }
  if (somente_digitos(d.numero_telefone).length < 10) {
    return "Informe um telefone válido, com DDD.";
  }
  if (!cpf_valido(d.cpf)) {
    return "CPF inválido. Confira os números digitados.";
  }
  if (somente_digitos(d.cep).length !== 8) {
    return "Informe um CEP com 8 números.";
  }
  if (d.bairro === "" || d.rua === "") {
    return "Preencha bairro e rua.";
  }
  if (!/^\d+$/.test(d.numero)) {
    return "O número do endereço deve conter apenas números.";
  }
  return "";
}
