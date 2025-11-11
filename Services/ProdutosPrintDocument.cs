using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MapaEstoqueCD.Database.Models;
using System.Globalization;

namespace MapaEstoqueCD.Services
{
    public class ProdutosPdfGenerator
    {
        private readonly List<Produtos> produtos;

        private readonly (string PropertyName, string HeaderName, float Weight)[] columnDefinitions = new (string, string, float)[]
        {
            ("Codigo", "COD", 0.7f),
            ("Descricao", "DESCRIÇÃO", 4.0f),
            ("Ncm", "NCM", 1.3f),
            ("Pis", "PIS", 1.0f),
            ("Ipi", "IPI", 1.0f),
            ("Cofins", "COFINS", 1.0f),
            ("ShelfLife", "SHELF LIFE", 1.2f),
            ("UCodigoBarras", "EAN-13", 1.7f),
            ("UC", "C(cm) Unit", 0.7f),
            ("UL", "L(cm) Unit", 0.7f),
            ("UD", "D(cm) Unit", 0.7f),
            ("UH", "H(cm) Unit", 0.7f),
            ("UPesoLiquido", "Peso Líq. (Unit)", 1.0f),
            ("UPesoBruto", "Peso Bruto (Unit)", 1.0f),
            ("DCodigoBarras", "DUN-13", 1.7f),
            ("DQtd", "Qtd/Disp", 0.7f),
            ("DC", "C(cm) Disp", 0.8f),
            ("DL", "L(cm) Disp", 0.8f),
            ("DH", "H(cm) Disp", 0.8f),
            ("DPesoLiquido", "Peso Líq. (Disp)", 1.0f),
            ("DPesoBruto", "Peso Bruto (Disp)", 1.0f),
            ("CCodigoBarras", "DUN-14", 1.7f),
            ("CQtd", "Qtd/Caixa", 1.0f),
            ("CC", "C(cm) Caixa", 0.8f),
            ("CL", "L(cm) Caixa", 0.8f),
            ("CH", "H(cm) Caixa", 0.8f),
            ("CPesoLiquido", "Peso Líq. (Caixa)", 1.0f),
            ("CPesoBruto", "Peso Bruto (Caixa)", 1.0f),
            ("PCxLastro", "Cxs Lastro", 0.8f),
            ("PEmpCx", "Empilhamento", 0.8f),
            ("PCxPalete", "Cxs Palet", 0.8f)
        };

        public ProdutosPdfGenerator(List<Produtos> produtos)
        {
            this.produtos = produtos;
        }

        private string FormatValue(string propertyName, object value)
        {
            if (value == null) return "";

            if (propertyName == "Ipi" || propertyName == "Pis" || propertyName == "Cofins")
            {
                if (value is decimal decValue) return $"{(decValue * 100):N1}%";
            }

            if (value is DateTime dtValue) return dtValue.ToString("dd/MM/yyyy HH:mm");

            if (value is double dValue) return dValue.ToString("N3", CultureInfo.GetCultureInfo("pt-BR"));

            return value.ToString() ?? "";
        }

        public void GeneratePdf(string outputPath)
        {
            using var writer = new PdfWriter(outputPath);
            using var pdf = new PdfDocument(writer);
            var document = new Document(pdf, PageSize.A4.Rotate());

            // Margens
            document.SetMargins(15, 10, 15, 10);

            // Fonte negrito
            PdfFont boldFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            // --- Cabeçalho com logo + título ---
            string logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"imagens\dc.jpg");
            float[] headerColWidths = { 150, 400 }; // largura logo e título
            Table headerTable = new Table(UnitValue.CreatePointArray(headerColWidths))
                .UseAllAvailableWidth()
                .SetBorder(Border.NO_BORDER);

            // Logo
            if (File.Exists(logoPath))
            {
                ImageData imageData = ImageDataFactory.Create(logoPath);
                iText.Layout.Element.Image logo = new iText.Layout.Element.Image(imageData).ScaleToFit(150, 80);
                Cell logoCell = new Cell().Add(logo)
                    .SetBorder(Border.NO_BORDER)
                    .SetVerticalAlignment(VerticalAlignment.MIDDLE);
                headerTable.AddCell(logoCell);
            }
            else
            {
                headerTable.AddCell(new Cell().SetBorder(Border.NO_BORDER));
            }

            // Título
            Cell titleCell = new Cell()
                .Add(new Paragraph("LISTA DE PRODUTOS").SetFont(boldFont).SetFontSize(18))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetBorder(Border.NO_BORDER);
            headerTable.AddCell(titleCell);

            document.Add(headerTable);
            document.Add(new Paragraph("\n")); // espaço abaixo do cabeçalho

            // --- Tabela de produtos ---
            float totalWeight = columnDefinitions.Sum(c => c.Weight);
            float pageWidth = PageSize.A4.GetWidth() - document.GetLeftMargin() - document.GetRightMargin();
            float[] colWidths = columnDefinitions.Select(c => c.Weight / totalWeight * pageWidth).ToArray();
            Table table = new Table(UnitValue.CreatePointArray(colWidths)).UseAllAvailableWidth();

