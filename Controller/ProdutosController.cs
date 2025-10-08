using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils.Excel;
using MapaEstoqueCD.View.Modal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapaEstoqueCD.Controller
{
    public class ProdutosController
    {
        public readonly Dictionary<string, string> Columns;
        private readonly ProdutoService _produtoService = new();
        public ProdutosController()
        {
            Columns = new Dictionary<string, string>
            {
                { "Código", nameof(Produtos.Codigo) },
                { "Descrição", nameof(Produtos.Descricao) },
                { "NCM", nameof(Produtos.Ncm) },
                { "IPI", nameof(Produtos.Ipi) },
                { "PIS", nameof(Produtos.Pis) },
                { "COFINS", nameof(Produtos.Cofins) },
                { "Shelf Life", nameof(Produtos.ShelfLife) },
                { "EAN-13", nameof(Produtos.UCodigoBarras) },
                { "C(cm) Unit", nameof(Produtos.UC) },
                { "L(cm) Unit", nameof(Produtos.UL) },
                { "D(cm) Unit", nameof(Produtos.UD) },
                { "H(cm) Unit", nameof(Produtos.UH) },
                { "Peso Líquido (Unit)", nameof(Produtos.UPesoLiquido) },
                { "Peso Bruto (Unit)", nameof(Produtos.UPesoBruto) },
                { "DUN-13", nameof(Produtos.DCodigoBarras) },
                { "Qtd/Unidade", nameof(Produtos.DQtd) },
                { "C(cm) Caixa", nameof(Produtos.DC) },
                { "L(cm) Caixa", nameof(Produtos.DL) },
                { "H(cm) Caixa", nameof(Produtos.DH) },
                { "Peso Líquido (Caixa)", nameof(Produtos.DPesoLiquido) },
                { "Peso Bruto (Caixa)", nameof(Produtos.DPesoBruto) },
                { "DUN-14", nameof(Produtos.CCodigoBarras) },
                { "Qtd/Caixa", nameof(Produtos.CQtd) },
                { "C(cm) Palet", nameof(Produtos.CC) },
                { "L(cm) Palet", nameof(Produtos.CL) },
                { "H(cm) Palet", nameof(Produtos.CH) },
                { "Peso Líquido (Palet)", nameof(Produtos.CPesoLiquido) },
                { "Peso Bruto (Palet)", nameof(Produtos.CPesoBruto) },
                { "Caixas por Lastro", nameof(Produtos.PCxLastro) },
                { "Empilhamento (Cxs)", nameof(Produtos.PEmpCx) },
                { "Caixas por Palet", nameof(Produtos.PCxPalete) },
                { "Data de Atualização", nameof(Produtos.UpdateAt) },
                { "Data de Criação", nameof(Produtos.CreateAt) }
            };

        }

        public List<Produtos> GetAllProduct(ref ListView listView)
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



                valores[3] = (Convert.ToDecimal(valores[3]) * 100) + "%";
                valores[4] = (Convert.ToDecimal(valores[4]) * 100) + "%";
                valores[5] = (Convert.ToDecimal(valores[5]) * 100) + "%";


                listView.Items.Add(new ListViewItem(valores));
            }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            return produtos;
        }

        public List<Produtos> GetProductByFilter(List<FiltroItem> filtros, ref ListView listView)
        {
            if (filtros == null || !filtros.Any())
            {
                return GetAllProduct(ref listView);                
            }
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
            return produtos;
        }

        public Produtos GetByCod(string id) => _produtoService.ObterPorCod(id);

        public void AddProduct(Produtos p, Image img)
        {
            p.Produto = img != null ? SalvarImagemLocal(img, p.Codigo) : null;
            _produtoService.Adicionar(p);
            MessageBox.Show("Produto adiciondo com sucesso!");
        }

        public void UpdateProduct(Produtos p, Image img)
        {
            p.Produto = img != null ? SalvarImagemLocal(img, p.Codigo) : null;
            _produtoService.Atualizar(p);

            MessageBox.Show("Produto atualizado com sucesso!");

        }
        private static string SalvarImagemLocal(Image imagem, string nomeArquivo)
        {
            try
            {
                string pasta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "imagens", "produtos");

                if (!Directory.Exists(pasta))
                    Directory.CreateDirectory(pasta);

                if (!nomeArquivo.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase))
                    nomeArquivo += ".jpg";

                string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

                imagem.Save(caminhoCompleto, System.Drawing.Imaging.ImageFormat.Jpeg);

                return Path.Combine("imagens", "produtos", nomeArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar imagem: {ex.Message}");
            }
        }

        public Image CarregarImagemProduto(string url)
        {
            try
            {
                if (File.Exists(url))
                {
                    return Image.FromFile(url);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        internal void PrintPdf(List<Produtos> produtosCurrent)
        {
            var pdfGenerator = new ProdutosPdfGenerator(produtosCurrent);
            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Produtos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
            pdfGenerator.GeneratePdf(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        internal void ExportExcel(List<Produtos> produtosCurrent)
        {
            string caminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
               $"Produtos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            ExcelExporter.ExportProdutos(produtosCurrent, caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }
    }
}
