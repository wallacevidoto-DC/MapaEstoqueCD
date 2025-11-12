using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Geom;

namespace MapaEstoqueCD.Utils.Print
{
    public static class ExportDataGridViewToPdf
    {
        public static void ExportDataGridViewStyled(DataGridView dgv, string caminhoArquivo)
        {
            using var writer = new PdfWriter(caminhoArquivo);
            using var pdf = new PdfDocument(writer);

            // 👇 Aqui definimos a página como A4 horizontal
            var pageSize = PageSize.A4.Rotate();
            using var doc = new Document(pdf, pageSize);
            doc.SetMargins(20, 20, 20, 20);

            var colunasVisiveis = dgv.Columns.Cast<DataGridViewColumn>().Where(c => c.Visible).ToList();
            if (!colunasVisiveis.Any())
                throw new InvalidOperationException("Nenhuma coluna visível para exportar.");

            PdfFont fontNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont fontBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            float[] larguras = colunasVisiveis.Select(c => (float)Math.Max(c.Width, 20)).ToArray();

            // 👇 Usa largura proporcional e ocupa toda a página
            var table = new Table(UnitValue.CreatePercentArray(larguras))
                .UseAllAvailableWidth();

            // Cabeçalhos
            foreach (var col in colunasVisiveis)
            {
                var p = new Paragraph(col.HeaderText)
                    .SetFont(fontBold)
                    .SetFontSize(10)
                    .SetFontColor(ColorConstants.WHITE);

                var headerCell = new Cell()
                    .Add(p)
                    .SetBackgroundColor(new DeviceRgb(64, 64, 64))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER)
                    .SetPadding(5);

                table.AddHeaderCell(headerCell);
            }

            // Linhas
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                foreach (var col in colunasVisiveis)
                {
                    var raw = row.Cells[col.Index].Value;
                    string texto = raw?.ToString() ?? string.Empty;

                    var para = new Paragraph(texto)
                        .SetFont(fontNormal)
                        .SetFontSize(9);

                    var cell = new Cell()
                        .Add(para)
                        .SetBorder(Border.NO_BORDER)
                        .SetPadding(4)
                        .SetTextAlignment(col.DefaultCellStyle.Alignment switch
                        {
                            DataGridViewContentAlignment.MiddleRight or
                            DataGridViewContentAlignment.TopRight or
                            DataGridViewContentAlignment.BottomRight => TextAlignment.RIGHT,
                            DataGridViewContentAlignment.MiddleCenter or
                            DataGridViewContentAlignment.TopCenter or
                            DataGridViewContentAlignment.BottomCenter => TextAlignment.CENTER,
                            _ => TextAlignment.LEFT
                        });

                    if (row.Index % 2 == 0)
                        cell.SetBackgroundColor(new DeviceRgb(245, 245, 245));

                    table.AddCell(cell);
                }
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show($"PDF exportado com sucesso (horizontal):\n{caminhoArquivo}",
                            "Exportação", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

