addEventListener("DOMContentLoaded", () => {
  let form = document.querySelector(".singin-form");

  form.addEventListener("submit", async (e) => {
    e.preventDefault();

    let dados = Object.fromEntries(new FormData(form));
    for (let campo in dados) {
      dados[campo] = dados[campo].trim();
    }

    let cliente;
    try {
      cliente = await add_json_record("clientes.json", (clientes) => {
        if (
          clientes.some((c) => c.email === dados.email || c.cpf === dados.cpf)
        ) {
          throw new Error("Já existe uma conta com este e-mail ou CPF.");
        }
        let novo = { id: next_id(clientes), ...dados };
        clientes.push(novo);
        return novo;
      });
    } catch (erro) {
      alert(erro.message);
      return;
    }

    if (!cliente) {
      alert(
        "Este navegador não consegue gravar data/clientes.json. Use o Chrome ou o Edge. Você entrou só nesta sessão, sem id no banco."
      );
      cliente = { id: null, ...dados };
    }

    // a senha fica só no JSON; o localStorage guarda só os dados da sessão
    let { senha, ...usuario } = cliente;
    localStorage.setItem("usuario", JSON.stringify(usuario));

    alert("Conta criada!");
    window.location.href = "menu.html";
  });
});
