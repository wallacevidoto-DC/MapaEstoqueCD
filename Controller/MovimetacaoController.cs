using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MapaEstoqueCD.Controller
{
    public class MovimetacaoController
    {
        public readonly MovimentacaoService movimentacaoService = new();
        public readonly List<ColumnConfig> Columns;
        public MovimetacaoController()
        {
            Columns = new()
                {
                    //new ColumnConfig("ID Movimentação", nameof(MovimentacaoDto.movimentacaoId)),
                    new ColumnConfig("Estoque ID", nameof(MovimentacaoDto.estoqueId)),
                    new ColumnConfig("Endereço", nameof(MovimentacaoDto.endereco)),
                    new ColumnConfig("Usuário", nameof(MovimentacaoDto.usuarioNome)),
                    new ColumnConfig("Código do Produto", nameof(MovimentacaoDto.produtoCodigo)),
                    new ColumnConfig("Descrição do Produto", nameof(MovimentacaoDto.produtoDescricao)),
                    new ColumnConfig("Tipo", nameof(MovimentacaoDto.tipo)),
                    new ColumnConfig("Data F", nameof(MovimentacaoDto.dataF)),
                    new ColumnConfig("Sem F", nameof(MovimentacaoDto.semF)),
                    new ColumnConfig("Quantidade", nameof(MovimentacaoDto.quantidade)),
                    new ColumnConfig("Lote", nameof(MovimentacaoDto.lote)),
                    new ColumnConfig("Observações", nameof(MovimentacaoDto.obs)),
                    new ColumnConfig("Data de Criação", nameof(MovimentacaoDto.createAt)),
                };

        }

        public List<MovimentacaoDto>? GetAllMovimentacao(ref ListView listView1)
        {
            listView1.Items.Clear();


            var columns = Columns.Where(c => c.Visivel).ToList();

            listView1.Columns.Clear();
            foreach (var col in columns)
                listView1.Columns.Add(col.Titulo);

            List<MovimentacaoDto> estoque = movimentacaoService.GetAllMovime();

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
                        var prop = typeof(MovimentacaoDto).GetProperty(c.Propriedade);
                        val = prop?.GetValue(p);
                    }

                    return val?.ToString() ?? "";
                }).ToArray();

                listView1.Items.Add(new ListViewItem(valores));
            }

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

            return estoque;
        }

        public List<MovimentacaoDto>? GetAllMovimentacao(ref DataGridView datagrid)
        {
            datagrid.Rows.Clear();


            var columns = Columns.Where(c => c.Visivel).ToList();

            List<MovimentacaoDto> estoque = movimentacaoService.GetAllMovime();

            foreach (var p in estoque)
            {
                datagrid.Rows.Add(
                    p.usuarioNome,
                    p.endereco,
                    p.produtoCodigo,
                    p.produtoDescricao,
                    p.tipo,
                    p.quantidade,
                    p.dataF,
                    p.semF,
                    p.lote,
                    p.obs,
                    p.createAt);
            }

            return estoque;
        }

        internal void PrintPdf(List<MovimentacaoDto> produtosCurrent)
        {
            var pdfGenerator = new MovimentacaoPrintDocument(produtosCurrent);
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Estoque_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            pdfGenerator.GeneratePdf(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        internal void PrintExcel(List<MovimentacaoDto> produtosCurrent)
        {
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Estoque_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            var exporter = new MovimentacaoExcelDocument(produtosCurrent);
            exporter.GenerateExcel(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        internal List<MovimentacaoDto> GetEstoquetByFilter(List<FiltroItem> filtros, ref DataGridView datagrid)
        {
            if (filtros.Count == 0)
            {
                return GetAllMovimentacao(ref datagrid);
            }

            datagrid.Rows.Clear();

            var columns = Columns.Where(c => c.Visivel).ToList();

            List<MovimentacaoDto> movimentacoes = movimentacaoService.GetAllMovime();

            // --- 🔍 APLICA OS FILTROS ---
            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Valor))
                    continue;

                switch (filtro.Coluna.ToLower())
                {
                    case "usuário":
                    case "usuario":
                    case "usuarionome":
                        movimentacoes = filtro.Tipo switch
                        {
                            "contém" => movimentacoes.Where(m => m.usuarioNome?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => movimentacoes.Where(m => string.Equals(m.usuarioNome, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => movimentacoes
                        };
                        break;

                    case "produto.codigo":
                    case "produtocodigo":
                        movimentacoes = filtro.Tipo switch
                        {
                            "contém" => movimentacoes.Where(m => m.produtoCodigo?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => movimentacoes.Where(m => string.Equals(m.produtoCodigo, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => movimentacoes
                        };
                        break;

                    case "produto.descricao":
                    case "produtodescricao":
                        movimentacoes = filtro.Tipo switch
                        {
                            "contém" => movimentacoes.Where(m => m.produtoDescricao?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => movimentacoes.Where(m => string.Equals(m.produtoDescricao, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => movimentacoes
                        };
                        break;

                    case "tipo":
                        movimentacoes = filtro.Tipo switch
                        {
                            "contém" => movimentacoes.Where(m => m.tipo?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => movimentacoes.Where(m => string.Equals(m.tipo, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => movimentacoes
                        };
                        break;

                    case "quantidade":
                        if (int.TryParse(filtro.Valor, out int qtd))
                        {
                            movimentacoes = filtro.Tipo switch
                            {
                                "maior" => movimentacoes.Where(m => m.quantidade > qtd).ToList(),
                                "menor" => movimentacoes.Where(m => m.quantidade < qtd).ToList(),
                                "igual" => movimentacoes.Where(m => m.quantidade == qtd).ToList(),
                                _ => movimentacoes
                            };
                        }
                        break;

                    case "semf":
                        if (int.TryParse(filtro.Valor, out int semF))
                            movimentacoes = movimentacoes.Where(m => m.semF == semF).ToList();
                        break;

                    case "lote":
                        movimentacoes = filtro.Tipo switch
                        {
                            "contém" => movimentacoes.Where(m => m.lote?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => movimentacoes.Where(m => string.Equals(m.lote, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => movimentacoes
                        };
                        break;

                    case "dataf":
                        if (DateTime.TryParse(filtro.Valor, out DateTime dataF))
                        {
                            movimentacoes = movimentacoes.Where(m => Convert.ToDateTime(m.dataF) == dataF.Date).ToList();
                        }
                        break;

                    case "datadecriação":
                    case "createat":
                        if (DateTime.TryParse(filtro.Valor, out DateTime createAt))
                        {
                            movimentacoes = movimentacoes.Where(m => m.createAt.Date == createAt.Date).ToList();
                        }
                        break;
                }
            }
            foreach (var m in movimentacoes)
            {
                datagrid.Rows.Add(
                    //m.estoqueId,
                    m.usuarioNome,
                    m.endereco,
                    m.produtoCodigo,
                    m.produtoDescricao,
                    m.tipo,
                    m.dataF,
                    m.semF,
                    m.quantidade,
                    m.lote,
                    m.obs,
                    m.createAt.ToString("g")
                );
            }

            return movimentacoes;
        }

    }
}
