using System;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Solaris
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FrmLogin login = new FrmLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new FrmPrincipal());
                }
            }
        }

    internal class Usuario
    {
        private readonly Conexao db = new Conexao();

        public void Cadastrar(string usuario, string senha)
        {
            string usuarioSeguro = usuario.Replace("'", "''");
            string senhaHash = GerarHash(senha);
            string sql = $"INSERT INTO usuarios (usuario, senha_hash) VALUES ('{usuarioSeguro}', '{senhaHash}');";

            db.ExecutarComando(sql);
        }

        public bool Autenticar(string usuario, string senha)
        {
            string usuarioSeguro = usuario.Replace("'", "''");
            string senhaHash = GerarHash(senha);
            string sql = $"SELECT id FROM usuarios WHERE usuario = '{usuarioSeguro}' AND senha_hash = '{senhaHash}' LIMIT 1;";
            DataTable resultado = db.ExecutarConsulta(sql);
            return resultado.Rows.Count > 0;
        }

        public static string GerarHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder hash = new StringBuilder(bytes.Length * 2);

                foreach (byte item in bytes)
                {
                    hash.Append(item.ToString("x2"));
                }

                return hash.ToString();
            }
        }
    }

    internal class FrmLogin : Form
    {
        private readonly TextBox txtUsuario;
        private readonly TextBox txtSenha;
        private readonly Button btnEntrar;
        private readonly Button btnCadastrar;
        private readonly Label lblMensagem;

        public FrmLogin()
        {
            Text = "Login - Café Solaris";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(360, 250);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Controls.Add(new Label { AutoSize = true, Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold), Location = new Point(105, 20), Text = "Café Solaris" });
            Controls.Add(new Label { AutoSize = true, Location = new Point(35, 75), Text = "Usuário" });
            txtUsuario = new TextBox { Location = new Point(125, 72), Size = new Size(190, 26) };
            Controls.Add(txtUsuario);
            Controls.Add(new Label { AutoSize = true, Location = new Point(35, 115), Text = "Senha" });
            txtSenha = new TextBox { Location = new Point(125, 112), PasswordChar = '*', Size = new Size(190, 26) };
            Controls.Add(txtSenha);
            btnEntrar = new Button { Location = new Point(75, 155), Size = new Size(90, 32), Text = "Entrar" };
            btnEntrar.Click += btnEntrar_Click;
            Controls.Add(btnEntrar);
            btnCadastrar = new Button { Location = new Point(180, 155), Size = new Size(105, 32), Text = "Cadastrar" };
            btnCadastrar.Click += btnCadastrar_Click;
            Controls.Add(btnCadastrar);
            lblMensagem = new Label { AutoSize = true, ForeColor = Color.Firebrick, Location = new Point(35, 205) };
            Controls.Add(lblMensagem);
            AcceptButton = btnEntrar;
            Shown += (sender, e) => txtUsuario.Focus();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                lblMensagem.Text = "Informe usuário e senha.";
                return;
            }

            try
            {
                if (new Usuario().Autenticar(txtUsuario.Text.Trim(), txtSenha.Text))
                {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }

                lblMensagem.Text = "Usuário ou senha inválidos.";
                txtSenha.Clear();
                txtSenha.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao realizar login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            using (FrmCadastroUsuario cadastro = new FrmCadastroUsuario())
            {
                cadastro.ShowDialog(this);
            }
        }
    }

    internal class FrmCadastroUsuario : Form
    {
        private readonly TextBox txtUsuario;
        private readonly TextBox txtSenha;
        private readonly TextBox txtConfirmacao;

        public FrmCadastroUsuario()
        {
            Text = "Cadastro de usuário";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(380, 260);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            Controls.Add(new Label { AutoSize = true, Font = new Font("Microsoft Sans Serif", 13F, FontStyle.Bold), Location = new Point(95, 18), Text = "Novo usuário" });
            Controls.Add(new Label { AutoSize = true, Location = new Point(35, 70), Text = "Usuário" });
            txtUsuario = new TextBox { Location = new Point(150, 67), Size = new Size(190, 26) };
            Controls.Add(txtUsuario);
            Controls.Add(new Label { AutoSize = true, Location = new Point(35, 110), Text = "Senha" });
            txtSenha = new TextBox { Location = new Point(150, 107), PasswordChar = '*', Size = new Size(190, 26) };
            Controls.Add(txtSenha);
            Controls.Add(new Label { AutoSize = true, Location = new Point(35, 150), Text = "Confirmar senha" });
            txtConfirmacao = new TextBox { Location = new Point(150, 147), PasswordChar = '*', Size = new Size(190, 26) };
            Controls.Add(txtConfirmacao);

            Button btnSalvar = new Button { Location = new Point(150, 195), Size = new Size(90, 32), Text = "Cadastrar" };
            btnSalvar.Click += btnSalvar_Click;
            Controls.Add(btnSalvar);
            AcceptButton = btnSalvar;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Informe usuário e senha.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtSenha.Text != txtConfirmacao.Text)
            {
                MessageBox.Show("As senhas não conferem.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                new Usuario().Cadastrar(txtUsuario.Text.Trim(), txtSenha.Text);
                MessageBox.Show("Usuário cadastrado com sucesso.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao cadastrar usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    }
}
