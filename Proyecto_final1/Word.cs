using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Proyecto_final1
{
    public class WordS
    {
        public void CreateDoc(string filePath, string content)
        {
            using (var doc = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
            {
                doc.AddMainDocumentPart().Document = new Document(
                    new Body(new Paragraph(new Run(new Text(content)))));
            }
        }
    }
}
