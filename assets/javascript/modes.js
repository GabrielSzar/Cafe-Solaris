// Gerenciamento de tema (Dark / Light Mode) com persistência em localStorage

function apply_theme() {
  const theme = localStorage.getItem("theme");
  if (theme === "dark") {
    document.body.classList.add("dark");
  } else {
    document.body.classList.remove("dark");
  }
  update_toggle_icon();
}

function toggle_theme() {
  const isDark = document.body.classList.toggle("dark");
  localStorage.setItem("theme", isDark ? "dark" : "light");
  update_toggle_icon();
}

function update_toggle_icon() {
  const btn = document.getElementById("toggle-modes");
  if (!btn) return;
  const isDark = document.body.classList.contains("dark");
  if (isDark) {
    btn.innerHTML = '<i class="fa-solid fa-sun"></i>';
  } else {
    btn.innerHTML = '<i class="fa-solid fa-moon"></i>';
  }
  if (
    window.FontAwesome &&
    typeof window.FontAwesome.dom?.i2svg === "function"
  ) {
    window.FontAwesome.dom.i2svg();
  }
}

// Aplica o tema assim que o body estiver disponível
if (document.body) {
  apply_theme();
} else {
  document.addEventListener("DOMContentLoaded", apply_theme);
}

document.addEventListener("DOMContentLoaded", () => {
  apply_theme();
});

// Event delegation para o botão de alternar tema na navbar
document.addEventListener("click", (e) => {
  const btn = e.target.closest("#toggle-modes");
  if (btn) {
    e.preventDefault();
    toggle_theme();
  }
});
