namespace Cafe_Solaris
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtDescricaoProduto;
        private System.Windows.Forms.Label lblDescricaoProduto;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label lblNomeCliente;
        private System.Windows.Forms.TextBox txtSenhaCliente;
        private System.Windows.Forms.Label lblSenhaCliente;
        private System.Windows.Forms.TextBox txtNomeEntregador;
        private System.Windows.Forms.Label lblNomeEntregador;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbCafeSolaris = new System.Windows.Forms.TabControl();
            this.tbProduto = new System.Windows.Forms.TabPage();
            this.lblDescricaoProduto = new System.Windows.Forms.Label();
            this.txtDescricaoProduto = new System.Windows.Forms.TextBox();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblPreco = new System.Windows.Forms.Label();
            this.txtPreco = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.tbPedido = new System.Windows.Forms.TabPage();
            this.btnExcluirPedido = new System.Windows.Forms.Button();
            this.btnSalvarPedido = new System.Windows.Forms.Button();
            this.numTaxaEntrega = new System.Windows.Forms.NumericUpDown();
            this.lblTaxaEntrega = new System.Windows.Forms.Label();
            this.txtFormaPagamento = new System.Windows.Forms.TextBox();
            this.lblFormaPagamento = new System.Windows.Forms.Label();
            this.txtObservacoesPedido = new System.Windows.Forms.TextBox();
            this.lblObservacoesPedido = new System.Windows.Forms.Label();
            this.txtStatusPedido = new System.Windows.Forms.TextBox();
            this.lblStatusPedido = new System.Windows.Forms.Label();
            this.dtpDataPedido = new System.Windows.Forms.DateTimePicker();
            this.lblDataPedido = new System.Windows.Forms.Label();
            this.txtEntregadorId = new System.Windows.Forms.TextBox();
            this.lblEntregadorId = new System.Windows.Forms.Label();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.lblClienteId = new System.Windows.Forms.Label();
            this.txtPedidoId = new System.Windows.Forms.TextBox();
            this.lblPedidoId = new System.Windows.Forms.Label();
            this.tbClientes = new System.Windows.Forms.TabPage();
            this.lblNomeCliente = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.lblSenhaCliente = new System.Windows.Forms.Label();
            this.txtSenhaCliente = new System.Windows.Forms.TextBox();
            this.btnExcluirCliente = new System.Windows.Forms.Button();
            this.btnSalvarCliente = new System.Windows.Forms.Button();
            this.txtComplementoCliente = new System.Windows.Forms.TextBox();
            this.lblComplementoCliente = new System.Windows.Forms.Label();
            this.txtNumeroCliente = new System.Windows.Forms.TextBox();
            this.lblNumeroCliente = new System.Windows.Forms.Label();
            this.txtRuaCliente = new System.Windows.Forms.TextBox();
            this.lblRuaCliente = new System.Windows.Forms.Label();
            this.txtBairroCliente = new System.Windows.Forms.TextBox();
            this.lblBairroCliente = new System.Windows.Forms.Label();
            this.txtCepCliente = new System.Windows.Forms.TextBox();
            this.lblCepCliente = new System.Windows.Forms.Label();
            this.txtCpfCliente = new System.Windows.Forms.TextBox();
            this.lblCpfCliente = new System.Windows.Forms.Label();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();
            this.lblEmailCliente = new System.Windows.Forms.Label();
            this.txtNumeroTelefoneCliente = new System.Windows.Forms.TextBox();
            this.lblNumeroTelefoneCliente = new System.Windows.Forms.Label();
            this.txtClienteCadastroId = new System.Windows.Forms.TextBox();
            this.lblClienteCadastroId = new System.Windows.Forms.Label();
            this.tbEntregadores = new System.Windows.Forms.TabPage();
            this.lblNomeEntregador = new System.Windows.Forms.Label();
            this.txtNomeEntregador = new System.Windows.Forms.TextBox();
            this.btnExcluirEntregador = new System.Windows.Forms.Button();
            this.btnSalvarEntregador = new System.Windows.Forms.Button();
            this.txtEmailEntregador = new System.Windows.Forms.TextBox();
            this.lblEmailEntregador = new System.Windows.Forms.Label();
            this.txtCepEntregador = new System.Windows.Forms.TextBox();
            this.lblCepEntregador = new System.Windows.Forms.Label();
            this.txtRgEntregador = new System.Windows.Forms.TextBox();
            this.lblRgEntregador = new System.Windows.Forms.Label();
            this.txtCpfEntregador = new System.Windows.Forms.TextBox();
            this.lblCpfEntregador = new System.Windows.Forms.Label();
            this.txtNumeroTelefoneEntregador = new System.Windows.Forms.TextBox();
            this.lblNumeroTelefoneEntregador = new System.Windows.Forms.Label();
            this.txtEntregadorCadastroId = new System.Windows.Forms.TextBox();
            this.lblEntregadorCadastroId = new System.Windows.Forms.Label();
            this.tbItensPedido = new System.Windows.Forms.TabPage();
            this.btnExcluirItemPedido = new System.Windows.Forms.Button();
            this.btnSalvarItemPedido = new System.Windows.Forms.Button();
            this.numPrecoUnitarioItem = new System.Windows.Forms.NumericUpDown();
            this.lblPrecoUnitarioItem = new System.Windows.Forms.Label();
            this.numQuantidadeItem = new System.Windows.Forms.NumericUpDown();
            this.lblQuantidadeItem = new System.Windows.Forms.Label();
            this.txtProdutoItemId = new System.Windows.Forms.TextBox();
            this.lblProdutoItemId = new System.Windows.Forms.Label();
            this.txtPedidoItemId = new System.Windows.Forms.TextBox();
            this.lblPedidoItemId = new System.Windows.Forms.Label();
            this.txtItemPedidoId = new System.Windows.Forms.TextBox();
            this.lblItemPedidoId = new System.Windows.Forms.Label();
            this.dtGridCafeSolaris = new System.Windows.Forms.DataGridView();
            this.tbCafeSolaris.SuspendLayout();
            this.tbProduto.SuspendLayout();
            this.tbPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxaEntrega)).BeginInit();
            this.tbClientes.SuspendLayout();
            this.tbEntregadores.SuspendLayout();
            this.tbItensPedido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoUnitarioItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadeItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCafeSolaris)).BeginInit();
            this.SuspendLayout();
            // 
            // tbCafeSolaris
            // 
            this.tbCafeSolaris.Controls.Add(this.tbProduto);
            this.tbCafeSolaris.Controls.Add(this.tbPedido);
            this.tbCafeSolaris.Controls.Add(this.tbClientes);
            this.tbCafeSolaris.Controls.Add(this.tbEntregadores);
            this.tbCafeSolaris.Controls.Add(this.tbItensPedido);
            this.tbCafeSolaris.Location = new System.Drawing.Point(12, 12);
            this.tbCafeSolaris.Name = "tbCafeSolaris";
            this.tbCafeSolaris.SelectedIndex = 0;
            this.tbCafeSolaris.Size = new System.Drawing.Size(1130, 326);
            this.tbCafeSolaris.TabIndex = 0;
            // 
            // tbProduto
            // 
            this.tbProduto.Controls.Add(this.lblDescricaoProduto);
            this.tbProduto.Controls.Add(this.txtDescricaoProduto);
            this.tbProduto.Controls.Add(this.btnExcluir);
            this.tbProduto.Controls.Add(this.btnSalvar);
            this.tbProduto.Controls.Add(this.lblId);
            this.tbProduto.Controls.Add(this.txtId);
            this.tbProduto.Controls.Add(this.lblPreco);
            this.tbProduto.Controls.Add(this.txtPreco);
            this.tbProduto.Controls.Add(this.lblCategoria);
            this.tbProduto.Controls.Add(this.txtCategoria);
            this.tbProduto.Controls.Add(this.lblNome);
            this.tbProduto.Controls.Add(this.txtNome);
            this.tbProduto.Location = new System.Drawing.Point(4, 29);
            this.tbProduto.Name = "tbProduto";
            this.tbProduto.Padding = new System.Windows.Forms.Padding(3);
            this.tbProduto.Size = new System.Drawing.Size(1122, 293);
            this.tbProduto.TabIndex = 0;
            this.tbProduto.Text = "Produto";
            this.tbProduto.UseVisualStyleBackColor = true;
            // 
            // lblDescricaoProduto
            // 
            this.lblDescricaoProduto.AutoSize = true;
            this.lblDescricaoProduto.Location = new System.Drawing.Point(300, 115);
            this.lblDescricaoProduto.Name = "lblDescricaoProduto";
            this.lblDescricaoProduto.Size = new System.Drawing.Size(80, 20);
            this.lblDescricaoProduto.TabIndex = 0;
            this.lblDescricaoProduto.Text = "Descrição";
            // 
            // txtDescricaoProduto
            // 
            this.txtDescricaoProduto.Location = new System.Drawing.Point(304, 138);
            this.txtDescricaoProduto.Multiline = true;
            this.txtDescricaoProduto.Name = "txtDescricaoProduto";
            this.txtDescricaoProduto.Size = new System.Drawing.Size(180, 60);
            this.txtDescricaoProduto.TabIndex = 1;
            this.txtDescricaoProduto.TextChanged += new System.EventHandler(this.txtDescricaoProduto_TextChanged);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(114, 162);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 36);
            this.btnExcluir.TabIndex = 9;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(21, 162);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 36);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(17, 47);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(26, 20);
            this.lblId.TabIndex = 7;
            this.lblId.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(21, 70);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 26);
            this.txtId.TabIndex = 6;
            // 
            // lblPreco
            // 
            this.lblPreco.AutoSize = true;
            this.lblPreco.Location = new System.Drawing.Point(381, 47);
            this.lblPreco.Name = "lblPreco";
            this.lblPreco.Size = new System.Drawing.Size(50, 20);
            this.lblPreco.TabIndex = 5;
            this.lblPreco.Text = "Preço";
            // 
            // txtPreco
            // 
            this.txtPreco.Location = new System.Drawing.Point(384, 70);
            this.txtPreco.Name = "txtPreco";
            this.txtPreco.Size = new System.Drawing.Size(100, 26);
            this.txtPreco.TabIndex = 4;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Location = new System.Drawing.Point(260, 47);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(78, 20);
            this.lblCategoria.TabIndex = 3;
            this.lblCategoria.Text = "Categoria";
            // 
            // txtCategoria
            // 
            this.txtCategoria.Location = new System.Drawing.Point(263, 70);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(100, 26);
            this.txtCategoria.TabIndex = 2;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(138, 47);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(51, 20);
            this.lblNome.TabIndex = 1;
            this.lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(142, 70);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(100, 26);
            this.txtNome.TabIndex = 0;
            // 
            // tbPedido
            // 
            this.tbPedido.Controls.Add(this.btnExcluirPedido);
            this.tbPedido.Controls.Add(this.btnSalvarPedido);
            this.tbPedido.Controls.Add(this.numTaxaEntrega);
            this.tbPedido.Controls.Add(this.lblTaxaEntrega);
            this.tbPedido.Controls.Add(this.txtFormaPagamento);
            this.tbPedido.Controls.Add(this.lblFormaPagamento);
            this.tbPedido.Controls.Add(this.txtObservacoesPedido);
            this.tbPedido.Controls.Add(this.lblObservacoesPedido);
            this.tbPedido.Controls.Add(this.txtStatusPedido);
            this.tbPedido.Controls.Add(this.lblStatusPedido);
            this.tbPedido.Controls.Add(this.dtpDataPedido);
            this.tbPedido.Controls.Add(this.lblDataPedido);
            this.tbPedido.Controls.Add(this.txtEntregadorId);
            this.tbPedido.Controls.Add(this.lblEntregadorId);
            this.tbPedido.Controls.Add(this.txtClienteId);
            this.tbPedido.Controls.Add(this.lblClienteId);
            this.tbPedido.Controls.Add(this.txtPedidoId);
            this.tbPedido.Controls.Add(this.lblPedidoId);
            this.tbPedido.Location = new System.Drawing.Point(4, 29);
            this.tbPedido.Name = "tbPedido";
            this.tbPedido.Size = new System.Drawing.Size(1122, 293);
            this.tbPedido.TabIndex = 1;
            this.tbPedido.Text = "Pedido";
            this.tbPedido.UseVisualStyleBackColor = true;
            // 
            // btnExcluirPedido
            // 
            this.btnExcluirPedido.Location = new System.Drawing.Point(113, 190);
            this.btnExcluirPedido.Name = "btnExcluirPedido";
            this.btnExcluirPedido.Size = new System.Drawing.Size(75, 36);
            this.btnExcluirPedido.TabIndex = 27;
            this.btnExcluirPedido.Text = "Excluir";
            this.btnExcluirPedido.UseVisualStyleBackColor = true;
            // 
            // btnSalvarPedido
            // 
            this.btnSalvarPedido.Location = new System.Drawing.Point(20, 190);
            this.btnSalvarPedido.Name = "btnSalvarPedido";
            this.btnSalvarPedido.Size = new System.Drawing.Size(75, 36);
            this.btnSalvarPedido.TabIndex = 26;
            this.btnSalvarPedido.Text = "Salvar";
            this.btnSalvarPedido.UseVisualStyleBackColor = true;
            // 
            // numTaxaEntrega
            // 
            this.numTaxaEntrega.DecimalPlaces = 2;
            this.numTaxaEntrega.Location = new System.Drawing.Point(594, 114);
            this.numTaxaEntrega.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numTaxaEntrega.Name = "numTaxaEntrega";
            this.numTaxaEntrega.Size = new System.Drawing.Size(130, 26);
            this.numTaxaEntrega.TabIndex = 25;
            // 
            // lblTaxaEntrega
            // 
            this.lblTaxaEntrega.AutoSize = true;
            this.lblTaxaEntrega.Location = new System.Drawing.Point(591, 91);
            this.lblTaxaEntrega.Name = "lblTaxaEntrega";
            this.lblTaxaEntrega.Size = new System.Drawing.Size(124, 20);
            this.lblTaxaEntrega.TabIndex = 24;
            this.lblTaxaEntrega.Text = "Taxa de entrega";
            // 
            // txtFormaPagamento
            // 
            this.txtFormaPagamento.Location = new System.Drawing.Point(389, 114);
            this.txtFormaPagamento.Name = "txtFormaPagamento";
            this.txtFormaPagamento.Size = new System.Drawing.Size(180, 26);
            this.txtFormaPagamento.TabIndex = 23;
            // 
            // lblFormaPagamento
            // 
            this.lblFormaPagamento.AutoSize = true;
            this.lblFormaPagamento.Location = new System.Drawing.Point(386, 91);
            this.lblFormaPagamento.Name = "lblFormaPagamento";
            this.lblFormaPagamento.Size = new System.Drawing.Size(162, 20);
            this.lblFormaPagamento.TabIndex = 22;
            this.lblFormaPagamento.Text = "Forma de pagamento";
            // 
            // txtObservacoesPedido
            // 
            this.txtObservacoesPedido.Location = new System.Drawing.Point(20, 114);
            this.txtObservacoesPedido.Multiline = true;
            this.txtObservacoesPedido.Name = "txtObservacoesPedido";
            this.txtObservacoesPedido.Size = new System.Drawing.Size(350, 45);
            this.txtObservacoesPedido.TabIndex = 21;
            // 
            // lblObservacoesPedido
            // 
            this.lblObservacoesPedido.AutoSize = true;
            this.lblObservacoesPedido.Location = new System.Drawing.Point(17, 91);
            this.lblObservacoesPedido.Name = "lblObservacoesPedido";
            this.lblObservacoesPedido.Size = new System.Drawing.Size(102, 20);
            this.lblObservacoesPedido.TabIndex = 20;
            this.lblObservacoesPedido.Text = "Observações";
            // 
            // txtStatusPedido
            // 
            this.txtStatusPedido.Location = new System.Drawing.Point(594, 43);
            this.txtStatusPedido.Name = "txtStatusPedido";
            this.txtStatusPedido.Size = new System.Drawing.Size(130, 26);
            this.txtStatusPedido.TabIndex = 19;
            // 
            // lblStatusPedido
            // 
            this.lblStatusPedido.AutoSize = true;
            this.lblStatusPedido.Location = new System.Drawing.Point(591, 20);
            this.lblStatusPedido.Name = "lblStatusPedido";
            this.lblStatusPedido.Size = new System.Drawing.Size(56, 20);
            this.lblStatusPedido.TabIndex = 18;
            this.lblStatusPedido.Text = "Status";
            // 
            // dtpDataPedido
            // 
            this.dtpDataPedido.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataPedido.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataPedido.Location = new System.Drawing.Point(389, 43);
            this.dtpDataPedido.Name = "dtpDataPedido";
            this.dtpDataPedido.Size = new System.Drawing.Size(180, 26);
            this.dtpDataPedido.TabIndex = 17;
            // 
            // lblDataPedido
            // 
            this.lblDataPedido.AutoSize = true;
            this.lblDataPedido.Location = new System.Drawing.Point(386, 20);
            this.lblDataPedido.Name = "lblDataPedido";
            this.lblDataPedido.Size = new System.Drawing.Size(118, 20);
            this.lblDataPedido.TabIndex = 16;
            this.lblDataPedido.Text = "Data do pedido";
            // 
            // txtEntregadorId
            // 
            this.txtEntregadorId.Location = new System.Drawing.Point(266, 43);
            this.txtEntregadorId.Name = "txtEntregadorId";
            this.txtEntregadorId.Size = new System.Drawing.Size(100, 26);
            this.txtEntregadorId.TabIndex = 15;
            // 
            // lblEntregadorId
            // 
            this.lblEntregadorId.AutoSize = true;
            this.lblEntregadorId.Location = new System.Drawing.Point(263, 20);
            this.lblEntregadorId.Name = "lblEntregadorId";
            this.lblEntregadorId.Size = new System.Drawing.Size(110, 20);
            this.lblEntregadorId.TabIndex = 14;
            this.lblEntregadorId.Text = "ID Entregador";
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(143, 43);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(100, 26);
            this.txtClienteId.TabIndex = 13;
            // 
            // lblClienteId
            // 
            this.lblClienteId.AutoSize = true;
            this.lblClienteId.Location = new System.Drawing.Point(140, 20);
            this.lblClienteId.Name = "lblClienteId";
            this.lblClienteId.Size = new System.Drawing.Size(79, 20);
            this.lblClienteId.TabIndex = 12;
            this.lblClienteId.Text = "ID Cliente";
            // 
            // txtPedidoId
            // 
            this.txtPedidoId.Location = new System.Drawing.Point(20, 43);
            this.txtPedidoId.Name = "txtPedidoId";
            this.txtPedidoId.ReadOnly = true;
            this.txtPedidoId.Size = new System.Drawing.Size(100, 26);
            this.txtPedidoId.TabIndex = 11;
            // 
            // lblPedidoId
            // 
            this.lblPedidoId.AutoSize = true;
            this.lblPedidoId.Location = new System.Drawing.Point(17, 20);
            this.lblPedidoId.Name = "lblPedidoId";
            this.lblPedidoId.Size = new System.Drawing.Size(26, 20);
            this.lblPedidoId.TabIndex = 10;
            this.lblPedidoId.Text = "ID";
            // 
            // tbClientes
            // 
            this.tbClientes.Controls.Add(this.lblNomeCliente);
            this.tbClientes.Controls.Add(this.txtNomeCliente);
            this.tbClientes.Controls.Add(this.lblSenhaCliente);
            this.tbClientes.Controls.Add(this.txtSenhaCliente);
            this.tbClientes.Controls.Add(this.btnExcluirCliente);
            this.tbClientes.Controls.Add(this.btnSalvarCliente);
            this.tbClientes.Controls.Add(this.txtComplementoCliente);
            this.tbClientes.Controls.Add(this.lblComplementoCliente);
            this.tbClientes.Controls.Add(this.txtNumeroCliente);
            this.tbClientes.Controls.Add(this.lblNumeroCliente);
            this.tbClientes.Controls.Add(this.txtRuaCliente);
            this.tbClientes.Controls.Add(this.lblRuaCliente);
            this.tbClientes.Controls.Add(this.txtBairroCliente);
            this.tbClientes.Controls.Add(this.lblBairroCliente);
            this.tbClientes.Controls.Add(this.txtCepCliente);
            this.tbClientes.Controls.Add(this.lblCepCliente);
            this.tbClientes.Controls.Add(this.txtCpfCliente);
            this.tbClientes.Controls.Add(this.lblCpfCliente);
            this.tbClientes.Controls.Add(this.txtEmailCliente);
            this.tbClientes.Controls.Add(this.lblEmailCliente);
            this.tbClientes.Controls.Add(this.txtNumeroTelefoneCliente);
            this.tbClientes.Controls.Add(this.lblNumeroTelefoneCliente);
            this.tbClientes.Controls.Add(this.txtClienteCadastroId);
            this.tbClientes.Controls.Add(this.lblClienteCadastroId);
            this.tbClientes.Location = new System.Drawing.Point(4, 29);
            this.tbClientes.Name = "tbClientes";
            this.tbClientes.Size = new System.Drawing.Size(1122, 293);
            this.tbClientes.TabIndex = 2;
            this.tbClientes.Text = "Clientes";
            this.tbClientes.UseVisualStyleBackColor = true;
            // 
            // lblNomeCliente
            // 
            this.lblNomeCliente.AutoSize = true;
            this.lblNomeCliente.Location = new System.Drawing.Point(804, 20);
            this.lblNomeCliente.Name = "lblNomeCliente";
            this.lblNomeCliente.Size = new System.Drawing.Size(51, 20);
            this.lblNomeCliente.TabIndex = 0;
            this.lblNomeCliente.Text = "Nome";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(808, 43);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(180, 26);
            this.txtNomeCliente.TabIndex = 1;
            // 
            // lblSenhaCliente
            // 
            this.lblSenhaCliente.AutoSize = true;
            this.lblSenhaCliente.Location = new System.Drawing.Point(804, 91);
            this.lblSenhaCliente.Name = "lblSenhaCliente";
            this.lblSenhaCliente.Size = new System.Drawing.Size(56, 20);
            this.lblSenhaCliente.TabIndex = 2;
            this.lblSenhaCliente.Text = "Senha";
            // 
            // txtSenhaCliente
            // 
            this.txtSenhaCliente.Location = new System.Drawing.Point(808, 114);
            this.txtSenhaCliente.Name = "txtSenhaCliente";
            this.txtSenhaCliente.Size = new System.Drawing.Size(180, 26);
            this.txtSenhaCliente.TabIndex = 3;
            this.txtSenhaCliente.UseSystemPasswordChar = true;
            // 
            // btnExcluirCliente
            // 
            this.btnExcluirCliente.Location = new System.Drawing.Point(113, 190);
            this.btnExcluirCliente.Name = "btnExcluirCliente";
            this.btnExcluirCliente.Size = new System.Drawing.Size(75, 36);
            this.btnExcluirCliente.TabIndex = 47;
            this.btnExcluirCliente.Text = "Excluir";
            this.btnExcluirCliente.UseVisualStyleBackColor = true;
            // 
            // btnSalvarCliente
            // 
            this.btnSalvarCliente.Location = new System.Drawing.Point(20, 190);
            this.btnSalvarCliente.Name = "btnSalvarCliente";
            this.btnSalvarCliente.Size = new System.Drawing.Size(75, 36);
            this.btnSalvarCliente.TabIndex = 46;
            this.btnSalvarCliente.Text = "Salvar";
            this.btnSalvarCliente.UseVisualStyleBackColor = true;
            // 
            // txtComplementoCliente
            // 
            this.txtComplementoCliente.Location = new System.Drawing.Point(543, 114);
            this.txtComplementoCliente.Name = "txtComplementoCliente";
            this.txtComplementoCliente.Size = new System.Drawing.Size(190, 26);
            this.txtComplementoCliente.TabIndex = 45;
            // 
            // lblComplementoCliente
            // 
            this.lblComplementoCliente.AutoSize = true;
            this.lblComplementoCliente.Location = new System.Drawing.Point(540, 91);
            this.lblComplementoCliente.Name = "lblComplementoCliente";
            this.lblComplementoCliente.Size = new System.Drawing.Size(108, 20);
            this.lblComplementoCliente.TabIndex = 44;
            this.lblComplementoCliente.Text = "Complemento";
            // 
            // txtNumeroCliente
            // 
            this.txtNumeroCliente.Location = new System.Drawing.Point(432, 114);
            this.txtNumeroCliente.Name = "txtNumeroCliente";
            this.txtNumeroCliente.Size = new System.Drawing.Size(90, 26);
            this.txtNumeroCliente.TabIndex = 43;
            // 
            // lblNumeroCliente
            // 
            this.lblNumeroCliente.AutoSize = true;
            this.lblNumeroCliente.Location = new System.Drawing.Point(429, 91);
            this.lblNumeroCliente.Name = "lblNumeroCliente";
            this.lblNumeroCliente.Size = new System.Drawing.Size(65, 20);
            this.lblNumeroCliente.TabIndex = 42;
            this.lblNumeroCliente.Text = "Número";
            // 
            // txtRuaCliente
            // 
            this.txtRuaCliente.Location = new System.Drawing.Point(191, 114);
            this.txtRuaCliente.Name = "txtRuaCliente";
            this.txtRuaCliente.Size = new System.Drawing.Size(220, 26);
            this.txtRuaCliente.TabIndex = 41;
            // 
            // lblRuaCliente
            // 
            this.lblRuaCliente.AutoSize = true;
            this.lblRuaCliente.Location = new System.Drawing.Point(188, 91);
            this.lblRuaCliente.Name = "lblRuaCliente";
            this.lblRuaCliente.Size = new System.Drawing.Size(39, 20);
            this.lblRuaCliente.TabIndex = 40;
            this.lblRuaCliente.Text = "Rua";
            // 
            // txtBairroCliente
            // 
            this.txtBairroCliente.Location = new System.Drawing.Point(20, 114);
            this.txtBairroCliente.Name = "txtBairroCliente";
            this.txtBairroCliente.Size = new System.Drawing.Size(150, 26);
            this.txtBairroCliente.TabIndex = 39;
            // 
            // lblBairroCliente
            // 
            this.lblBairroCliente.AutoSize = true;
            this.lblBairroCliente.Location = new System.Drawing.Point(17, 91);
            this.lblBairroCliente.Name = "lblBairroCliente";
            this.lblBairroCliente.Size = new System.Drawing.Size(51, 20);
            this.lblBairroCliente.TabIndex = 38;
            this.lblBairroCliente.Text = "Bairro";
            // 
            // txtCepCliente
            // 
            this.txtCepCliente.Location = new System.Drawing.Point(616, 43);
            this.txtCepCliente.Name = "txtCepCliente";
            this.txtCepCliente.Size = new System.Drawing.Size(110, 26);
            this.txtCepCliente.TabIndex = 37;
            // 
            // lblCepCliente
            // 
            this.lblCepCliente.AutoSize = true;
            this.lblCepCliente.Location = new System.Drawing.Point(613, 20);
            this.lblCepCliente.Name = "lblCepCliente";
            this.lblCepCliente.Size = new System.Drawing.Size(41, 20);
            this.lblCepCliente.TabIndex = 36;
            this.lblCepCliente.Text = "CEP";
            // 
            // txtCpfCliente
            // 
            this.txtCpfCliente.Location = new System.Drawing.Point(467, 43);
            this.txtCpfCliente.Name = "txtCpfCliente";
            this.txtCpfCliente.Size = new System.Drawing.Size(130, 26);
            this.txtCpfCliente.TabIndex = 35;
            // 
            // lblCpfCliente
            // 
            this.lblCpfCliente.AutoSize = true;
            this.lblCpfCliente.Location = new System.Drawing.Point(464, 20);
            this.lblCpfCliente.Name = "lblCpfCliente";
            this.lblCpfCliente.Size = new System.Drawing.Size(40, 20);
            this.lblCpfCliente.TabIndex = 34;
            this.lblCpfCliente.Text = "CPF";
            // 
            // txtEmailCliente
            // 
            this.txtEmailCliente.Location = new System.Drawing.Point(268, 43);
            this.txtEmailCliente.Name = "txtEmailCliente";
            this.txtEmailCliente.Size = new System.Drawing.Size(180, 26);
            this.txtEmailCliente.TabIndex = 33;
            // 
            // lblEmailCliente
            // 
            this.lblEmailCliente.AutoSize = true;
            this.lblEmailCliente.Location = new System.Drawing.Point(265, 20);
            this.lblEmailCliente.Name = "lblEmailCliente";
            this.lblEmailCliente.Size = new System.Drawing.Size(53, 20);
            this.lblEmailCliente.TabIndex = 32;
            this.lblEmailCliente.Text = "E-mail";
            // 
            // txtNumeroTelefoneCliente
            // 
            this.txtNumeroTelefoneCliente.Location = new System.Drawing.Point(119, 43);
            this.txtNumeroTelefoneCliente.Name = "txtNumeroTelefoneCliente";
            this.txtNumeroTelefoneCliente.Size = new System.Drawing.Size(130, 26);
            this.txtNumeroTelefoneCliente.TabIndex = 31;
            // 
            // lblNumeroTelefoneCliente
            // 
            this.lblNumeroTelefoneCliente.AutoSize = true;
            this.lblNumeroTelefoneCliente.Location = new System.Drawing.Point(116, 20);
            this.lblNumeroTelefoneCliente.Name = "lblNumeroTelefoneCliente";
            this.lblNumeroTelefoneCliente.Size = new System.Drawing.Size(71, 20);
            this.lblNumeroTelefoneCliente.TabIndex = 30;
            this.lblNumeroTelefoneCliente.Text = "Telefone";
            // 
            // txtClienteCadastroId
            // 
            this.txtClienteCadastroId.Location = new System.Drawing.Point(20, 43);
            this.txtClienteCadastroId.Name = "txtClienteCadastroId";
            this.txtClienteCadastroId.ReadOnly = true;
            this.txtClienteCadastroId.Size = new System.Drawing.Size(80, 26);
            this.txtClienteCadastroId.TabIndex = 29;
            // 
            // lblClienteCadastroId
            // 
            this.lblClienteCadastroId.AutoSize = true;
            this.lblClienteCadastroId.Location = new System.Drawing.Point(17, 20);
            this.lblClienteCadastroId.Name = "lblClienteCadastroId";
            this.lblClienteCadastroId.Size = new System.Drawing.Size(26, 20);
            this.lblClienteCadastroId.TabIndex = 28;
            this.lblClienteCadastroId.Text = "ID";
            // 
            // tbEntregadores
            // 
            this.tbEntregadores.Controls.Add(this.lblNomeEntregador);
            this.tbEntregadores.Controls.Add(this.txtNomeEntregador);
            this.tbEntregadores.Controls.Add(this.btnExcluirEntregador);
            this.tbEntregadores.Controls.Add(this.btnSalvarEntregador);
            this.tbEntregadores.Controls.Add(this.txtEmailEntregador);
            this.tbEntregadores.Controls.Add(this.lblEmailEntregador);
            this.tbEntregadores.Controls.Add(this.txtCepEntregador);
            this.tbEntregadores.Controls.Add(this.lblCepEntregador);
            this.tbEntregadores.Controls.Add(this.txtRgEntregador);
            this.tbEntregadores.Controls.Add(this.lblRgEntregador);
            this.tbEntregadores.Controls.Add(this.txtCpfEntregador);
            this.tbEntregadores.Controls.Add(this.lblCpfEntregador);
            this.tbEntregadores.Controls.Add(this.txtNumeroTelefoneEntregador);
            this.tbEntregadores.Controls.Add(this.lblNumeroTelefoneEntregador);
            this.tbEntregadores.Controls.Add(this.txtEntregadorCadastroId);
            this.tbEntregadores.Controls.Add(this.lblEntregadorCadastroId);
            this.tbEntregadores.Location = new System.Drawing.Point(4, 29);
            this.tbEntregadores.Name = "tbEntregadores";
            this.tbEntregadores.Size = new System.Drawing.Size(1122, 293);
            this.tbEntregadores.TabIndex = 3;
            this.tbEntregadores.Text = "Entregadores";
            this.tbEntregadores.UseVisualStyleBackColor = true;
            // 
            // lblNomeEntregador
            // 
            this.lblNomeEntregador.AutoSize = true;
            this.lblNomeEntregador.Location = new System.Drawing.Point(882, 20);
            this.lblNomeEntregador.Name = "lblNomeEntregador";
            this.lblNomeEntregador.Size = new System.Drawing.Size(51, 20);
            this.lblNomeEntregador.TabIndex = 0;
            this.lblNomeEntregador.Text = "Nome";
            // 
            // txtNomeEntregador
            // 
            this.txtNomeEntregador.Location = new System.Drawing.Point(886, 43);
            this.txtNomeEntregador.Name = "txtNomeEntregador";
            this.txtNomeEntregador.Size = new System.Drawing.Size(180, 26);
            this.txtNomeEntregador.TabIndex = 1;
            // 
            // btnExcluirEntregador
            // 
            this.btnExcluirEntregador.Location = new System.Drawing.Point(113, 114);
            this.btnExcluirEntregador.Name = "btnExcluirEntregador";
            this.btnExcluirEntregador.Size = new System.Drawing.Size(75, 36);
            this.btnExcluirEntregador.TabIndex = 61;
            this.btnExcluirEntregador.Text = "Excluir";
            this.btnExcluirEntregador.UseVisualStyleBackColor = true;
            // 
            // btnSalvarEntregador
            // 
            this.btnSalvarEntregador.Location = new System.Drawing.Point(20, 114);
            this.btnSalvarEntregador.Name = "btnSalvarEntregador";
            this.btnSalvarEntregador.Size = new System.Drawing.Size(75, 36);
            this.btnSalvarEntregador.TabIndex = 60;
            this.btnSalvarEntregador.Text = "Salvar";
            this.btnSalvarEntregador.UseVisualStyleBackColor = true;
            // 
            // txtEmailEntregador
            // 
            this.txtEmailEntregador.Location = new System.Drawing.Point(685, 43);
            this.txtEmailEntregador.Name = "txtEmailEntregador";
            this.txtEmailEntregador.Size = new System.Drawing.Size(180, 26);
            this.txtEmailEntregador.TabIndex = 59;
            // 
            // lblEmailEntregador
            // 
            this.lblEmailEntregador.AutoSize = true;
            this.lblEmailEntregador.Location = new System.Drawing.Point(682, 20);
            this.lblEmailEntregador.Name = "lblEmailEntregador";
            this.lblEmailEntregador.Size = new System.Drawing.Size(53, 20);
            this.lblEmailEntregador.TabIndex = 58;
            this.lblEmailEntregador.Text = "E-mail";
            // 
            // txtCepEntregador
            // 
            this.txtCepEntregador.Location = new System.Drawing.Point(556, 43);
            this.txtCepEntregador.Name = "txtCepEntregador";
            this.txtCepEntregador.Size = new System.Drawing.Size(110, 26);
            this.txtCepEntregador.TabIndex = 57;
            // 
            // lblCepEntregador
            // 
            this.lblCepEntregador.AutoSize = true;
            this.lblCepEntregador.Location = new System.Drawing.Point(553, 20);
            this.lblCepEntregador.Name = "lblCepEntregador";
            this.lblCepEntregador.Size = new System.Drawing.Size(41, 20);
            this.lblCepEntregador.TabIndex = 56;
            this.lblCepEntregador.Text = "CEP";
            // 
            // txtRgEntregador
            // 
            this.txtRgEntregador.Location = new System.Drawing.Point(417, 43);
            this.txtRgEntregador.Name = "txtRgEntregador";
            this.txtRgEntregador.Size = new System.Drawing.Size(110, 26);
            this.txtRgEntregador.TabIndex = 55;
            // 
            // lblRgEntregador
            // 
            this.lblRgEntregador.AutoSize = true;
            this.lblRgEntregador.Location = new System.Drawing.Point(414, 20);
            this.lblRgEntregador.Name = "lblRgEntregador";
            this.lblRgEntregador.Size = new System.Drawing.Size(34, 20);
            this.lblRgEntregador.TabIndex = 54;
            this.lblRgEntregador.Text = "RG";
            // 
            // txtCpfEntregador
            // 
            this.txtCpfEntregador.Location = new System.Drawing.Point(268, 43);
            this.txtCpfEntregador.Name = "txtCpfEntregador";
            this.txtCpfEntregador.Size = new System.Drawing.Size(130, 26);
            this.txtCpfEntregador.TabIndex = 53;
            // 
            // lblCpfEntregador
            // 
            this.lblCpfEntregador.AutoSize = true;
            this.lblCpfEntregador.Location = new System.Drawing.Point(265, 20);
            this.lblCpfEntregador.Name = "lblCpfEntregador";
            this.lblCpfEntregador.Size = new System.Drawing.Size(40, 20);
            this.lblCpfEntregador.TabIndex = 52;
            this.lblCpfEntregador.Text = "CPF";
            // 
            // txtNumeroTelefoneEntregador
            // 
            this.txtNumeroTelefoneEntregador.Location = new System.Drawing.Point(119, 43);
            this.txtNumeroTelefoneEntregador.Name = "txtNumeroTelefoneEntregador";
            this.txtNumeroTelefoneEntregador.Size = new System.Drawing.Size(130, 26);
            this.txtNumeroTelefoneEntregador.TabIndex = 51;
            // 
            // lblNumeroTelefoneEntregador
            // 
            this.lblNumeroTelefoneEntregador.AutoSize = true;
            this.lblNumeroTelefoneEntregador.Location = new System.Drawing.Point(116, 20);
            this.lblNumeroTelefoneEntregador.Name = "lblNumeroTelefoneEntregador";
            this.lblNumeroTelefoneEntregador.Size = new System.Drawing.Size(71, 20);
            this.lblNumeroTelefoneEntregador.TabIndex = 50;
            this.lblNumeroTelefoneEntregador.Text = "Telefone";
            // 
            // txtEntregadorCadastroId
            // 
            this.txtEntregadorCadastroId.Location = new System.Drawing.Point(20, 43);
            this.txtEntregadorCadastroId.Name = "txtEntregadorCadastroId";
            this.txtEntregadorCadastroId.ReadOnly = true;
            this.txtEntregadorCadastroId.Size = new System.Drawing.Size(80, 26);
            this.txtEntregadorCadastroId.TabIndex = 49;
            // 
            // lblEntregadorCadastroId
            // 
            this.lblEntregadorCadastroId.AutoSize = true;
            this.lblEntregadorCadastroId.Location = new System.Drawing.Point(17, 20);
            this.lblEntregadorCadastroId.Name = "lblEntregadorCadastroId";
            this.lblEntregadorCadastroId.Size = new System.Drawing.Size(26, 20);
            this.lblEntregadorCadastroId.TabIndex = 48;
            this.lblEntregadorCadastroId.Text = "ID";
            // 
            // tbItensPedido
            // 
            this.tbItensPedido.Controls.Add(this.btnExcluirItemPedido);
            this.tbItensPedido.Controls.Add(this.btnSalvarItemPedido);
            this.tbItensPedido.Controls.Add(this.numPrecoUnitarioItem);
            this.tbItensPedido.Controls.Add(this.lblPrecoUnitarioItem);
            this.tbItensPedido.Controls.Add(this.numQuantidadeItem);
            this.tbItensPedido.Controls.Add(this.lblQuantidadeItem);
            this.tbItensPedido.Controls.Add(this.txtProdutoItemId);
            this.tbItensPedido.Controls.Add(this.lblProdutoItemId);
            this.tbItensPedido.Controls.Add(this.txtPedidoItemId);
            this.tbItensPedido.Controls.Add(this.lblPedidoItemId);
            this.tbItensPedido.Controls.Add(this.txtItemPedidoId);
            this.tbItensPedido.Controls.Add(this.lblItemPedidoId);
            this.tbItensPedido.Location = new System.Drawing.Point(4, 29);
            this.tbItensPedido.Name = "tbItensPedido";
            this.tbItensPedido.Size = new System.Drawing.Size(1122, 293);
            this.tbItensPedido.TabIndex = 4;
            this.tbItensPedido.Text = "Itens do pedido";
            this.tbItensPedido.UseVisualStyleBackColor = true;
            // 
            // btnExcluirItemPedido
            // 
            this.btnExcluirItemPedido.Location = new System.Drawing.Point(113, 100);
            this.btnExcluirItemPedido.Name = "btnExcluirItemPedido";
            this.btnExcluirItemPedido.Size = new System.Drawing.Size(75, 36);
            this.btnExcluirItemPedido.TabIndex = 73;
            this.btnExcluirItemPedido.Text = "Excluir";
            this.btnExcluirItemPedido.UseVisualStyleBackColor = true;
            // 
            // btnSalvarItemPedido
            // 
            this.btnSalvarItemPedido.Location = new System.Drawing.Point(20, 100);
            this.btnSalvarItemPedido.Name = "btnSalvarItemPedido";
            this.btnSalvarItemPedido.Size = new System.Drawing.Size(75, 36);
            this.btnSalvarItemPedido.TabIndex = 72;
            this.btnSalvarItemPedido.Text = "Salvar";
            this.btnSalvarItemPedido.UseVisualStyleBackColor = true;
            // 
            // numPrecoUnitarioItem
            // 
            this.numPrecoUnitarioItem.DecimalPlaces = 2;
            this.numPrecoUnitarioItem.Location = new System.Drawing.Point(506, 43);
            this.numPrecoUnitarioItem.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numPrecoUnitarioItem.Name = "numPrecoUnitarioItem";
            this.numPrecoUnitarioItem.Size = new System.Drawing.Size(130, 26);
            this.numPrecoUnitarioItem.TabIndex = 71;
            // 
            // lblPrecoUnitarioItem
            // 
            this.lblPrecoUnitarioItem.AutoSize = true;
            this.lblPrecoUnitarioItem.Location = new System.Drawing.Point(503, 20);
            this.lblPrecoUnitarioItem.Name = "lblPrecoUnitarioItem";
            this.lblPrecoUnitarioItem.Size = new System.Drawing.Size(106, 20);
            this.lblPrecoUnitarioItem.TabIndex = 70;
            this.lblPrecoUnitarioItem.Text = "Preço unitário";
            // 
            // numQuantidadeItem
            // 
            this.numQuantidadeItem.Location = new System.Drawing.Point(377, 43);
            this.numQuantidadeItem.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numQuantidadeItem.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numQuantidadeItem.Name = "numQuantidadeItem";
            this.numQuantidadeItem.Size = new System.Drawing.Size(110, 26);
            this.numQuantidadeItem.TabIndex = 69;
            this.numQuantidadeItem.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblQuantidadeItem
            // 
            this.lblQuantidadeItem.AutoSize = true;
            this.lblQuantidadeItem.Location = new System.Drawing.Point(374, 20);
            this.lblQuantidadeItem.Name = "lblQuantidadeItem";
            this.lblQuantidadeItem.Size = new System.Drawing.Size(92, 20);
            this.lblQuantidadeItem.TabIndex = 68;
            this.lblQuantidadeItem.Text = "Quantidade";
            // 
            // txtProdutoItemId
            // 
            this.txtProdutoItemId.Location = new System.Drawing.Point(248, 43);
            this.txtProdutoItemId.Name = "txtProdutoItemId";
            this.txtProdutoItemId.Size = new System.Drawing.Size(110, 26);
            this.txtProdutoItemId.TabIndex = 67;
            // 
            // lblProdutoItemId
            // 
            this.lblProdutoItemId.AutoSize = true;
            this.lblProdutoItemId.Location = new System.Drawing.Point(245, 20);
            this.lblProdutoItemId.Name = "lblProdutoItemId";
            this.lblProdutoItemId.Size = new System.Drawing.Size(107, 20);
            this.lblProdutoItemId.TabIndex = 66;
            this.lblProdutoItemId.Text = "ID do produto";
            // 
            // txtPedidoItemId
            // 
            this.txtPedidoItemId.Location = new System.Drawing.Point(119, 43);
            this.txtPedidoItemId.Name = "txtPedidoItemId";
            this.txtPedidoItemId.Size = new System.Drawing.Size(110, 26);
            this.txtPedidoItemId.TabIndex = 65;
            // 
            // lblPedidoItemId
            // 
            this.lblPedidoItemId.AutoSize = true;
            this.lblPedidoItemId.Location = new System.Drawing.Point(116, 20);
            this.lblPedidoItemId.Name = "lblPedidoItemId";
            this.lblPedidoItemId.Size = new System.Drawing.Size(100, 20);
            this.lblPedidoItemId.TabIndex = 64;
            this.lblPedidoItemId.Text = "ID do pedido";
            // 
            // txtItemPedidoId
            // 
            this.txtItemPedidoId.Location = new System.Drawing.Point(20, 43);
            this.txtItemPedidoId.Name = "txtItemPedidoId";
            this.txtItemPedidoId.ReadOnly = true;
            this.txtItemPedidoId.Size = new System.Drawing.Size(80, 26);
            this.txtItemPedidoId.TabIndex = 63;
            // 
            // lblItemPedidoId
            // 
            this.lblItemPedidoId.AutoSize = true;
            this.lblItemPedidoId.Location = new System.Drawing.Point(17, 20);
            this.lblItemPedidoId.Name = "lblItemPedidoId";
            this.lblItemPedidoId.Size = new System.Drawing.Size(26, 20);
            this.lblItemPedidoId.TabIndex = 62;
            this.lblItemPedidoId.Text = "ID";
            // 
            // dtGridCafeSolaris
            // 
            this.dtGridCafeSolaris.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCafeSolaris.Location = new System.Drawing.Point(16, 384);
            this.dtGridCafeSolaris.Name = "dtGridCafeSolaris";
            this.dtGridCafeSolaris.RowHeadersWidth = 62;
            this.dtGridCafeSolaris.RowTemplate.Height = 28;
            this.dtGridCafeSolaris.Size = new System.Drawing.Size(1114, 239);
            this.dtGridCafeSolaris.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 673);
            this.Controls.Add(this.dtGridCafeSolaris);
            this.Controls.Add(this.tbCafeSolaris);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Café Solaris";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.btnImportarProdutos = new System.Windows.Forms.Button();
            this.btnImportarProdutos.Location = new System.Drawing.Point(21, 240);
            this.btnImportarProdutos.Name = "btnImportarProdutos";
            this.btnImportarProdutos.Size = new System.Drawing.Size(150, 36);
            this.btnImportarProdutos.TabIndex = 200;
            this.btnImportarProdutos.Text = "Importar JSON";
            this.btnImportarProdutos.UseVisualStyleBackColor = true;
            this.tbProduto.Controls.Add(this.btnImportarProdutos);
            this.btnImportarPedidos = new System.Windows.Forms.Button();
            this.btnImportarPedidos.Location = new System.Drawing.Point(21, 240);
            this.btnImportarPedidos.Name = "btnImportarPedidos";
            this.btnImportarPedidos.Size = new System.Drawing.Size(150, 36);
            this.btnImportarPedidos.TabIndex = 201;
            this.btnImportarPedidos.Text = "Importar JSON";
            this.btnImportarPedidos.UseVisualStyleBackColor = true;
            this.tbPedido.Controls.Add(this.btnImportarPedidos);
            this.btnImportarClientes = new System.Windows.Forms.Button();
            this.btnImportarClientes.Location = new System.Drawing.Point(21, 240);
            this.btnImportarClientes.Name = "btnImportarClientes";
            this.btnImportarClientes.Size = new System.Drawing.Size(150, 36);
            this.btnImportarClientes.TabIndex = 202;
            this.btnImportarClientes.Text = "Importar JSON";
            this.btnImportarClientes.UseVisualStyleBackColor = true;
            this.tbClientes.Controls.Add(this.btnImportarClientes);
            this.btnImportarEntregadores = new System.Windows.Forms.Button();
            this.btnImportarEntregadores.Location = new System.Drawing.Point(21, 240);
            this.btnImportarEntregadores.Name = "btnImportarEntregadores";
            this.btnImportarEntregadores.Size = new System.Drawing.Size(150, 36);
            this.btnImportarEntregadores.TabIndex = 203;
            this.btnImportarEntregadores.Text = "Importar JSON";
            this.btnImportarEntregadores.UseVisualStyleBackColor = true;
            this.tbEntregadores.Controls.Add(this.btnImportarEntregadores);
            this.btnImportarItensPedido = new System.Windows.Forms.Button();
            this.btnImportarItensPedido.Location = new System.Drawing.Point(21, 240);
            this.btnImportarItensPedido.Name = "btnImportarItensPedido";
            this.btnImportarItensPedido.Size = new System.Drawing.Size(150, 36);
            this.btnImportarItensPedido.TabIndex = 204;
            this.btnImportarItensPedido.Text = "Importar JSON";
            this.btnImportarItensPedido.UseVisualStyleBackColor = true;
            this.tbItensPedido.Controls.Add(this.btnImportarItensPedido);
            this.tbCafeSolaris.ResumeLayout(false);
            this.tbProduto.ResumeLayout(false);
            this.tbProduto.PerformLayout();
            this.tbPedido.ResumeLayout(false);
            this.tbPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTaxaEntrega)).EndInit();
            this.tbClientes.ResumeLayout(false);
            this.tbClientes.PerformLayout();
            this.tbEntregadores.ResumeLayout(false);
            this.tbEntregadores.PerformLayout();
            this.tbItensPedido.ResumeLayout(false);
            this.tbItensPedido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPrecoUnitarioItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidadeItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCafeSolaris)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbCafeSolaris;
        private System.Windows.Forms.TabPage tbProduto;
        private System.Windows.Forms.TabPage tbPedido;
        private System.Windows.Forms.TabPage tbClientes;
        private System.Windows.Forms.TabPage tbEntregadores;
        private System.Windows.Forms.TabPage tbItensPedido;
        private System.Windows.Forms.DataGridView dtGridCafeSolaris;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblPreco;
        private System.Windows.Forms.TextBox txtPreco;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblPedidoId;
        private System.Windows.Forms.TextBox txtPedidoId;
        private System.Windows.Forms.Label lblClienteId;
        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.Label lblEntregadorId;
        private System.Windows.Forms.TextBox txtEntregadorId;
        private System.Windows.Forms.Label lblDataPedido;
        private System.Windows.Forms.DateTimePicker dtpDataPedido;
        private System.Windows.Forms.Label lblStatusPedido;
        private System.Windows.Forms.TextBox txtStatusPedido;
        private System.Windows.Forms.Label lblObservacoesPedido;
        private System.Windows.Forms.TextBox txtObservacoesPedido;
        private System.Windows.Forms.Label lblFormaPagamento;
        private System.Windows.Forms.TextBox txtFormaPagamento;
        private System.Windows.Forms.Label lblTaxaEntrega;
        private System.Windows.Forms.NumericUpDown numTaxaEntrega;
        private System.Windows.Forms.Button btnSalvarPedido;
        private System.Windows.Forms.Button btnExcluirPedido;
        private System.Windows.Forms.Label lblClienteCadastroId;
        private System.Windows.Forms.TextBox txtClienteCadastroId;
        private System.Windows.Forms.Label lblNumeroTelefoneCliente;
        private System.Windows.Forms.TextBox txtNumeroTelefoneCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label lblCpfCliente;
        private System.Windows.Forms.TextBox txtCpfCliente;
        private System.Windows.Forms.Label lblCepCliente;
        private System.Windows.Forms.TextBox txtCepCliente;
        private System.Windows.Forms.Label lblBairroCliente;
        private System.Windows.Forms.TextBox txtBairroCliente;
        private System.Windows.Forms.Label lblRuaCliente;
        private System.Windows.Forms.TextBox txtRuaCliente;
        private System.Windows.Forms.Label lblNumeroCliente;
        private System.Windows.Forms.TextBox txtNumeroCliente;
        private System.Windows.Forms.Label lblComplementoCliente;
        private System.Windows.Forms.TextBox txtComplementoCliente;
        private System.Windows.Forms.Button btnSalvarCliente;
        private System.Windows.Forms.Button btnExcluirCliente;
        private System.Windows.Forms.Label lblEntregadorCadastroId;
        private System.Windows.Forms.TextBox txtEntregadorCadastroId;
        private System.Windows.Forms.Label lblNumeroTelefoneEntregador;
        private System.Windows.Forms.TextBox txtNumeroTelefoneEntregador;
        private System.Windows.Forms.Label lblCpfEntregador;
        private System.Windows.Forms.TextBox txtCpfEntregador;
        private System.Windows.Forms.Label lblRgEntregador;
        private System.Windows.Forms.TextBox txtRgEntregador;
        private System.Windows.Forms.Label lblCepEntregador;
        private System.Windows.Forms.TextBox txtCepEntregador;
        private System.Windows.Forms.Label lblEmailEntregador;
        private System.Windows.Forms.TextBox txtEmailEntregador;
        private System.Windows.Forms.Button btnSalvarEntregador;
        private System.Windows.Forms.Button btnExcluirEntregador;
        private System.Windows.Forms.Label lblItemPedidoId;
        private System.Windows.Forms.TextBox txtItemPedidoId;
        private System.Windows.Forms.Label lblPedidoItemId;
        private System.Windows.Forms.TextBox txtPedidoItemId;
        private System.Windows.Forms.Label lblProdutoItemId;
        private System.Windows.Forms.TextBox txtProdutoItemId;
        private System.Windows.Forms.Label lblQuantidadeItem;
        private System.Windows.Forms.NumericUpDown numQuantidadeItem;
        private System.Windows.Forms.Label lblPrecoUnitarioItem;
        private System.Windows.Forms.NumericUpDown numPrecoUnitarioItem;
        private System.Windows.Forms.Button btnSalvarItemPedido;
        private System.Windows.Forms.Button btnExcluirItemPedido;
        private System.Windows.Forms.Button btnImportarProdutos;
        private System.Windows.Forms.Button btnImportarPedidos;
        private System.Windows.Forms.Button btnImportarClientes;
        private System.Windows.Forms.Button btnImportarEntregadores;
        private System.Windows.Forms.Button btnImportarItensPedido;
    }
}

