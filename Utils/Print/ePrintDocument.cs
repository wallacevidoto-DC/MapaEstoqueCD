//using PdfSharpCore.Drawing;
//using PdfSharpCore.Pdf;
//using System;
//using System.Drawing;
//using System.Drawing.Imaging;
//using System.Drawing.Printing;
//using System.IO;

//namespace MapaEstoqueCD.Utils.Print
//{
//    public class ePrintDocument : PrintDocument
//    {
//        public event EventHandler<CountPagesEventArgs> PagesCount;
//        public int totalPages = 0;

//        // Exportação para PDF
//        private bool _exportingToPdf = false;
//        private string? _pdfPath;
//        private PdfDocument? _pdfDoc;
//        private int _currentPage = 1;

//        /// <summary>
//        /// Chame para exportar para PDF (usa o mesmo fluxo de render).
//        /// </summary>
//        public void ExportToPdf(string pdfPath)
//        {
//            _exportingToPdf = true;
//            _pdfPath = pdfPath;
//            PrintController = new StandardPrintController(); // sem UI
//            Print(); // dispara OnPrintPage repetidamente
//        }

//        protected override void OnBeginPrint(PrintEventArgs e)
//        {
//            base.OnBeginPrint(e);
//            totalPages = 0;
//            _currentPage = 1;

//            if (_exportingToPdf)
//            {
//                _pdfDoc = new PdfDocument();
//                _pdfDoc.Info.Title = DocumentName ?? "Documento";
//            }
//        }

//        /// <summary>
//        /// Método que derived classes devem sobrescrever para desenhar a página.
//        /// Deve retornar true se houver mais páginas (HasMorePages).
//        /// </summary>
//        protected virtual bool RenderPage(Graphics g, Rectangle marginBounds, PageSettings pageSettings, int pageNumber)
//        {
//            // Implementação padrão: nada a desenhar e sem mais páginas.
//            return false;
//        }

//        protected override void OnPrintPage(PrintPageEventArgs e)
//        {
//            // 1) desenha no Graphics real (impressora/preview)
//            bool morePages = RenderPage(e.Graphics, e.MarginBounds, e.PageSettings, _currentPage);

//            // 2) se estivermos exportando para PDF, desenhar também em bitmap e inserir no PDF
//            if (_exportingToPdf && _pdfDoc != null)
//            {
//                // cria bitmap com tamanho em pixels igual ao PageBounds
//                int pxW = e.PageBounds.Width;
//                int pxH = e.PageBounds.Height;

//                using (var bmp = new Bitmap(pxW, pxH, PixelFormat.Format32bppArgb))
//                {
//                    // define mesma resolução do device original para manter proporção
//                    float dpiX = e.Graphics.DpiX;
//                    float dpiY = e.Graphics.DpiY;
//                    bmp.SetResolution(dpiX, dpiY);

//                    using (var gBmp = Graphics.FromImage(bmp))
//                    {
//                        // importante: configurar antialiasing/smoothing se quiser
//                        gBmp.PageUnit = e.Graphics.PageUnit;
//                        gBmp.TranslateTransform(0, 0);

//                        // desenha a mesma página no bitmap usando o mesmo método reutilizável
//                        RenderPage(gBmp, e.MarginBounds, e.PageSettings, _currentPage);
//                    }

//                    // agora converte bitmap em imagem e adiciona ao pdf
//                    using (var ms = new MemoryStream())
//                    {
//                        bmp.Save(ms, ImageFormat.Png);
//                        ms.Position = 0;

//                        // calcula tamanho em pontos (PDF usa pontos: 72 pt/in)
//                        double widthPoints = pxW / dpiX * 72.0;
//                        double heightPoints = pxH / dpiY * 72.0;

//                        var pdfPage = _pdfDoc.AddPage();
//                        pdfPage.Width = XUnit.FromPoint(widthPoints);
//                        pdfPage.Height = XUnit.FromPoint(heightPoints);

//                        using (var pdfGfx = XGraphics.FromPdfPage(pdfPage))
//                        {
//                            // PdfSharpCore exige um factory para stream:
//                            var ximg = XImage.FromStream(() => new MemoryStream(ms.ToArray()));
//                            pdfGfx.DrawImage(ximg, 0, 0, widthPoints, heightPoints);
//                        }
//                    }
//                }
//            }

//            // 3) atualiza paginação
//            e.HasMorePages = morePages;
//            totalPages++;
//            _currentPage++;
//        }

//        protected override void OnEndPrint(PrintEventArgs e)
//        {
//            base.OnEndPrint(e);

//            if (_exportingToPdf && _pdfDoc != null && !string.IsNullOrEmpty(_pdfPath))
//            {
//                // salva PDF em disco
//                using (var fs = File.Create(_pdfPath))
//                {
//                    _pdfDoc.Save(fs);
//                }
//                _pdfDoc.Dispose();
//                _pdfDoc = null;
//            }

//            // reset flags
//            _exportingToPdf = false;
//            _pdfPath = null;

//            PagesCount?.Invoke(this, new CountPagesEventArgs(totalPages));
//        }
//    }

//    public class CountPagesEventArgs : PrintEventArgs
//    {
//        public int TotalPages { get; }

//        public CountPagesEventArgs(int totalPages) 
//        {
//            TotalPages = totalPages;
//        }
//    }
//}
