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

        public List<EstoqueWsDto>? GetEstoquetByFilter(List<FiltroItem> filtros, ref DataGridView datagrid)
        {

            if (filtros.Count == 0)
            {
                return GetAllEstoque(ref datagrid);
            }
            datagrid.Rows.Clear();

            var columns = Columns.Where(c => c.Visivel).ToList();

            List<EstoqueWsDto> estoque = estoqueService.GetAllEstoque();

            // --- 🔍 APLICA OS FILTROS ---
            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Valor))
                    continue;

                switch (filtro.Coluna.ToLower())
                {
                    case "produto.codigo":
                        estoque = filtro.Tipo switch
                        {
                            "contém" => estoque.Where(e => e.produto?.codigo?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => estoque.Where(e => string.Equals(e.produto?.codigo, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => estoque
                        };
                        break;

                    case "produto.descricao":
                        estoque = filtro.Tipo switch
                        {
                            "contém" => estoque.Where(e => e.produto?.descricao?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => estoque.Where(e => string.Equals(e.produto?.descricao, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => estoque
                        };
                        break;

                    case "quantidade":
                        if (int.TryParse(filtro.Valor, out int qtd))
                        {
                            estoque = filtro.Tipo switch
                            {
                                "maior" => estoque.Where(e => e.quantidade > qtd).ToList(),
                                "menor" => estoque.Where(e => e.quantidade < qtd).ToList(),
                                "igual" => estoque.Where(e => e.quantidade == qtd).ToList(),
                                _ => estoque
                            };
                        }
                        break;

                    case "semf":
                        if (int.TryParse(filtro.Valor, out int semF))
                            estoque = estoque.Where(e => e.semF == semF).ToList();
                        break;

                    case "enderecoid":
                        estoque = estoque.Where(e => e.enderecoId?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList();
                        break;

                    case "lote":
                        estoque = estoque.Where(e => e.lote?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList();
                        break;
                }
            }

            // --- 🧾 PREENCHER O GRID ---
            foreach (var p in estoque)
            {
                datagrid.Rows.Add(
                    p.estoqueId,
                    p.enderecoId,
                    p.produto?.codigo,
                    p.produto?.descricao,
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

        internal bool SetTranferencia(TranferenciaDto transferenciaDto)
        {
            transferenciaDto.userId = CacheMP.Instance.UserCurrent.UserId;
            return estoqueService.SetTransferencia(transferenciaDto);
        }

        internal bool SetPicking(PickingDto pickingDto)
        {
            pickingDto.userId = CacheMP.Instance.UserCurrent.UserId;
            return estoqueService.SetPicking(pickingDto);
        }
    }
}