            // Cabeçalho da tabela
            foreach (var col in columnDefinitions)
            {
                var headerCell = new Cell()
                    .Add(new Paragraph(col.HeaderName)
                        .SetFont(boldFont)
                        .SetFontSize(5)
                        .SetFontColor(ColorConstants.WHITE))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER);
                table.AddHeaderCell(headerCell);
            }

            // Dados
            var properties = typeof(Produtos).GetProperties().ToDictionary(p => p.Name, p => p);
            foreach (var produto in produtos)
            {
                foreach (var col in columnDefinitions)
                {
                    string value = "";
                    if (properties.TryGetValue(col.PropertyName, out var propInfo))
                    {
                        value = FormatValue(col.PropertyName, propInfo.GetValue(produto));
                        if (value.Length > 30) value = value.Substring(0, 27) + "...";
                    }

                    var cell = new Cell()
                        .Add(new Paragraph(value).SetFontSize(4))
                        .SetTextAlignment(TextAlignment.CENTER);

                    table.AddCell(cell);
                }
            }

            document.Add(table);
            document.Close();
        }
    }
}


//using MapaEstoqueCD.Database.Models;
//using MapaEstoqueCD.Properties;
//using System.Drawing;
//using System.Drawing.Printing;
//using System.Reflection;
//using System.Globalization;
//using MapaEstoqueCD.Utils.Print;

//namespace MapaEstoqueCD.Services
//{
//    public class ProdutosPrintDocument : PrintResopitoryGeneric
//    {
//        private readonly List<Produtos> produtos;
//        private readonly Font headerFont = new Font("Arial", 6, FontStyle.Bold);
//        private readonly Font bodyFont = new Font("Arial", 4, FontStyle.Italic);
//        private readonly int rowHeight = 20;
//        private readonly int margin = 15;
//        private int currentPage = 0;

//        private readonly Brush headerBackgroundBrush = new SolidBrush(Color.DarkGray);
//        private readonly Brush headerForegroundBrush = Brushes.White;

//        // Estrutura de pesos relativos (mantida do código anterior)
//        private readonly (string PropertyName, string HeaderName, float Weight)[] columnDefinitions = new (string, string, float)[]
//        {
//            // Colunas principais
//            ("Codigo", "COD", 0.7f),
//            ("Descricao", "DESCRIÇÃO", 4.0f), // A mais larga
//            ("Ncm", "NCM", 1.3f),
//            ("Pis", "PIS", 1.0f),
//            ("Ipi", "IPI", 1.0f),
//            ("Cofins", "COFINS", 1.0f),
//            ("ShelfLife", "SHELF LIFE", 1.2f),

//            // Colunas Unitárias (Unidade)
//            ("UCodigoBarras", "EAN-13", 1.7f),
//            ("UC", "C(cm) Unit", 0.7f),
//            ("UL", "L(cm) Unit", 0.7f),
//            ("UD", "D(cm) Unit", 0.7f),
//            ("UH", "H(cm) Unit", 0.7f),
//            ("UPesoLiquido", "Peso Líq. (Unit)", 1.0f),
//            ("UPesoBruto", "Peso Bruto (Unit)", 1.0f),

//            // Colunas de Display (D_)
//            ("DCodigoBarras", "DUN-13", 1.7f),
//            ("DQtd", "Qtd/Disp", 0.7f),
//            ("DC", "C(cm) Disp", 0.8f),
//            ("DL", "L(cm) Disp", 0.8f),
//            ("DH", "H(cm) Disp", 0.8f),
//            ("DPesoLiquido", "Peso Líq. (Disp)", 1.0f),
//            ("DPesoBruto", "Peso Bruto (Disp)", 1.0f),

//            // Colunas de Paletização (Caixa/Palet - C_)
//            ("CCodigoBarras", "DUN-14", 1.7f),
//            ("CQtd", "Qtd/Caixa", 1.0f),
//            ("CC", "C(cm) Caixa", 0.8f),
//            ("CL", "L(cm) Caixa", 0.8f),
//            ("CH", "H(cm) Caixa", 0.8f),
//            ("CPesoLiquido", "Peso Líq. (Caixa)", 1.0f),
//            ("CPesoBruto", "Peso Bruto (Caixa)", 1.0f),

//            // Colunas de Paletização (P_)
//            ("PCxLastro", "Cxs Lastro", 0.8f),
//            ("PEmpCx", "Empilhamento", 0.8f),
//            ("PCxPalete", "Cxs Palet", 0.8f),

//            //// Colunas de Timestamp
//            //("UpdateAt", "Data Atualização", 1.5f),
//            //("CreateAt", "Data Criação", 1.5f)
//        };

//        public ProdutosPrintDocument(List<Produtos> produtos)
//        {
//            this.produtos = produtos;
//            printDocument.DefaultPageSettings.Landscape = true;  // horizontal
//            printDocument.PrintPage += new PrintPageEventHandler(PrintDocument_PrintPage);
//            printDocument.totalPages = totalPages;
//            printDocument.DefaultPageSettings.PaperSize = new PaperSize("A4", 850, 900);
//            printDocument.DefaultPageSettings.Margins = new Margins(3, 3, 3, 3);
//            printDocument.DocumentName = $"Produtos estoque {DateTime.Now.ToString("dd-MM-yyyy (HH mm ss)")}";
//            printDocument.DefaultPageSettings.Landscape = true;
//        }

