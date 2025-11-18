using ClosedXML.Excel;
using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using System.Globalization;
using System.Reflection;

namespace MapaEstoqueCD.Services
{
    internal class EntradaExcelDocument
    {
        private readonly List<EntradasViewerDto> produtos;

        private readonly (string PropertyName, string HeaderName, float Weight)[] columnDefinitions =
            [
              ("EntradaId", "Entrada ID", 0.6f),
    ("Tipo", "Tipo", 0.8f),

    ("UserNome", "Usuário", 1.2f),

    ("ProdutoCodigo", "Código Produto", 1.0f),
    ("ProdutoDescricao", "Descrição do Produto", 2.0f),

    ("QtdConferida", "Qtd. Conferida", 0.8f),
    ("QtdEntrada", "Qtd. Entrada", 0.8f),

    ("CifsNome", "CIF", 1.0f),

    ("Lote", "Lote", 1.0f),
    ("DataF", "Data Fab.", 1.0f),
    ("SemF", "Sem Fab.", 0.8f),

    ("CreateAt", "Criado Em", 1.2f),
    ("UpdateAt", "Atualizado Em", 1.2f),
            ];


        public EntradaExcelDocument(List<EntradasViewerDto> produtos)
        {
            this.produtos = produtos ?? new List<EntradasViewerDto>();
        }

        private static object? GetNestedPropertyValue(object? obj, string propertyPath)
        {
            if (obj == null || string.IsNullOrWhiteSpace(propertyPath)) return null;

            var parts = propertyPath.Split('.');
            object? current = obj;
            foreach (var part in parts)
            {
                if (current == null) return null;
                var type = current.GetType();
                var prop = type.GetProperty(part, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (prop == null) return null;
                current = prop.GetValue(current);
            }
            return current;
        }

        private string FormatValue(string propertyName, object? value)
        {
            if (value == null) return string.Empty;

            if (value is DateTime dt)
                return dt.ToString("dd/MM/yyyy HH:mm", CultureInfo.GetCultureInfo("pt-BR"));

            if (value is string s)
                return s;

            if (value is int i)
                return i.ToString("N0", CultureInfo.GetCultureInfo("pt-BR"));

            if (value is decimal decVal)
                return decVal.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"));

            if (value is double dVal)
                return dVal.ToString("N3", CultureInfo.GetCultureInfo("pt-BR"));

            if (value is float fVal)
                return fVal.ToString("N3", CultureInfo.GetCultureInfo("pt-BR"));

            return value.ToString() ?? string.Empty;
        }

        public void GenerateExcel(string outputPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Estoque");

            // Cabeçalho
            for (int i = 0; i < columnDefinitions.Length; i++)
            {
                var col = columnDefinitions[i];
                var cell = worksheet.Cell(1, i + 1);
                cell.Value = col.HeaderName;
                cell.Style.Font.Bold = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromArgb(64, 64, 64);
                cell.Style.Font.FontColor = XLColor.White;
                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            }

            // Dados
            int row = 2;
            foreach (var produto in produtos)
            {
                for (int colIndex = 0; colIndex < columnDefinitions.Length; colIndex++)
                {
                    var col = columnDefinitions[colIndex];
                    object? value = GetNestedPropertyValue(produto, col.PropertyName);
                    string formatted = FormatValue(col.PropertyName, value);

                    var cell = worksheet.Cell(row, colIndex + 1);
                    cell.Value = formatted;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                row++;
            }

            // Ajustar largura das colunas
            worksheet.Columns().AdjustToContents();

            // Bordas totais
            var range = worksheet.Range(1, 1, row - 1, columnDefinitions.Length);
            range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
            range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            workbook.SaveAs(outputPath);
        }
    }
}

