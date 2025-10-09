using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.View.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapaEstoqueCD.Controller
{
    public class EstoqueController
    {
        public readonly EstoqueService estoqueService = new();
        public readonly Dictionary<string, string> Columns;
        public EstoqueController()
        {
            Columns = new Dictionary<string, string>
            {
                { "Estoque ID", nameof(EstoqueWsDto.estoqueId) },
                { "Endereço ID", nameof(EstoqueWsDto.enderecoId) },
                //{ "Produto ID", nameof(EstoqueWsDto.produtoId) },
                { "Código do Produto", "produto.codigo" },
                { "Descrição do Produto", "produto.descricao" },
                { "Quantidade", nameof(EstoqueWsDto.quantidade) },
                { "Data F", nameof(EstoqueWsDto.dataF) },
                { "Sem F", nameof(EstoqueWsDto.semF) },
                { "Data L", nameof(EstoqueWsDto.dataL) },
                { "Lote", nameof(EstoqueWsDto.lote) },
                { "Observações", nameof(EstoqueWsDto.obs) },
                { "Data de Criação", nameof(EstoqueWsDto.createAt) },
                { "Data de Atualização", nameof(EstoqueWsDto.updateAt) },
                // Campos do Produto (ProdutoWsDto) aninhado
            };

        }

        internal List<EstoqueWsDto>? GetAllEstoque(ref ListView listView1)
        {
            listView1.Items.Clear();
            List<EstoqueWsDto> estoque = estoqueService.GetAllProd();

            foreach (var p in estoque)
            {
                var valores = Columns.Values.Select(propName =>
                {
                    object? val = null;

                    // Trata propriedades aninhadas (ex: "produto.codigo")
                    if (propName.Contains("."))
                    {
                        var parts = propName.Split('.');
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
                        var prop = typeof(EstoqueWsDto).GetProperty(propName);
                        val = prop?.GetValue(p);
                    }

                    return val?.ToString() ?? "";
                }).ToArray();

                listView1.Items.Add(new ListViewItem(valores));
            }

            // Ajusta tamanho das colunas
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            return estoque;
        }

        public List<Produtos> GetAllProduct()
        {
            return CacheMP.Instance.Db.Produtos.ToList();
        }

        internal void GetEstoquetByFilter(List<FiltroItem> filtros, ref ListView listView1)
        {
            throw new NotImplementedException();
        }
    }
}