//        private string FormatValue(string propertyName, object value)
//        {
//            if (value == null) return "";

//            if (propertyName == "Ipi" || propertyName == "Pis" || propertyName == "Cofins")
//            {
//                if (value is decimal decValue) return $"{(decValue * 100):N1}%";
//            }

//            if (value is DateTime dtValue) return dtValue.ToString("dd/MM/yyyy HH:mm");

//            if (value is double dValue)
//            {
//                return dValue.ToString("N3", CultureInfo.GetCultureInfo("pt-BR"));
//            }

//            return value.ToString() ?? "";
//        }

//        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
//        {
//            //base.OnPrintPage(e);

//            int y = margin;
//            int x = margin;
//            int currentX = x;

//            // CÁLCULO DINÂMICO DA LARGURA DAS COLUNAS
//            float availableWidth = e.PageBounds.Width - 2 * margin;
//            float totalWeight = columnDefinitions.Sum(c => c.Weight);
//            float unitWidth = availableWidth / totalWeight;

//            var finalColWidths = columnDefinitions.Select(c => c.Weight * unitWidth).ToList();
//            // ----------------------------------------------------


//            // Desenha logo
//            if (currentPage == 0)
//            {
//                Image logo = Resources.dc;
//                if (logo != null)
//                {
//                    int logoWidth = 150;
//                    int logoHeight = 80;
//                    // Ajuste aqui: X é 'margin' para o canto esquerdo
//                    e.Graphics.DrawImage(logo, margin, margin, logoWidth, logoHeight);
//                }
//                // Adiciona espaço abaixo da logo para o cabeçalho começar abaixo dela
//                y += 90;
//            }


//            var properties = typeof(Produtos).GetProperties().ToDictionary(p => p.Name, p => p);

//            // Cabeçalho da Tabela (Mantido o código anterior)
//            currentX = x;
//            for (int i = 0; i < columnDefinitions.Length; i++)
//            {
//                string headerName = columnDefinitions[i].HeaderName;
//                float colWidth = finalColWidths[i];

//                e.Graphics.FillRectangle(headerBackgroundBrush, currentX, y, colWidth, rowHeight);
//                e.Graphics.DrawRectangle(Pens.Black, currentX, y, colWidth, rowHeight);

//                StringFormat headerFormat = new StringFormat
//                {
//                    Alignment = StringAlignment.Center,
//                    LineAlignment = StringAlignment.Center,
//                    Trimming = StringTrimming.EllipsisCharacter
//                };

//                e.Graphics.DrawString(headerName, headerFont, headerForegroundBrush, new RectangleF(currentX, y, colWidth, rowHeight), headerFormat);

//                currentX += (int)colWidth;
//            }

//            y += rowHeight;

//            // Linhas de produtos (Dados)
//            int maxBodyHeight = e.PageBounds.Height - margin - y;
//            int productsPerPage = maxBodyHeight / rowHeight;

//            int start = currentPage * productsPerPage;
//            int end = Math.Min(start + productsPerPage, produtos.Count);

//            // Configuração única para o formato do corpo
//            StringFormat bodyFormat = new StringFormat
//            {
//                LineAlignment = StringAlignment.Center,
//                // ESSA É A PROPRIEDADE CHAVE: TRUNCA o texto que não couber, adicionando "..."
//                Trimming = StringTrimming.EllipsisCharacter
//            };

//            // Loop para as linhas
//            for (int i = start; i < end; i++)
//            {
//                var p = produtos[i];
//                currentX = x; // Reseta a posição X para cada nova linha

//                // Loop para as células da linha
//                for (int j = 0; j < columnDefinitions.Length; j++)
//                {
//                    string propName = columnDefinitions[j].PropertyName;
//                    float colWidth = finalColWidths[j];

//                    string value = "";
//                    if (properties.TryGetValue(propName, out PropertyInfo propInfo))
//                    {
//                        var rawValue = propInfo.GetValue(p);
//                        value = FormatValue(propName, rawValue);
//                    }

//                    e.Graphics.DrawRectangle(Pens.Black, currentX, y, colWidth, rowHeight);

//                    // Desenha o valor usando a área da célula
//                    // Usamos RectangleF para que o Trimming funcione corretamente, pois ele precisa dos limites.
//                    RectangleF cellRect = new RectangleF(currentX + 2, y, colWidth - 4, rowHeight); // Subtrai 4 para padding

//                    // Desenha o valor da célula (preto), usando o bodyFormat que trunca o texto
//                    e.Graphics.DrawString(value, bodyFont, Brushes.Black, cellRect, bodyFormat);

//                    currentX += (int)colWidth;
//                }
//                y += rowHeight;
//            }

//            // Atualiza paginação
//            totalPages = (int)Math.Ceiling((double)produtos.Count / productsPerPage);
//            currentPage++;

//            e.HasMorePages = currentPage < totalPages;
//        }
//    }
//}