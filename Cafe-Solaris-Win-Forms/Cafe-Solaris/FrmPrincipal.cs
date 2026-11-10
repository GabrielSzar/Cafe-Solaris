using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cafe_Solaris
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
            tbCafeSolaris.SelectedIndexChanged += tbCafeSolaris_SelectedIndexChanged;
            dtGridCafeSolaris.CellClick += dtGridCafeSolaris_CellClick;
            btnSalvar.Click += btnEditar_Click;
            btnSalvarPedido.Click += btnEditar_Click;
            btnSalvarCliente.Click += btnEditar_Click;
            btnSalvarEntregador.Click += btnEditar_Click;
            btnSalvarItemPedido.Click += btnEditar_Click;
            btnExcluir.Click += btnExcluir_Click;
            btnExcluirPedido.Click += btnExcluir_Click;
            btnExcluirCliente.Click += btnExcluir_Click;
            btnExcluirEntregador.Click += btnExcluir_Click;
            btnExcluirItemPedido.Click += btnExcluir_Click;
            btnImportarProdutos.Click += (s, ev) => ImportarJson("produtos");
            btnImportarPedidos.Click += (s, ev) => ImportarJson("pedidos");
            btnImportarClientes.Click += (s, ev) => ImportarJson("clientes");
            btnImportarEntregadores.Click += (s, ev) => ImportarJson("entregadores");
            btnImportarItensPedido.Click += (s, ev) => ImportarJson("itens_pedido");
            btnSalvar.Text = "Editar";
            btnSalvarPedido.Text = "Editar";
            btnSalvarCliente.Text = "Editar";
            btnSalvarEntregador.Text = "Editar";
            btnSalvarItemPedido.Text = "Editar";
            AtualizarGrid();
        }

        private void tbCafeSolaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarGrid();
        }

        private void dtGridCafeSolaris_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dtGridCafeSolaris.Rows.Count)
            {
                CarregarRegistro(dtGridCafeSolaris.Rows[e.RowIndex]);
            }
        }

        private object ValorLinha(DataGridViewRow linha, string coluna)
        {
            if (linha == null || !dtGridCafeSolaris.Columns.Contains(coluna))
            {
                return null;
            }

            object valor = linha.Cells[coluna].Value;
            return valor == null || valor == DBNull.Value ? null : valor;
        }

        private object ValorLinhaAlternativo(DataGridViewRow linha, string colunaPrincipal, string colunaAlternativa)
        {
            if (dtGridCafeSolaris.Columns.Contains(colunaPrincipal))
            {
                return ValorLinha(linha, colunaPrincipal);
            }

            return ValorLinha(linha, colunaAlternativa);
        }

        private DateTime ObterDataPedido(DataGridViewRow linha)
        {
            object valor = ValorLinha(linha, "data_pedido");
            DateTime data;

            if (valor == null || !DateTime.TryParse(Convert.ToString(valor), out data))
            {
                return DateTime.Today;
            }

            if (data < dtpDataPedido.MinDate || data > dtpDataPedido.MaxDate)
            {
                return DateTime.Today;
            }

            return data;
        }

        private void CarregarRegistro(DataGridViewRow linha)
        {
            switch (tbCafeSolaris.SelectedIndex)
            {
                case 0:
                    txtId.Text = Convert.ToString(ValorLinha(linha, "id"));
                    txtNome.Text = Convert.ToString(ValorLinha(linha, "nome"));
                    txtDescricaoProduto.Text = Convert.ToString(ValorLinha(linha, "descricao"));
                    txtCategoria.Text = Convert.ToString(ValorLinha(linha, "categoria"));
                    txtPreco.Text = Convert.ToString(ValorLinha(linha, "preco"));
                    break;
                case 1:
                    txtPedidoId.Text = Convert.ToString(ValorLinha(linha, "id"));
                    txtClienteId.Text = Convert.ToString(ValorLinha(linha, "cliente_id"));
                    txtEntregadorId.Text = Convert.ToString(ValorLinha(linha, "entregador_id"));
                    dtpDataPedido.Value = ObterDataPedido(linha);
                    txtStatusPedido.Text = Convert.ToString(ValorLinha(linha, "status"));
                    txtObservacoesPedido.Text = Convert.ToString(ValorLinhaAlternativo(linha, "observacoes", "obs"));
                    txtFormaPagamento.Text = Convert.ToString(ValorLinhaAlternativo(linha, "forma_pagamento", "forma_pg"));
                    numTaxaEntrega.Value = Convert.ToDecimal(ValorLinha(linha, "taxa_entrega"));
                    break;
                case 2:
                    txtClienteCadastroId.Text = Convert.ToString(ValorLinha(linha, "id"));
                    txtNomeCliente.Text = Convert.ToString(ValorLinha(linha, "nome"));
                    txtSenhaCliente.Clear();
                    txtNumeroTelefoneCliente.Text = Convert.ToString(ValorLinhaAlternativo(linha, "numero_telefone", "numero_tel"));
                    txtEmailCliente.Text = Convert.ToString(ValorLinha(linha, "email"));
                    txtCpfCliente.Text = Convert.ToString(ValorLinha(linha, "cpf"));
                    txtCepCliente.Text = Convert.ToString(ValorLinha(linha, "cep"));
                    txtBairroCliente.Text = Convert.ToString(ValorLinha(linha, "bairro"));
                    txtRuaCliente.Text = Convert.ToString(ValorLinha(linha, "rua"));
                    txtNumeroCliente.Text = Convert.ToString(ValorLinha(linha, "numero"));
                    txtComplementoCliente.Text = Convert.ToString(ValorLinhaAlternativo(linha, "complemento_endereco", "comp_endereco"));
                    break;
                case 3:
                    txtEntregadorCadastroId.Text = Convert.ToString(ValorLinha(linha, "id"));
                    txtNomeEntregador.Text = Convert.ToString(ValorLinha(linha, "nome"));
                    txtNumeroTelefoneEntregador.Text = Convert.ToString(ValorLinhaAlternativo(linha, "numero_telefone", "numero_tel"));
                    txtCpfEntregador.Text = Convert.ToString(ValorLinha(linha, "cpf"));
                    txtRgEntregador.Text = Convert.ToString(ValorLinha(linha, "rg"));
                    txtCepEntregador.Text = Convert.ToString(ValorLinha(linha, "cep"));
                    txtEmailEntregador.Text = Convert.ToString(ValorLinha(linha, "email"));
                    break;
                case 4:
                    txtItemPedidoId.Text = Convert.ToString(ValorLinha(linha, "id"));
                    txtPedidoItemId.Text = Convert.ToString(ValorLinha(linha, "pedido_id"));
                    txtProdutoItemId.Text = Convert.ToString(ValorLinha(linha, "produto_id"));
                    numQuantidadeItem.Value = Convert.ToDecimal(ValorLinha(linha, "qtd"));
                    numPrecoUnitarioItem.Value = Convert.ToDecimal(ValorLinha(linha, "preco_unitario"));
                    break;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tbCafeSolaris.SelectedIndex)
                {
                    case 0:
                        new Produtos
                        {
                            id = Convert.ToInt32(txtId.Text),
                            nome = txtNome.Text,
                            descricao = txtDescricaoProduto.Text,
                            categoria = txtCategoria.Text,
                            preco = Convert.ToDecimal(txtPreco.Text)
                        }.AlterarProduto();
                        break;
                    case 1:
                        new Pedidos
                        {
                            id = Convert.ToInt32(txtPedidoId.Text),
                            cliente_id = Convert.ToInt32(txtClienteId.Text),
                            entregador_id = Convert.ToInt32(txtEntregadorId.Text),
                            data_pedido = dtpDataPedido.Value,
                            status = txtStatusPedido.Text,
                            obs = txtObservacoesPedido.Text,
                            forma_pg = txtFormaPagamento.Text,
                            taxa_entrega = numTaxaEntrega.Value
                        }.AlterarPedido();
                        break;
                    case 2:
                        new Cliente
                        {
                            id = Convert.ToInt32(txtClienteCadastroId.Text),
                            nome = txtNomeCliente.Text,
                            senha = txtSenhaCliente.Text,
                            numero_tel = txtNumeroTelefoneCliente.Text,
                            email = txtEmailCliente.Text,
                            cpf = txtCpfCliente.Text,
                            cep = txtCepCliente.Text,
                            bairro = txtBairroCliente.Text,
                            rua = txtRuaCliente.Text,
                            numero = txtNumeroCliente.Text,
                            comp_endereco = txtComplementoCliente.Text
                        }.AlterarCliente();
                        break;
                    case 3:
                        new Entregadores
                        {
                            id = Convert.ToInt32(txtEntregadorCadastroId.Text),
                            nome = txtNomeEntregador.Text,
                            numero_tel = txtNumeroTelefoneEntregador.Text,
                            cpf = txtCpfEntregador.Text,
                            rg = txtRgEntregador.Text,
                            cep = txtCepEntregador.Text,
                            email = txtEmailEntregador.Text
                        }.AlterarEntregadores();
                        break;
                    case 4:
                        new Itens_pedido
                        {
                            id = Convert.ToInt32(txtItemPedidoId.Text),
                            pedido_id = Convert.ToInt32(txtPedidoItemId.Text),
                            produto_id = Convert.ToInt32(txtProdutoItemId.Text),
                            qtd = Convert.ToInt32(numQuantidadeItem.Value),
                            preco_unitario = numPrecoUnitarioItem.Value
                        }.AlterarItens_pedido();
                        break;
                }

                AtualizarGrid();
                MessageBox.Show("Registro atualizado com sucesso.", "Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao editar registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja realmente excluir o registro selecionado?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                int id;
                switch (tbCafeSolaris.SelectedIndex)
                {
                    case 0:
                        id = Convert.ToInt32(txtId.Text);
                        new Produtos { id = id }.ExcluirProduto();
                        break;
                    case 1:
                        id = Convert.ToInt32(txtPedidoId.Text);
                        new Pedidos { id = id }.ExcluirPedido();
                        break;
                    case 2:
                        id = Convert.ToInt32(txtClienteCadastroId.Text);
                        new Cliente { id = id }.ExcluirCliente();
                        break;
                    case 3:
                        id = Convert.ToInt32(txtEntregadorCadastroId.Text);
                        new Entregadores { id = id }.ExcluirEntregadores();
                        break;
                    case 4:
                        id = Convert.ToInt32(txtItemPedidoId.Text);
                        new Itens_pedido { id = id }.ExcluirItens_pedido();
                        break;
                    default:
                        return;
                }

                AtualizarGrid();
                MessageBox.Show("Registro excluído com sucesso.", "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AtualizarGrid()
        {
            try
            {
                DataTable dados;

                switch (tbCafeSolaris.SelectedIndex)
                {
                    case 0:
                        dados = new Produtos().ListarProdutos();
                        break;
                    case 1:
                        dados = new Pedidos().ListarPedido();
                        break;
                    case 2:
                        dados = new Cliente().ListarCliente();
                        break;
                    case 3:
                        dados = new Entregadores().ListarEntregadores();
                        break;
                    case 4:
                        dados = new Itens_pedido().ListarItens_pedido();
                        break;
                    default:
                        return;
                }

                dtGridCafeSolaris.AutoGenerateColumns = true;
                dtGridCafeSolaris.DataSource = dados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Erro ao carregar dados",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtDescricaoProduto_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
