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
    public class ProdutosController
    {
        public readonly Dictionary<string, string> Columns;
        private readonly ProdutoService _produtoService = new();
        public ProdutosController()
        {
            Columns = new Dictionary<string, string>
            {{ "Código", "Cod" },
            { "Descrição", "Descricao" },
            { "NCM", "Ncm" },
            { "IPI", "Ipi" },
            { "PIS", "Pis" },
            { "COFINS", "Cofins" },
            { "Shelf Life", "ShelfLife" },
            { "EAN-13", "CodigoBarrasEan13" },
            { "C(cm) Unit", "CcmUnit" },
            { "L(cm) Unit", "LcmUnit" },
            { "D(cm) Unit", "DcmUnit" },
            { "H(cm) Unit", "HcmUnit" },
            { "Peso Líquido (Unit)", "PesoLiquidoUnit" },
            { "Peso Bruto (Unit)", "PesoBrutoUnit" },
            { "DUN-13", "CodigoBarrasDun13" },
            { "Qtd/Unidade", "QtdUnit" },
            { "C(cm) Caixa", "CcmCaixa" },
            { "L(cm) Caixa", "LcmCaixa" },
            { "H(cm) Caixa", "HcmCaixa" },
            { "Peso Líquido (Caixa)", "PesoLiquidoCaixa" },
            { "Peso Bruto (Caixa)", "PesoBrutoCaixa" },
            { "DUN-14", "CodigoBarrasDun14" },
            { "Qtd/Caixa", "QtdCaixa" },
            { "C(cm) Palet", "CcmPalet" },
            { "L(cm) Palet", "LcmPalet" },
            { "H(cm) Palet", "HcmPalet" },
            { "Peso Líquido (Palet)", "PesoLiquidoPalet" },
            { "Peso Bruto (Palet)", "PesoBrutoPalet" },
            { "Caixas por Lastro", "CxsPorLastro" },
            { "Empilhamento (Cxs)", "EmpCxs" },
            { "Caixas por Palet", "CxsPorPalet" },
            { "Data de Atualização", "UpdateAt" },
            { "Data de Criação", "CreateAt" }};
        }

        public void GetAllProduct(ref ListView listView)
        {
            listView.Items.Clear();
            List<Produtos> produtos = CacheMP.Instance.Db.Produtos.ToList();

            foreach (var p in produtos)
            {
                var valores = Columns.Values.Select(propName =>
                {
                    var prop = typeof(Produtos).GetProperty(propName);
                    var val = prop?.GetValue(p);
                    return val?.ToString() ?? "";
                }).ToArray();

                listView.Items.Add(new ListViewItem(valores));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void GetProductByFilter(List<FiltroItem> filtros, ref ListView listView)
        {
            listView.Items.Clear();
            var produtos = _produtoService.GetProdutosByFilter(filtros);
            
            foreach (var p in produtos.ToList())
            {
                var valores = Columns.Values.Select(propName =>
                {
                    var prop = typeof(Produtos).GetProperty(propName);
                    var val = prop?.GetValue(p);
                    return val?.ToString() ?? "";
                }).ToArray();
                listView.Items.Add(new ListViewItem(valores));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
