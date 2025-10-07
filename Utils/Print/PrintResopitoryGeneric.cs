using MapaEstoqueCD.View.Modal;
using System.Drawing.Printing;

namespace MapaEstoqueCD.Utils.Print
{
    public class PrintResopitoryGeneric : IPrint
    {
        public event EventHandler<CountPagesEventArgs> PagesCount;

        protected ePrintDocument printDocument;

        public int totalPages { get; set; }

        public PrintResopitoryGeneric()
        {
            printDocument = new ePrintDocument();

            printDocument.EndPrint += PrintDocument_EndPrint;

        }

        private void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            printDocument.totalPages = totalPages;
        }

        public void ShowPrintPreview()
        {
            PrintPreviewForm previewForm = new PrintPreviewForm(printDocument);
            previewForm.ShowDialog();
        }

    }
}
