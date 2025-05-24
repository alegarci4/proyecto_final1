using System.Windows.Forms.Design;
using Azure;

namespace Proyecto_final1
{
    public partial class Form1 : Form
    {
        private readonly AI _ai = new AI();
        private readonly DatabaseService _db = new DatabaseService();
        private readonly WordS _word = new WordS();

        public Form1()
        {
            InitializeComponent();
        }

        private async void buttonInvestigar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textPrompt.Text))
            {
                MessageBox.Show("Por favor ingrese un prompt válido.", "Advertencia",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                buttonInvestigar.Enabled = false;
                Cursor = Cursors.WaitCursor;

                var prompt = textPrompt.Text;
                var respuesta = await _ai.ObtenerBusqueda(prompt);

                if (respuesta.StartsWith("Error al obtener respuesta"))
                {
                    MessageBox.Show(respuesta, "Error de API",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                textResultado.Text = respuesta;

                await _db.GuardarAsync(new Registro
                {
                    Prompt = prompt,
                    Respuesta = respuesta
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                buttonInvestigar.Enabled = true;
                Cursor = Cursors.Default;
            }
        }




        private void buttonExportar_Click(object sender, EventArgs e)
        {
            var saveDialog = new SaveFileDialog { Filter = "Word|*.docx" };
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                _word.CreateDoc(saveDialog.FileName, textResultado.Text);
            }
        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

}


