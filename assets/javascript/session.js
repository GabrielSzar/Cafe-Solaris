// Dados do site no localStorage (no lugar dos JSON de data/).
// "clientes", "pedidos" e "itens_pedido" são listas.
// "usuario" é quem está logado (sem a senha).

function get_lista(chave) {
  return JSON.parse(localStorage.getItem(chave)) || [];
}

function save_lista(chave, lista) {
  localStorage.setItem(chave, JSON.stringify(lista));
}

function next_id(lista) {
  return lista.reduce((max, r) => Math.max(max, r.id), 0) + 1;
}

function get_usuario() {
  return JSON.parse(localStorage.getItem("usuario"));
}

function login_usuario(cliente) {
  let { senha, ...usuario } = cliente;
  localStorage.setItem("usuario", JSON.stringify(usuario));
}

function logout_usuario() {
  localStorage.removeItem("usuario");
}

// troca o botão Log In pelo ícone de usuário quando há login
function atualizar_nav() {
  let area = document.getElementById("account-area");
  if (!area) {
    return;
  }

  if (get_usuario()) {
    area.innerHTML = `<a href="usuario.html" class="nav-link" title="Minha conta"><i class="fa-solid fa-user"></i></a>`;
  } else {
    area.innerHTML = `<button command="show-modal" commandfor="login-dialog" class="nav-link nav-btn">Log In</button>`;
  }
}

// o modal de login existe em todas as páginas; o clique no formulário é tratado no document
document.addEventListener("submit", (e) => {
  if (e.target.id !== "login-dialog-form") {
    return;
  }
  e.preventDefault();

  let form = e.target;
  let email = form.elements.email_login.value.trim();
  let senha = form.elements.password_login.value;

  let cliente = get_lista("clientes").find(
    (c) => c.email === email && c.senha === senha
  );
  if (!cliente) {
    alert("E-mail ou senha incorretos.");
    return;
  }

  login_usuario(cliente);
  form.reset();
  document.getElementById("login-dialog").close();
  atualizar_nav();
});
