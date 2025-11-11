using iText.Commons.Actions;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Event;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Utils.Print;
using System.Globalization;
namespace MapaEstoqueCD.Services
{

    public class EstoquePrintDocument
    {
        private readonly List<EstoqueWsDto> produtos;

        private readonly (string PropertyName, string HeaderName, float Weight)[] columnDefinitions = new (string, string, float)[]
        {
           //("estoqueId", "Estoque ID", 1.0f),
            ("enderecoId", "Endereço", 0.5f),
            ("produto.codigo", "Código do Produto", 1.0f),
            ("produto.descricao", "Descrição do Produto", 2.0f),
            ("quantidade", "Quantidade", 0.8f),
            ("dataF", "Data Fab.", 1.0f),
            ("semF", "Sem Fab.", 0.8f),
            ("dataL", "Data Lan.", 1.0f),
            ("lote", "Lote", 1.0f),
            ("obs", "Observações", 2.0f),
            //("createAt", "Data de Criação", 1.2f),
            //("updateAt", "Data de Atualização", 1.2f),
        };

        public EstoquePrintDocument(List<EstoqueWsDto> produtos)
        {
            this.produtos = produtos;
        }

        private string FormatValue(string propertyName, object value)
        {
            if (value == null) return "";

            if (propertyName == "dataL")
            {
                return Convert.ToDateTime(value).ToShortDateString();
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

            string dataHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            pdf.AddEventHandler(PdfDocumentEvent.END_PAGE, new FooterEventHandler($"Gerado por {CacheMP.Instance.UserCurrent.Name} em {DateTime.Now:dd/MM/yyyy HH:mm}"));




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
                .Add(new Paragraph("LISTA DE PRODUTOS NO ESTOQUE").SetFont(boldFont).SetFontSize(18))
                .SetTextAlignment(TextAlignment.CENTER)
                .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                .SetBorder(Border.NO_BORDER);
            headerTable.AddCell(titleCell);

            document.Add(headerTable);
            document.Add(new Paragraph("\n")); 
            float totalWeight = columnDefinitions.Sum(c => c.Weight);

            // Faz a tabela usar proporções relativas em vez de pontos absolutos
            float[] colWidths = columnDefinitions.Select(c => c.Weight).ToArray();
            Table table = new Table(UnitValue.CreatePercentArray(colWidths))
                .UseAllAvailableWidth()
                .SetTextAlignment(TextAlignment.CENTER)
                .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
            // Cabeçalho da tabela
            foreach (var col in columnDefinitions)
            {
                var headerCell = new Cell()
                    .Add(new Paragraph(col.HeaderName)
                        .SetFont(boldFont)
                        .SetFontSize(7)
                        .SetFontColor(ColorConstants.WHITE))
                    .SetBackgroundColor(ColorConstants.DARK_GRAY)
                    .SetTextAlignment(TextAlignment.CENTER);
                table.AddHeaderCell(headerCell);
            }

            // Dados
            // --- Preenche linhas da tabela ---
            foreach (var produto in produtos)
            {
                foreach (var col in columnDefinitions)
                {
                    object? rawValue = null;

                    // Caminho da propriedade, exemplo: "produto.codigo"
                    string[] path = col.PropertyName.Split('.');
                    object? current = produto;

                    foreach (var part in path)
                    {
                        if (current == null) break;

                        var type = current.GetType();
                        var propInfo = type.GetProperty(part);
                        if (propInfo == null) break;

                        current = propInfo.GetValue(current);
                    }

                    rawValue = current;
                    string value = FormatValue(col.PropertyName, rawValue);

                    // Trunca texto longo
                    //if (value.Length > 30)
                    //    value = value.Substring(0, 27) + "...";

                    var cell = new Cell()
                        .Add(new Paragraph(value).SetFontSize(6))
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetVerticalAlignment(VerticalAlignment.MIDDLE)
                        .SetPadding(2);

                    table.AddCell(cell);
                }
            }

            


            document.Add(table);
            document.Close();
        }
    }
}
