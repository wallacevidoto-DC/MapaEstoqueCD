using ClosedXML.Excel;
using MapaEstoqueCD.Database.Models;

namespace MapaEstoqueCD.Utils.Excel
{
    public class ExcelExporter
    {
        public static void ExportProdutos(List<Produtos> produtos, string caminhoArquivo)
        {
            var columns = new Dictionary<string, string>
        {
            { "Código", nameof(Produtos.Codigo) },
            { "Descrição", nameof(Produtos.Descricao) },
            { "NCM", nameof(Produtos.Ncm) },
            { "IPI", nameof(Produtos.Ipi) },
            { "PIS", nameof(Produtos.Pis) },
            { "COFINS", nameof(Produtos.Cofins) },
            { "Shelf Life", nameof(Produtos.ShelfLife) },
            { "EAN-13", nameof(Produtos.UCodigoBarras) },
            { "C(cm) Unit", nameof(Produtos.UC) },
            { "L(cm) Unit", nameof(Produtos.UL) },
            { "D(cm) Unit", nameof(Produtos.UD) },
            { "H(cm) Unit", nameof(Produtos.UH) },
            { "Peso Líquido (Unit)", nameof(Produtos.UPesoLiquido) },
            { "Peso Bruto (Unit)", nameof(Produtos.UPesoBruto) },
            { "DUN-13", nameof(Produtos.DCodigoBarras) },
            { "Qtd/Unidade", nameof(Produtos.DQtd) },
            { "C(cm) Caixa", nameof(Produtos.DC) },
            { "L(cm) Caixa", nameof(Produtos.DL) },
            { "H(cm) Caixa", nameof(Produtos.DH) },
            { "Peso Líquido (Caixa)", nameof(Produtos.DPesoLiquido) },
            { "Peso Bruto (Caixa)", nameof(Produtos.DPesoBruto) },
            { "DUN-14", nameof(Produtos.CCodigoBarras) },
            { "Qtd/Caixa", nameof(Produtos.CQtd) },
            { "C(cm) Palet", nameof(Produtos.CC) },
            { "L(cm) Palet", nameof(Produtos.CL) },
            { "H(cm) Palet", nameof(Produtos.CH) },
            { "Peso Líquido (Palet)", nameof(Produtos.CPesoLiquido) },
            { "Peso Bruto (Palet)", nameof(Produtos.CPesoBruto) },
            { "Caixas por Lastro", nameof(Produtos.PCxLastro) },
            { "Empilhamento (Cxs)", nameof(Produtos.PEmpCx) },
            { "Caixas por Palet", nameof(Produtos.PCxPalete) },
            { "Data de Atualização", nameof(Produtos.UpdateAt) },
            { "Data de Criação", nameof(Produtos.CreateAt) }
        };

            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Produtos");

            // Cores pastel
            var coralPastel = XLColor.FromArgb(255, 204, 203);
            var azulPastel = XLColor.FromArgb(173, 216, 230);
            var verdePastel = XLColor.FromArgb(204, 255, 204);
            var amareloPastel = XLColor.FromArgb(255, 255, 204);

            // Mapeamento de cores por coluna
            var cores = new Dictionary<string, XLColor>();
            foreach (var col in columns.Keys)
            {
                if (new[] { "EAN-13", "C(cm) Unit", "L(cm) Unit", "D(cm) Unit", "H(cm) Unit", "Peso Líquido (Unit)", "Peso Bruto (Unit)" }.Contains(col))
                    cores[col] = coralPastel;
                else if (new[] { "DUN-13", "Qtd/Unidade", "C(cm) Caixa", "L(cm) Caixa", "H(cm) Caixa", "Peso Líquido (Caixa)", "Peso Bruto (Caixa)" }.Contains(col))
                    cores[col] = azulPastel;
                else if (new[] { "DUN-14", "Qtd/Caixa", "C(cm) Palet", "L(cm) Palet", "H(cm) Palet", "Peso Líquido (Palet)", "Peso Bruto (Palet)" }.Contains(col))
                    cores[col] = verdePastel;
                else if (new[] { "Caixas por Lastro", "Empilhamento (Cxs)", "Caixas por Palet" }.Contains(col))
                    cores[col] = amareloPastel;
                else
                    cores[col] = XLColor.White;
            }

            // Cabeçalho
            int colIndex = 1;
            foreach (var header in columns.Keys)
            {
                var cell = ws.Cell(1, colIndex);
                cell.Value = header;
                cell.Style.Fill.BackgroundColor = cores[header];
                cell.Style.Font.Bold = true;

                // Adiciona borda no cabeçalho
                cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                colIndex++;
            }

            // Dados
            for (int rowIndex = 0; rowIndex < produtos.Count; rowIndex++)
            {
                var produto = produtos[rowIndex];
                colIndex = 1;
                foreach (var kvp in columns)
                {
                    var prop = produto.GetType().GetProperty(kvp.Value);
                    var value = prop?.GetValue(produto, null);

                    var cell = ws.Cell(rowIndex + 2, colIndex);

                    if (value is DateTime dt)
                        cell.Value = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    else if (value is double d)
                        cell.Value = d;
                    else if (value is int i)
                        cell.Value = i;
                    else
                        cell.Value = value?.ToString() ?? string.Empty;

                    // Cor da célula
                    cell.Style.Fill.BackgroundColor = cores[kvp.Key];

                    // Bordas finas em todas as células
                    cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;

                    colIndex++;
                }
            }

            // Auto-ajusta colunas
            ws.Columns().AdjustToContents();

            // Salva arquivo
            wb.SaveAs(caminhoArquivo);
        }
    }
}
