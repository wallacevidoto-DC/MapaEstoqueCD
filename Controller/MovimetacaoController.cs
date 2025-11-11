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
    }   
}
