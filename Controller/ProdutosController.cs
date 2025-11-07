using MapaEstoqueCD.Database.Models;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.Utils.Excel;
using MapaEstoqueCD.View.Modal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MapaEstoqueCD.Controller
{
    public class ProdutosController
    {
        public readonly List<ColumnConfig> Columns;
        private readonly ProdutoService _produtoService = new();

        public ProdutosController()
        {
            Columns = new List<ColumnConfig>
            {
                new ColumnConfig("Código", nameof(Produtos.Codigo)),
                new ColumnConfig("Descrição", nameof(Produtos.Descricao)),
                new ColumnConfig("NCM", nameof(Produtos.Ncm)),
                new ColumnConfig("IPI", nameof(Produtos.Ipi)),
                new ColumnConfig("PIS", nameof(Produtos.Pis)),
                new ColumnConfig("COFINS", nameof(Produtos.Cofins)),
                new ColumnConfig("Shelf Life", nameof(Produtos.ShelfLife)),
                new ColumnConfig("EAN-13", nameof(Produtos.UCodigoBarras)),
                new ColumnConfig("C(cm) Unit", nameof(Produtos.UC)),
                new ColumnConfig("L(cm) Unit", nameof(Produtos.UL)),
                new ColumnConfig("D(cm) Unit", nameof(Produtos.UD)),
                new ColumnConfig("H(cm) Unit", nameof(Produtos.UH)),
                new ColumnConfig("Peso Líquido (Unit)", nameof(Produtos.UPesoLiquido)),
                new ColumnConfig("Peso Bruto (Unit)", nameof(Produtos.UPesoBruto)),
                new ColumnConfig("DUN-13", nameof(Produtos.DCodigoBarras)),
                new ColumnConfig("Qtd/Unidade", nameof(Produtos.DQtd)),
                new ColumnConfig("C(cm) Caixa", nameof(Produtos.DC)),
                new ColumnConfig("L(cm) Caixa", nameof(Produtos.DL)),
                new ColumnConfig("H(cm) Caixa", nameof(Produtos.DH)),
                new ColumnConfig("Peso Líquido (Caixa)", nameof(Produtos.DPesoLiquido)),
                new ColumnConfig("Peso Bruto (Caixa)", nameof(Produtos.DPesoBruto)),
                new ColumnConfig("DUN-14", nameof(Produtos.CCodigoBarras)),
                new ColumnConfig("Qtd/Caixa", nameof(Produtos.CQtd)),
                new ColumnConfig("C(cm) Palet", nameof(Produtos.CC)),
                new ColumnConfig("L(cm) Palet", nameof(Produtos.CL)),
                new ColumnConfig("H(cm) Palet", nameof(Produtos.CH)),
                new ColumnConfig("Peso Líquido (Palet)", nameof(Produtos.CPesoLiquido)),
                new ColumnConfig("Peso Bruto (Palet)", nameof(Produtos.CPesoBruto)),
                new ColumnConfig("Caixas por Lastro", nameof(Produtos.PCxLastro)),
                new ColumnConfig("Empilhamento (Cxs)", nameof(Produtos.PEmpCx)),
                new ColumnConfig("Caixas por Palet", nameof(Produtos.PCxPalete)),
                new ColumnConfig("Data de Atualização", nameof(Produtos.UpdateAt)),
                new ColumnConfig("Data de Criação", nameof(Produtos.CreateAt))
            };
        }

        // ----------------------------
        // MÉTODOS PRINCIPAIS
        // ----------------------------

        public List<Produtos> GetAllProduct(ref ListView listView)
        {
            var produtos = CacheMP.Instance.Db.Produtos.ToList();
            PopularListView(produtos, ref listView);
            return produtos;
        }

        public List<Produtos> GetProductByFilter(List<FiltroItem> filtros, ref ListView listView)
        {
            if (filtros == null || !filtros.Any())
                return GetAllProduct(ref listView);

            var produtos = _produtoService.GetProdutosByFilter(filtros);
            PopularListView(produtos, ref listView);
            return produtos;
        }

        // ----------------------------
        // FUNÇÕES AUXILIARES
        // ----------------------------

        private void PopularListView(List<Produtos> produtos, ref ListView listView)
        {
            listView.Items.Clear();
            listView.Columns.Clear();

            var columns = Columns.Where(c => c.Visivel).ToList();
            foreach (var col in columns)
                listView.Columns.Add(col.Titulo);

            foreach (var p in produtos)
            {
                var valores = columns.Select(c =>
                {
                    object? val = null;

                    // Propriedade aninhada (ex: produto.tipo.nome)
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
                        var prop = typeof(Produtos).GetProperty(c.Propriedade);
                        val = prop?.GetValue(p);
                    }

                    return val?.ToString() ?? "";
                }).ToArray();

                // Ajusta índices de IPI, PIS e COFINS (%)
                for (int i = 3; i <= 5 && i < valores.Length; i++)
                {
                    if (decimal.TryParse(valores[i], out decimal num))
                        valores[i] = (num * 100).ToString("0.##") + "%";
                    else
                        valores[i] = "0%";
                }

                listView.Items.Add(new ListViewItem(valores));
            }

            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public Produtos GetByCod(string id) => _produtoService.ObterPorCod(id);

        public void AddProduct(Produtos p, Image img)
        {
            p.Produto = img != null ? SalvarImagemLocal(img, p.Codigo) : null;
            _produtoService.Adicionar(p);
            MessageBox.Show("Produto adicionado com sucesso!");
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

        public Image? CarregarImagemProduto(string url)
        {
            try
            {
                if (File.Exists(url))
                    return Image.FromFile(url);

                string caminhoCompleto = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, url);
                return File.Exists(caminhoCompleto) ? Image.FromFile(caminhoCompleto) : null;
            }
            catch
            {
                return null;
            }
        }

        internal void PrintPdf(List<Produtos> produtosCurrent)
        {
            var pdfGenerator = new ProdutosPdfGenerator(produtosCurrent);
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Produtos_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            pdfGenerator.GeneratePdf(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        internal void ExportExcel(List<Produtos> produtosCurrent)
        {
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Produtos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");

            ExcelExporter.ExportProdutos(produtosCurrent, caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }
    }
}
