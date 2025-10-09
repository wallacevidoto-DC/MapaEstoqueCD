using ClosedXML.Excel;
using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Utils;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

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
                    Ncm = worksheet.Cell(row, 4).GetValue<string>().Trim().Replace(".", ""),
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

    public static async Task ImportarEstoque(string fileName, List<Produtos> prods)
    {
        using var workbook = new XLWorkbook(fileName);
        var worksheet = workbook.Worksheet(1);
        int totalRows = worksheet.LastRowUsed().RowNumber() - 1;

        using var db = new AppDbContext();
        using var dbe = new AppDbContext();
        using var dbc = new AppDbContext();
        var cacheEnderecos = new Dictionary<string, Endereco>();

        try
        {
            //await ProgressHelper.RunWithProgressAsync(totalRows, async progress =>
            //{
                for (int row = 2; row <= worksheet.LastRowUsed().RowNumber(); row++)
                {
                    if (worksheet.Cell(row, 1).IsEmpty())
                        continue;

                    string cod = worksheet.Cell(row, 1).GetValue<string>().Trim();
                    var prod = prods.FirstOrDefault(x => x.Codigo == cod);
                    if (prod == null)
                        continue;

                    string R = worksheet.Cell(row, 6).GetValue<string>().Trim();
                    string B = worksheet.Cell(row, 7).GetValue<string>().Trim();
                    string A = worksheet.Cell(row, 8).GetValue<string>().Trim();

                    if (string.IsNullOrWhiteSpace(R) ||
                        string.IsNullOrWhiteSpace(B) ||
                        string.IsNullOrWhiteSpace(A))
                    {
                        continue;
                    }

                    string enderecoKey = $"{R}{B}{A}".ToUpper().Trim();

                    if (!cacheEnderecos.TryGetValue(enderecoKey, out Endereco endereco))
                    {
                        endereco = await dbc.Enderecos.FirstOrDefaultAsync(e => e.Rua == R && e.Coluna == B && e.Palete == A);

                        if (endereco == null)
                        {
                            endereco = new Endereco
                            {
                                Rua = R,
                                Coluna = B,
                                Palete = A
                            };
                            dbe.Enderecos.Add(endereco);
                            dbe.SaveChanges(); // pega EnderecoId
                        }

                        cacheEnderecos[enderecoKey] = endereco;
                    }

                    DateTime? dataFValue = worksheet.Cell(row, 2).IsEmpty() ? null : worksheet.Cell(row, 2).GetDateTime();
                    int? semFValue = worksheet.Cell(row, 3).IsEmpty() ? null : worksheet.Cell(row, 3).GetValue<int>();
                    int? quantidadeValue = worksheet.Cell(row, 4).IsEmpty() ? null : worksheet.Cell(row, 4).GetValue<int>();
                    DateTime? dataLValue = worksheet.Cell(row, 5).IsEmpty() ? null : worksheet.Cell(row, 5).GetDateTime();
                    string loteValue = worksheet.Cell(row, 9).IsEmpty() ? string.Empty : worksheet.Cell(row, 9).GetValue<string>().Trim();

                    var estoque = new Estoque
                    {
                        EnderecoId = endereco.EnderecoId,
                        ProdutoId = prod.ProdutoId,
                        DataF = dataFValue ?? DateTime.Now,
                        SemF = semFValue ?? 0,
                        Quantidade = quantidadeValue ?? 0,
                        DataL = dataLValue ?? DateTime.Now,
                        Lote = loteValue,
                    };

                    estoque.Movimentacoes = null;
                    estoque.Produto = null;
                    estoque.Endereco = null;

                    dbc.Estoque.Add(estoque);
                    //progress.Report(row - 1);
                    dbc.SaveChanges();
                }

                
            //});
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao importar estoque: " + ex);
            throw;
        }
    }
}



