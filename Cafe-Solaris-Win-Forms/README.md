Instale o Newtonsoft.Json. O zip não inclui esse pacote, porque eu não tenho acesso à internet para baixá-lo. No Visual Studio, clique com o botão direito no projeto → Gerenciar Pacotes NuGet → procure Newtonsoft.Json → Instalar. Ele atualiza o packages.config e o .csproj sozinho.
Rode o dados/ajustes-banco.sql no MySQL uma vez, antes de importar.
Importe na ordem: clientes → entregadores → produtos → pedidos → itens_pedido.
