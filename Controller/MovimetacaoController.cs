using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Controller
{
    public class MovimetacaoController
    {
        public readonly EstoqueService estoqueService = new();
        public readonly List<ColumnConfig> Columns;
        public MovimetacaoController()
        {
            Columns = new()
                {
                    new ColumnConfig("ID Movimentação", nameof(MovimentacaoDto.movimentacaoId)),
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

        internal List<MovimentacaoDto>? GetAllEstoque(ref ListView listView1)
        {
            listView1.Items.Clear();

            
            var columns = Columns.Where(c => c.Visivel).ToList();
           
            listView1.Columns.Clear();
            foreach (var col in columns)
                listView1.Columns.Add(col.Titulo);

            List<MovimentacaoDto> estoque = estoqueService.GetAllProd();

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

        public List<MovimentacaoDto> GetAllProduct()
        {
            return CacheMP.Instance.Db.m.ToList();
        }

        internal void GetEstoquetByFilter(List<FiltroItem> filtros, ref ListView listView1)
        {
            throw new NotImplementedException();
        }
    }
}
