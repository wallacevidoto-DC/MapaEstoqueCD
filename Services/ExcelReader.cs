using ClosedXML.Excel;
using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using System.Globalization;
using System.Windows.Forms;

public class ExcelImporter
{
    public static async void ImportarProdutos(string caminhoExcel)
    {
        using var workbook = new XLWorkbook(caminhoExcel);
        var worksheet = workbook.Worksheet(1);
        int totalRows = worksheet.LastRowUsed().RowNumber() - 1;


        await ProgressHelper.RunWithProgressAsync(totalRows, async progress =>
        {
            using var db = new AppDbContext();

            for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
            {
                var produto = new Produtos
                {
                    Codigo = worksheet.Cell(row, 1).GetValue<string>().Trim(),
                    Descricao = worksheet.Cell(row, 2).GetValue<string>().Trim(),
                    Ncm = worksheet.Cell(row, 4).GetValue<string>().Trim().Replace(".",""),
                    Ipi = ParsePercentual(worksheet.Cell(row, 5).GetValue<string>()),
                    Pis = ParsePercentual(worksheet.Cell(row, 6).GetValue<string>()),
                    Cofins = ParsePercentual(worksheet.Cell(row, 7).GetValue<string>()),
                    ShelfLife = worksheet.Cell(row, 8).GetValue<string>().Trim(),

                    UCodigoBarras = worksheet.Cell(row, 9).GetValue<string>().Trim(),
                    UC = ParseDouble(worksheet.Cell(row, 10).GetValue<string>()),
                    UL = ParseDouble(worksheet.Cell(row, 11).GetValue<string>()),
                    UD = ParseDouble(worksheet.Cell(row, 12).GetValue<string>()),
                    UH = ParseDouble(worksheet.Cell(row, 13).GetValue<string>()),
                    UPesoLiquido = ParseDouble(worksheet.Cell(row, 14).GetValue<string>()),
                    UPesoBruto = ParseDouble(worksheet.Cell(row, 15).GetValue<string>()),

                    DCodigoBarras = worksheet.Cell(row, 16).GetValue<string>().Trim(),
                    DQtd = ParseInt(worksheet.Cell(row, 17).GetValue<string>()),
                    DC = ParseDouble(worksheet.Cell(row, 18).GetValue<string>()),
                    DL = ParseDouble(worksheet.Cell(row, 19).GetValue<string>()),
                    DH = ParseDouble(worksheet.Cell(row, 20).GetValue<string>()),
                    DPesoLiquido = ParseDouble(worksheet.Cell(row, 21).GetValue<string>()),
                    DPesoBruto = ParseDouble(worksheet.Cell(row, 22).GetValue<string>()),

                    CCodigoBarras = worksheet.Cell(row, 23).GetValue<string>().Trim(),
                    CQtd = ParseInt(worksheet.Cell(row, 24).GetValue<string>()),
                    CC = ParseDouble(worksheet.Cell(row, 25).GetValue<string>()),
                    CL = ParseDouble(worksheet.Cell(row, 26).GetValue<string>()),
                    CH = ParseDouble(worksheet.Cell(row, 27).GetValue<string>()),
                    CPesoLiquido = ParseDouble(worksheet.Cell(row, 28).GetValue<string>()),
                    CPesoBruto = ParseDouble(worksheet.Cell(row, 29).GetValue<string>()),

                    PCxLastro = ParseInt(worksheet.Cell(row, 30).GetValue<string>()),
                    PEmpCx = ParseInt(worksheet.Cell(row, 31).GetValue<string>()),
                    PCxPalete = ParseInt(worksheet.Cell(row, 32).GetValue<string>())
                };

                db.Produtos.Add(produto);
                progress.Report(row - 1);
            }

            db.SaveChanges();
        });
        
    }

    private static int? ParseInt(string valor)
        => int.TryParse(valor, out int result) ? result : (int?)null;

    private static double? ParseDouble(string valor)
    {
        if (double.TryParse(valor, NumberStyles.Any, new CultureInfo("pt-BR"), out double result))
            return result;
        if (double.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            return result;
        return null;
    }


    private static decimal? ParsePercentual(string valor)
    {
        return Convert.ToDecimal(valor);
        
        if (decimal.TryParse(valor, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
            return result;// divide por 100 para transformar em fração
        return null;
    }
}

