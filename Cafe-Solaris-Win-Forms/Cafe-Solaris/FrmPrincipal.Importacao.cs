using System;
using System.Windows.Forms;

namespace Cafe_Solaris
{
    public partial class FrmPrincipal
    {
        //Chamado pelos botões "Importar JSON" de cada aba. 'tabela' é o nome da tabela no banco.
        private void ImportarJson(string tabela)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = $"Selecione o arquivo JSON de {tabela}";
                dialog.Filter = "Arquivos JSON (*.json)|*.json|Todos os arquivos (*.*)|*.*";

                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }

                try
                {
                    ResultadoImportacao resultado = new ImportadorJson().Importar(tabela, dialog.FileName);

                    AtualizarGrid();

                    MessageBox.Show(
                        $"Importação de {tabela} concluída.\n\nInseridos: {resultado.Inseridos}\nIgnorados (já existiam): {resultado.Ignorados}",
                        "Importação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    //Se o erro for de gravação, parte dos registros pode ter entrado (MyISAM), então atualiza a grid mesmo assim
                    AtualizarGrid();

                    MessageBox.Show(ex.Message, "Erro ao importar JSON", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
