using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using System.Diagnostics;

namespace MapaEstoqueCD.Controller
{
    public class MovimentacaoController
    {
        public readonly MovimentacaoService movimentacaoService = new();
        public readonly List<ColumnConfig> Columns;
        public Dictionary<string, Func<MovimentacaoDto, object>> ColunaParaFunc;
        public MovimentacaoController()
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

            ColunaParaFunc = new Dictionary<string, Func<MovimentacaoDto, object>>()
                            {
                                { "Usuário", p => p.usuarioNome },
                                { "Endereço", p => p.endereco },
                                { "Código", p => p.produtoCodigo },
                                { "Descrição", p => p.produtoDescricao },
                                { "Tipo.", p => p.tipo },
                                { "Qtd.", p => p.quantidade },
                                { "Data Fab.", p => p.dataF },
                                { "Sem. Fab.", p => p.semF },
                                { "Lote", p => p.lote },
                                { "Observações", p => p.obs },
                                { "Data de Criação", p => p.createAt },
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
                    p.movimentacaoId,
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



            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Valor))
                    continue;

                // Usamos filtro.Tabela que contém o nome da Propriedade (ValueMember)
                switch (filtro.Tabela.ToLower())
                {
                    case "movimentacaoid":
                        movimentacoes = movimentacoes.Where(m => m.movimentacaoId.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "usuarionome":
                        movimentacoes = movimentacoes.Where(m => m.usuarioNome != null && m.usuarioNome.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "produtocodigo":
                        movimentacoes = movimentacoes.Where(m => m.produtoCodigo != null && m.produtoCodigo.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "produtodescricao":
                        movimentacoes = movimentacoes.Where(m => m.produtoDescricao != null && m.produtoDescricao.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "tipo":
                        movimentacoes = movimentacoes.Where(m => m.tipo != null && m.tipo.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "quantidade":
                        movimentacoes = movimentacoes.Where(m => m.quantidade.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "dataf":
                        movimentacoes = movimentacoes.Where(m => m.dataF != null && m.dataF.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "semf":
                        movimentacoes = movimentacoes.Where(m => m.semF.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "lote":
                        movimentacoes = movimentacoes.Where(m => m.lote != null && m.lote.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "endereco":
                        movimentacoes = movimentacoes.Where(m => m.endereco != null && m.endereco.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "createat":
                        movimentacoes = movimentacoes.Where(m => m.createAt.ToString("dd/MM/yyyy HH:mm").Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "obs":
                        movimentacoes = movimentacoes.Where(m => m.obs != null && m.obs.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                }
            }

            foreach (var m in movimentacoes)
            {
                datagrid.Rows.Add(
                     m.movimentacaoId,
                    m.usuarioNome,
                    m.endereco,
                    m.produtoCodigo,
                    m.produtoDescricao,
                    m.tipo,
                    m.quantidade,
                    m.dataF,
                    m.semF,
                    m.lote,
                    m.obs,
                    m.createAt.ToString("g")
                );
            }

            return movimentacoes;
        }

        public List<MovimentacaoDto> GetMovimeById(ref DataGridView datagrid, MovimentacaoDto movimentacaoDto)
        {
            List<MovimentacaoDto> estoque = new List<MovimentacaoDto>();

            if (movimentacaoDto.estoqueId != null)
            {
                estoque = movimentacaoService.GetAllMovimeByIdEstoque((int)movimentacaoDto.estoqueId);
            }

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
    }
}
