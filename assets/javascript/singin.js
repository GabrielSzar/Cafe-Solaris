addEventListener("DOMContentLoaded", () => {
  let form = document.querySelector(".singin-form");

  form.addEventListener("submit", (e) => {
    e.preventDefault();

    let dados = Object.fromEntries(new FormData(form));
    for (let campo in dados) {
      dados[campo] = dados[campo].trim();
    }

    // a tabela clientes tem UNIQUE em email e cpf
    let clientes = get_lista("clientes");
    if (
      clientes.some((c) => c.email === dados.email || c.cpf === dados.cpf)
    ) {
      alert("Já existe uma conta com este e-mail ou CPF.");
      return;
    }

    let novo = { id: next_id(clientes), ...dados };
    clientes.push(novo);
    save_lista("clientes", clientes);
    login_usuario(novo);

    alert("Conta criada!");
    window.location.href = "menu.html";
  });
});
