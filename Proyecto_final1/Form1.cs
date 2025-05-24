using System.Windows.Forms.Design;
using Azure;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using A= DocumentFormat.OpenXml.Drawing;
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

        private void textResultado_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonDocumento_Click(object sender, EventArgs e)
        {
            string contenido = textResultado.Text;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PowerPoint Presentation|*.pptx",
                Title = "Guardar presentación como",
                FileName = "presentacion.pptx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (PresentationDocument presentationDoc = PresentationDocument.Create(saveFileDialog.FileName, PresentationDocumentType.Presentation))
                {
                    // Crear partes básicas
                    PresentationPart presentationPart = presentationDoc.AddPresentationPart();
                    presentationPart.Presentation = new Presentation();

                    SlideMasterPart slideMasterPart = presentationPart.AddNewPart<SlideMasterPart>();
                    slideMasterPart.SlideMaster = new SlideMaster(new CommonSlideData(new ShapeTree()));
                    slideMasterPart.SlideMaster.Save();

                    SlideLayoutPart slideLayoutPart = slideMasterPart.AddNewPart<SlideLayoutPart>();
                    slideLayoutPart.SlideLayout = new SlideLayout(new CommonSlideData(new ShapeTree()));
                    slideLayoutPart.SlideLayout.Save();

                    SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
                    slidePart.Slide = new Slide(new CommonSlideData(new ShapeTree()));
                    slidePart.AddPart(slideLayoutPart);
                    slidePart.Slide.Save();

                    // Agregar texto a la diapositiva
                    Shape titleShape = new Shape(
                        new NonVisualShapeProperties(
                            new NonVisualDrawingProperties() { Id = 1, Name = "Title" },
                            new NonVisualShapeDrawingProperties(new A.ShapeLocks() { NoGrouping = true }),
                            new ApplicationNonVisualDrawingProperties()),
                        new ShapeProperties(),
                        new TextBody(
                            new A.BodyProperties(),
                            new A.ListStyle(),
                            new A.Paragraph(new A.Run(new A.Text(contenido)))
                        )
                    );

                    slidePart.Slide.CommonSlideData.ShapeTree.AppendChild(titleShape);

                    // Agregar SlideId a la presentación
                    SlideIdList slideIdList = new SlideIdList();
                    uint slideId = 256U;
                    slideIdList.Append(new SlideId() { Id = slideId, RelationshipId = presentationPart.GetIdOfPart(slidePart) });
                    presentationPart.Presentation.Append(slideIdList);
                    presentationPart.Presentation.Save();
                }

                MessageBox.Show("PowerPoint generado correctamente.");
            }
        }
    }
}






