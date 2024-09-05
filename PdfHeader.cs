using iText.IO.Font.Constants;
using iText.Kernel.Events;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CodeJam4
{
    internal class PdfHeader
    {
        public static void ConvertTextToPdfWithHeader(string content, string name, string? header)
        {
            PdfWriter writer = new PdfWriter(name + ".pdf");
            PdfDocument pdfDoc = new PdfDocument(writer);
            Document doc = new Document(pdfDoc);

            // Add event handler for header
            pdfDoc.AddEventHandler(PdfDocumentEvent.END_PAGE, new HeaderEventHandler(doc, header));

            // Add content to the document
            doc.Add(new Paragraph(content));

            // Close the document
            doc.Close();
        }

        // Event handler to add header on each page
        public class HeaderEventHandler : IEventHandler
        {
            private readonly Document doc;
            public string header;

            public HeaderEventHandler(Document doc, string header)
            {
                this.doc = doc;
                this.header = header;
            }

            public void HandleEvent(Event currentEvent)
            {
                PdfDocumentEvent docEvent = (PdfDocumentEvent)currentEvent;
                PdfPage page = docEvent.GetPage();
                Rectangle pageSize = page.GetPageSize();

                // Define the font for the header
                PdfFont font = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

                // Define the X and Y positions for the header
                float headerX = pageSize.GetWidth() / 2;
                float headerY = pageSize.GetTop() - 20;

                // Add header text
                Canvas canvas = new Canvas(page, pageSize);
                canvas.SetFont(font)
                      .SetFontSize(12)
                      .ShowTextAligned(header, headerX, headerY, TextAlignment.CENTER)
                      .Close();
            }
        }
    }
}
