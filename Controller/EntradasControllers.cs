using MapaEstoqueCD.Database.Dto;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.Utils;
using MapaEstoqueCD.View.Modal;
using System.Diagnostics;

namespace MapaEstoqueCD.Controller
{
    public class EntradasControllers
    {
        public readonly EntradasService entradasService = new();


        public readonly List<ColumnConfig> Columns;

        public EntradasControllers()
        {
            Columns = new()
                        {
                             new ColumnConfig("Entrada ID", nameof(EntradasViewerDto.EntradaId)),

                            new ColumnConfig("Código do Produto", nameof(EntradasViewerDto.ProdutoCodigo)),
                            new ColumnConfig("Descrição do Produto", nameof(EntradasViewerDto.ProdutoDescricao)),

                            new ColumnConfig("Tipo", nameof(EntradasViewerDto.Tipo)),
                            new ColumnConfig("Qtd Conferida", nameof(EntradasViewerDto.QtdConferida)),
                            new ColumnConfig("Qtd de Entrada", nameof(EntradasViewerDto.QtdEntrada)),

                            new ColumnConfig("Nome da CIF", nameof(EntradasViewerDto.CifsNome)),

                            new ColumnConfig("Lote", nameof(EntradasViewerDto.Lote)),
                            new ColumnConfig("Data F", nameof(EntradasViewerDto.DataF)),
                            new ColumnConfig("Sem F", nameof(EntradasViewerDto.SemF)),

                            new ColumnConfig("Usuário", nameof(EntradasViewerDto.UserNome)),

                            new ColumnConfig("Data de Criação", nameof(EntradasViewerDto.CreateAt)),
                            new ColumnConfig("Data de Atualização", nameof(EntradasViewerDto.UpdateAt)),
                        };
        }

        public bool SetEntradaLivre(EntradaLvDto entradaLvDto)
        {
            try
            {
                entradaLvDto.userId = CacheMP.Instance.UserCurrent.UserId;
                entradasService.SetEntradaLivre(entradaLvDto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<EntradasViewerDto>? AllGetEntradas(ref DataGridView datagrid)
        {
            datagrid.Rows.Clear();

            List<EntradasViewerDto> estoque = entradasService.GetAllEntradas();

            foreach (var p in estoque)
            {
                datagrid.Rows.Add(
                    p.EntradaId,
                    p.UserNome,
                    p.ProdutoCodigo,
                    p.ProdutoDescricao,
                    p.Tipo,
                    p.CifsNome,
                    p.QtdConferida,
                    //p.QtdEntrada,
                    DataFormatter.FormatarMesAno(p.DataF),
                    p.SemF,
                    p.Lote,
                    p.CreateAt
                    );
            }

            return estoque;
        }
        

        public void PrinfPdf(List<EntradasViewerDto> entradasCurrent)
        {
            var pdfGenerator = new EntradaPrintDocument(entradasCurrent);
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Estoque_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");

            pdfGenerator.GeneratePdf(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        public void PritExcel(List<EntradasViewerDto> entradasCurrent)
        {
            string caminho = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"Estoque_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
            var exporter = new EntradaExcelDocument(entradasCurrent);
            exporter.GenerateExcel(caminho);
            Process.Start(new ProcessStartInfo(caminho) { UseShellExecute = true });
        }

        public List<EntradasViewerDto> GetEntradasByFilter(List<FiltroItem> filtros, ref DataGridView datagrid)
        {
            if (filtros.Count == 0)
                return AllGetEntradas(ref datagrid);

            datagrid.Rows.Clear();

            List<EntradasViewerDto> entradas = entradasService.GetAllEntradas();

            foreach (var filtro in filtros)
            {
                if (string.IsNullOrWhiteSpace(filtro.Valor))
                    continue;

                // Usamos filtro.Tabela que contém o nome da Propriedade (ValueMember)
                switch (filtro.Tabela.ToLower())
                {
                    case "entradaid":
                        entradas = entradas.Where(e => e.EntradaId.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "tipo":
                        entradas = entradas.Where(e => e.Tipo != null && e.Tipo.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "usernome":
                        entradas = entradas.Where(e => e.UserNome != null && e.UserNome.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "produtocodigo":
                        entradas = entradas.Where(e => e.ProdutoCodigo != null && e.ProdutoCodigo.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "produtodescricao":
                        entradas = entradas.Where(e => e.ProdutoDescricao != null && e.ProdutoDescricao.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "qtdconferida":
                        entradas = entradas.Where(e => e.QtdConferida.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "qtdentrada":
                        entradas = entradas.Where(e => e.QtdEntrada.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "cifsnome":
                        entradas = entradas.Where(e => e.CifsNome != null && e.CifsNome.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "lote":
                        entradas = entradas.Where(e => e.Lote != null && e.Lote.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "dataf":
                        entradas = entradas.Where(e => e.DataF != null && e.DataF.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "semf":
                        entradas = entradas.Where(e => e.SemF.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;

                    case "createat":
                        entradas = entradas.Where(e => e.CreateAt.HasValue && e.CreateAt.Value.ToString("dd/MM/yyyy HH:mm").Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList();
                        break;
                }
            }

            foreach (var p in entradas)
            {
                datagrid.Rows.Add(
                    p.EntradaId,
                    p.UserNome,
                    p.ProdutoCodigo,
                    p.ProdutoDescricao,
                    p.Tipo,
                    p.CifsNome,
                    p.QtdConferida,
                    //p.QtdEntrada,
                    DataFormatter.FormatarMesAno(p.DataF),
                    p.SemF,
                    p.Lote,
                    p.CreateAt
                );
            }

            return entradas;
        }

        public void SetEntradaLivreConferida(EntradasViewerDto entradaSelecionado)
        {
            entradasService.SetEntradaLivreConferida(entradaSelecionado);
        }

        public bool SetCorrecaoEntrada(CorrecaoEntradaDto correcao)
        {
            correcao.userId = CacheMP.Instance.UserCurrent.UserId;
            return entradasService.SetCorrecaoEntrada(correcao);

        }

        public void RemoveConferencia(EntradasViewerDto entradaSelecionado)
        {
            entradasService.RemoveConferencia(entradaSelecionado);
        }

    }
}
