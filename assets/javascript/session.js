function get_lista(chave) {
  return JSON.parse(localStorage.getItem(chave)) || [];
}

function save_lista(chave, lista) {
  localStorage.setItem(chave, JSON.stringify(lista));
}

function next_id(lista) {
  return lista.reduce((max, r) => Math.max(max, r.id), 0) + 1;
}

function somente_digitos(texto) {
  return String(texto ?? "").replace(/\D/g, "");
}

function escapar_html(texto) {
  return String(texto ?? "").replace(
    /[&<>"']/g,
    (c) =>
      ({ "&": "&amp;", "<": "&lt;", ">": "&gt;", '"': "&quot;", "'": "&#39;" })[c],
  );
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

function atualizar_nav() {
  const logado = Boolean(get_usuario());
  document.body.classList.toggle("logged-in", logado);

  const area = document.getElementById("account-area");
  if (!area) return;

  if (logado) {
    area.innerHTML = `<a href="usuario.html" class="nav-link" title="Minha conta" aria-label="Minha conta"><i class="fa-solid fa-user"></i><span class="nav-user-text">Minha conta</span></a>`;
  } else {
    area.innerHTML = `<button type="button" class="nav-link nav-btn" data-open-dialog="login-dialog">Entrar</button><a href="singin.html" class="nav-link nav-outline">Cadastrar</a>`;
  }
}

// Mostra, dentro de um elemento, o aviso pedindo login e os botões de entrar/cadastrar
function mostrar_aviso_login(elemento, mensagem) {
  elemento.innerHTML = `
        <div class="empty-state">
            <p>${escapar_html(mensagem)}</p>
            <div class="empty-actions">
                <button type="button" class="btn-primary" data-open-dialog="login-dialog">Entrar</button>
                <a href="singin.html" class="link-btn">Criar conta</a>
            </div>
        </div>`;
}

document.addEventListener("submit", (e) => {
  if (e.target.id !== "login-dialog-form") return;
  e.preventDefault();

  const form = e.target;
  const email = form.elements.email_login.value.trim().toLowerCase();
  const senha = form.elements.password_login.value;

  const cliente = get_lista("clientes").find(
    (c) => c.email.toLowerCase() === email && c.senha === senha,
  );
  if (!cliente) {
    alert("E-mail ou senha incorretos.");
    return;
  }

  login_usuario(cliente);
  form.reset();
  document.getElementById("login-dialog").close();
  atualizar_nav();
  document.dispatchEvent(new Event("usuario-mudou"));
});
