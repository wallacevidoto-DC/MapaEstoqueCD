using System.Drawing.Printing;

namespace MapaEstoqueCD.Utils.Print
{
    public class ePrintDocument : PrintDocument
    {
        public event EventHandler<CountPagesEventArgs> PagesCount;
        public int totalPages = 1;

        protected override void OnEndPrint(PrintEventArgs e)
        {
            base.OnEndPrint(e);

            PagesCount?.Invoke(this, new CountPagesEventArgs(totalPages));
        }
    }

    public class CountPagesEventArgs : PrintEventArgs
    {
        public int TotalPages { get; }

        public CountPagesEventArgs(int totalPages)
        {
            TotalPages = totalPages;
        }
    }
}
