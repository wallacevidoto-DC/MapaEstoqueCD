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
            }
            catch (Exception)
            {

                throw;
            }
                return false;
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
                    p.QtdConferida,
                    p.QtdEntrada,
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

                switch (filtro.Coluna.ToLower())
                {
                    case "EntradaId":
                    case "entradaId":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.EntradaId.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.Tipo, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;
                    case "tipo":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.Tipo?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.Tipo, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;

                    case "usuário":
                    case "usuario":
                    case "usernome":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.UserNome?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.UserNome, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;

                    case "produto.codigo":
                    case "produtocodigo":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.ProdutoCodigo?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.ProdutoCodigo, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;

                    case "produto.descricao":
                    case "produtodescricao":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.ProdutoDescricao?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.ProdutoDescricao, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;

                    case "quantidade conferida":
                    case "qtdconferida":
                        if (int.TryParse(filtro.Valor, out int qtdConf))
                        {
                            entradas = filtro.Tipo switch
                            {
                                "contém" => entradas.Where(e => e.QtdConferida.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                                "igual" => entradas.Where(e => string.Equals(e.ProdutoDescricao, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                                _ => entradas
                            };
                            //entradas = filtro.Tipo switch
                            //{
                            //    "maior" => entradas.Where(e => e.QtdConferida > qtdConf).ToList(),
                            //    "menor" => entradas.Where(e => e.QtdConferida < qtdConf).ToList(),
                            //    "igual" => entradas.Where(e => e.QtdConferida == qtdConf).ToList(),
                            //    _ => entradas
                            //};
                        }
                        break;

                    case "quantidade entrada":
                    case "qtdentrada":
                        if (int.TryParse(filtro.Valor, out int qtdEnt))
                        {
                            entradas = filtro.Tipo switch
                            {
                                "contém" => entradas.Where(e => e.QtdEntrada.ToString().Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                                "igual" => entradas.Where(e => string.Equals(e.ProdutoDescricao, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                                _ => entradas
                            };
                            //entradas = filtro.Tipo switch
                            //{
                            //    "maior" => entradas.Where(e => e.QtdEntrada > qtdEnt).ToList(),
                            //    "menor" => entradas.Where(e => e.QtdEntrada < qtdEnt).ToList(),
                            //    "igual" => entradas.Where(e => e.QtdEntrada == qtdEnt).ToList(),
                            //    _ => entradas
                            //};
                        }
                        break;

                    case "cifs":
                    case "cifsnome":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.CifsNome?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.CifsNome, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;

                    case "lote":
                        entradas = filtro.Tipo switch
                        {
                            "contém" => entradas.Where(e => e.Lote?.Contains(filtro.Valor, StringComparison.OrdinalIgnoreCase) == true).ToList(),
                            "igual" => entradas.Where(e => string.Equals(e.Lote, filtro.Valor, StringComparison.OrdinalIgnoreCase)).ToList(),
                            _ => entradas
                        };
                        break;

                    case "dataf":
                        if (DateTime.TryParse(filtro.Valor, out DateTime dataF))
                        {
                            entradas = entradas.Where(e => Convert.ToDateTime(e.DataF) == dataF.Date).ToList();
                        }
                        break;

                    case "semf":
                        if (int.TryParse(filtro.Valor, out int semF))
                            entradas = entradas.Where(e => e.SemF == semF).ToList();
                        break;

                    case "createat":
                    case "data criação":
                    case "datadecriação":
                        if (DateTime.TryParse(filtro.Valor, out DateTime created))
                        {
                            entradas = entradas.Where(e => e.CreateAt?.Date == created.Date).ToList();
                        }
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
                    p.QtdConferida,
                    p.QtdEntrada,
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
