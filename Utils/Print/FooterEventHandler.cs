using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas;
using iText.Kernel.Pdf.Event;
using iText.Layout;
using iText.Layout.Properties;

namespace MapaEstoqueCD.Utils.Print
{
    public class FooterEventHandler : AbstractPdfDocumentEventHandler
    {
        private readonly string _footerText;

        public FooterEventHandler(string footerText)
        {
            _footerText = footerText;
        }

        protected override void OnAcceptedEvent(AbstractPdfDocumentEvent @event)
        {
            PdfDocumentEvent docEvent = (PdfDocumentEvent)@event;
            PdfDocument pdf = docEvent.GetDocument();
            PdfPage page = docEvent.GetPage();

            float x = page.GetPageSize().GetRight() - 5;
            float y = page.GetPageSize().GetBottom() +0;

            // 🔹 Cria o canvas
            PdfCanvas pdfCanvas = new PdfCanvas(page.NewContentStreamAfter(), page.GetResources(), pdf);

            // 🔹 Usa o Canvas (que implementa IDisposable)
            Canvas drawCanvas = new Canvas(pdfCanvas, page.GetPageSize());

            string footer = $"{_footerText}  |  Página {pdf.GetPageNumber(page)}";

            drawCanvas
                .ShowTextAligned(footer, x, y, TextAlignment.RIGHT)
                .SetFontSize(3);

            drawCanvas.Close();
        }
    }
}