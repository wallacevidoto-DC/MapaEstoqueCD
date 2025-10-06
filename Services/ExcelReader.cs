//using ClosedXML.Excel;
//using MapaEstoqueCD.Database.Models;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;

//namespace MapaEstoqueCD.Services
//{
//    public class ExcelReader
//    {
//        public static List<Produtos> GetDataSourceFromExcel(string filePath)
//        {
//            var produtos = new List<Produtos>();

//            if (!File.Exists(filePath))
//            {
//                throw new FileNotFoundException($"O arquivo não foi encontrado: {filePath}");
//            }

//            // --- Função Auxiliar para Leitura Segura de Strings (Evita InvalidCastException) ---
//            string GetCellValueSafe(IXLRow row, int colIndex)
//            {
//                var cell = row.Cell(colIndex);
//                if (cell.IsEmpty())
//                {
//                    return string.Empty;
//                }
//                // Retorna o valor formatado (texto)
//                return cell.GetString();
//            }
//            // ----------------------------------------------------------------------------------

//            using (var workbook = new XLWorkbook(filePath))
//            {
//                var worksheet = workbook.Worksheets.FirstOrDefault();
//                if (worksheet == null) return produtos;

//                // A leitura começa na Linha 3 (Rótulo 1 e 2 são cabeçalhos)
//                int startRow = 3;

//                // Itera apenas pelas linhas que contêm dados
//                foreach (var row in worksheet.RowsUsed().Where(r => r.RowNumber() >= startRow))
//                {
//                    var produto = new Produtos();

//                    try
//                    {
//                        // Colunas de DADOS PRINCIPAIS (Texto)
//                        produto.Cod = GetCellValueSafe(row, 1);    // Coluna A: COD
//                        produto.Descricao = GetCellValueSafe(row, 2); // Coluna B: DESCRIÇÃO

//                        // Coluna C: IMAGEM (Nula no ClosedXML)
//                        //produto.ImagemProduto = null;

//                        produto.Produto = null;
//                            var x = GetCellValueSafe(row, 3); // Coluna D: PRODUTO (Texto)

//                        // Colunas de IMPOSTOS / INFORMAÇÕES GERAIS
//                        produto.Ncm = GetCellValueSafe(row, 5);          // Coluna E: NCM
//                        produto.Ipi = row.Cell(6).GetValue<double?>() ?? 0.0;     // Coluna F: IPI
//                        produto.Pis = row.Cell(7).GetValue<double?>() ?? 0.0;     // Coluna G: PIS
//                        produto.Cofins = row.Cell(8).GetValue<double?>() ?? 0.0;  // Coluna H: COFINS
//                        produto.ShelfLife = GetCellValueSafe(row, 9);    // Coluna I: SHELF LIFE

//                        // --- UNIDADE (Unit) --- (Colunas J a R)
//                        produto.CodigoBarrasEan13 = GetCellValueSafe(row, 10); // Coluna J
//                        produto.CcmUnit = row.Cell(11).GetValue<double?>() ?? 0.0; // Coluna K (C)
//                        produto.LcmUnit = row.Cell(12).GetValue<double?>() ?? 0.0; // Coluna L (L)
//                        produto.DcmUnit = row.Cell(13).GetValue<double?>() ?? 0.0; // Coluna M (D)
//                        produto.HcmUnit = row.Cell(14).GetValue<double?>() ?? 0.0; // Coluna N (H)
//                        produto.PesoLiquidoUnit = row.Cell(15).GetValue<double?>() ?? 0.0; // Coluna O
//                        produto.PesoBrutoUnit = row.Cell(16).GetValue<double?>() ?? 0.0;   // Coluna P
//                        produto.CodigoBarrasDun13 = GetCellValueSafe(row, 17);  // Coluna Q
//                        produto.QtdUnit = row.Cell(18).GetValue<int?>() ?? 0;   // Coluna R (QTD)

//                        // --- CAIXA (Caixa) --- (Colunas S a Z)
//                        produto.CcmCaixa = row.Cell(19).GetValue<double?>() ?? 0.0;     // Coluna S (C)
//                        produto.LcmCaixa = row.Cell(20).GetValue<double?>() ?? 0.0;     // Coluna T (L)
//                        produto.HcmCaixa = row.Cell(21).GetValue<double?>() ?? 0.0;     // Coluna U (H)
//                        produto.PesoLiquidoCaixa = row.Cell(22).GetValue<double?>() ?? 0.0; // Coluna V
//                        produto.PesoBrutoCaixa = row.Cell(23).GetValue<double?>() ?? 0.0;   // Coluna W
//                        produto.CodigoBarrasDun14 = GetCellValueSafe(row, 24);  // Coluna X
//                        produto.QtdCaixa = row.Cell(25).GetValue<int?>() ?? 0;  // Coluna Y (QTD)

//                        // --- PALET (Pallet) --- (Colunas AA a AE)
//                        produto.CcmPalet = row.Cell(27).GetValue<double?>() ?? 0.0;     // Coluna AA (27) (C)
//                        produto.LcmPalet = row.Cell(28).GetValue<double?>() ?? 0.0;     // Coluna AB (28) (L)
//                        produto.HcmPalet = row.Cell(29).GetValue<double?>() ?? 0.0;     // Coluna AC (29) (H)
//                        produto.PesoLiquidoPalet = row.Cell(30).GetValue<double?>() ?? 0.0; // Coluna AD (30)
//                        produto.PesoBrutoPalet = row.Cell(31).GetValue<double?>() ?? 0.0;   // Coluna AE (31)

//                        // --- Cxs / Pallet (Colunas AF, AG, AH)
//                        produto.CxsPorLastro = row.Cell(32).GetValue<int?>() ?? 0; // Coluna AF (Cxs/Lastro)
//                        produto.EmpCxs = row.Cell(33).GetValue<int?>() ?? 0;       // Coluna AG (Emp/Cxs)
//                        produto.CxsPorPalet = row.Cell(34).GetValue<int?>() ?? 0;  // Coluna AH (Cxs/Palet)

//                        // Nota sobre Colunas Vazias: A planilha tem uma coluna vazia (Z), 
//                        // pulando do índice 25 (Y) para o 27 (AA). O ClosedXML não se importa com colunas
//                        // vazias, mas a numeração é sequencial.
//                        // (26 é a coluna Z, que parece estar vazia na imagem)

//                        produtos.Add(produto);
//                    }
//                    catch (Exception ex)
//                    {
//                        // Em caso de erro na conversão de um valor (ex: texto em campo double), 
//                        // ele logará e pulará a linha.
//                        Console.WriteLine($"Erro ao ler a Linha {row.RowNumber()} do Excel: {ex.Message}");
//                        // Você pode adicionar um 'continue;' aqui se quiser que a leitura siga.
//                    }
//                }
//            }

//            return produtos;
//        }
//    }
//}


   