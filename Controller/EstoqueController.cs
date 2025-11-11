using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using System.Diagnostics;

namespace MapaEstoqueCD.Controller
{
    public class EstoqueController
    {
        public readonly EstoqueService estoqueService = new();
        public readonly List<ColumnConfig> Columns;
        public EstoqueController()
        {
            Columns = new()
                            {
                                new ColumnConfig("Estoque ID", nameof(EstoqueWsDto.estoqueId)),
                                new ColumnConfig("Endereço", nameof(EstoqueWsDto.enderecoId)),
                                // new ColumnConfig("Produto ID", nameof(EstoqueWsDto.produtoId), false),
                                new ColumnConfig("Código do Produto", "produto.codigo"),
                                new ColumnConfig("Descrição do Produto", "produto.descricao"),
                                new ColumnConfig("Quantidade", nameof(EstoqueWsDto.quantidade)),
                                new ColumnConfig("Data F", nameof(EstoqueWsDto.dataF)),
                                new ColumnConfig("Sem F", nameof(EstoqueWsDto.semF)),
                                new ColumnConfig("Data L", nameof(EstoqueWsDto.dataL)),
                                new ColumnConfig("Lote", nameof(EstoqueWsDto.lote)),
                                new ColumnConfig("Observações", nameof(EstoqueWsDto.obs)),
                                new ColumnConfig("Data de Criação", nameof(EstoqueWsDto.createAt)),
                                new ColumnConfig("Data de Atualização", nameof(EstoqueWsDto.updateAt)),
                            };

        }

        internal List<EstoqueWsDto>? GetAllEstoque(ref ListView listView1)
        {
            listView1.Items.Clear();


            var columns = Columns.Where(c => c.Visivel).ToList();

            listView1.Columns.Clear();
            foreach (var col in columns)
                listView1.Columns.Add(col.Titulo);

            List<EstoqueWsDto> estoque = estoqueService.GetAllProd();

            foreach (var p in estoque)
            {
                var valores = columns.Select(c =>
                {
                    object? val = null;

                    if (c.Propriedade.Contains("."))
                    {
                        var parts = c.Propriedade.Split('.');
                        object? currentObj = p;

                        foreach (var part in parts)
                        {
                            if (currentObj == null) break;
                            var prop = currentObj.GetType().GetProperty(part);
                            currentObj = prop?.GetValue(currentObj);
                        }

                        val = currentObj;
                    }
                    else
                    {
                        var prop = typeof(EstoqueWsDto).GetProperty(c.Propriedade);
                        val = prop?.GetValue(p);
                    }

                    return val?.ToString() ?? "";
                }).ToArray();

                listView1.Items.Add(new ListViewItem(valores));
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            return estoque;
        }


        public List<EstoqueWsDto>? GetAllEstoque(ref DataGridView datagrid)
        {
            datagrid.Rows.Clear();


            var columns = Columns.Where(c => c.Visivel).ToList();

            List<EstoqueWsDto> estoque = estoqueService.GetAllEstoque();

            foreach (var p in estoque)
            {
                datagrid.Rows.Add(
                    p.estoqueId,
                    p.enderecoId,
                    p.produto.codigo,
                    p.produto.descricao,
                    p.quantidade,
                    p.dataL.ToShortDateString(),
                    DataFormatter.FormatarMesAno(p.dataF),
                    p.semF,
                    p.lote,
                    p.obs
                    );
            }

            return estoque;
        }
        public List<Produtos> GetAllProduct()
        {
            return CacheMP.Instance.Db.Produtos.ToList();
        }

        public void GetEstoquetByFilter(List<FiltroItem> filtros, ref ListView listView1)
        {
            throw new NotImplementedException();
        }

        public bool SetEntrada(EntradaDto entradaDto)
        {
            entradaDto.userId = CacheMP.Instance.UserCurrent.UserId;
            return estoqueService.SetEntrada(entradaDto);
        }

        public bool SetSaida(SaidaDto saidaDto)
        {
            saidaDto.userId = CacheMP.Instance.UserCurrent.UserId;
            return estoqueService.SetSaida(saidaDto);
        }

        public bool SetCorrecaoProduto(CorrecaoDto correcaoDto)
        {
            correcaoDto.userId = CacheMP.Instance.UserCurrent.UserId;
            return estoqueService.SetCorrecaoProduto(correcaoDto);
        }

        internal void PrintPdf(List<EstoqueWsDto> produtosCurrent)
        {
            var pdfGenerator = new EstoquePrintDocument(produtosCurrent);
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Estoque_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            pdfGenerator.GeneratePdf(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        internal void PrintExcel(List<EstoqueWsDto> produtosCurrent)
        {
            var pdfGenerator = new EstoquePrintDocument(produtosCurrent);
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Estoque_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            var exporter = new EstoqueExcelDocument(produtosCurrent);
            exporter.GenerateExcel(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }
    }
}
