using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.modal;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Services;
using MapaEstoqueCD.WebSocketActive.Dto;
using MapaEstoqueCD.WebSocketActive.Interface;
using System.Net.WebSockets;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MapaEstoqueCD.WebSocketActive
{
    public class GetEstoqueHandler : IActionHandler
    {
        public readonly EstoqueService estoqueService = new();
        public string ActionName => ActionsWs.GET_ESTOQUE;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                List<EstoqueWsDto> estoque = estoqueService.GetAllProd();

                return new WebSocketResponse { type = "estoque", status = "ok", mensagem = "es", dados = estoque };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = $"{ActionsWs.GET_ESTOQUE}_resposta", status = "erro", mensagem = ex.Message };
            }

        }
    }

    public class LoginHandler : IActionHandler
    {
        public readonly UserService userService = new();
        public string ActionName => ActionsWs.LOGIN;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                var user = userService.Login(data.GetProperty("username").GetString(), data.GetProperty("password").GetString());

                if (user != null)
                {
                    //user.Password = null;
                    return new WebSocketResponse { type = "login_resposta", status = "ok", mensagem = "Login realizado com sucesso", dados = user };
                }
                return new WebSocketResponse { type = "login_resposta", status = "erro", mensagem = "Algum dado errado" };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = "login_resposta", status = "erro", mensagem = ex.Message };
            }

        }
    }

    public class EntradaHandler : IActionHandler
    {

        public string ActionName => ActionsWs.ENTRADA;
        public EstoqueService estoqueService = new();


        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };

                EntradaDto entrada = JsonSerializer.Deserialize<EntradaDto>(data.GetRawText(), options);

                if (entrada != null)
                {
                    entrada.observacao = $"(REMOTO) - {entrada.observacao}";
                    if (estoqueService.SetEntrada(entrada))
                    {
                        return new WebSocketResponse { type = "entrada_resposta", status = "ok", mensagem = "Entrada realizado com sucesso", dados = null };
                    }


                }
                return new WebSocketResponse { type = "entrada_resposta", status = "erro", mensagem = "Algum dado errado" };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = "entrada_resposta", status = "erro", mensagem = ex.Message };
            }

        }
    }

    public class EnderecoHandler : IActionHandler
    {
        public string ActionName => ActionsWs.GET_ADDRESS;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                string enderecoId = $"{data.GetProperty("rua")}{data.GetProperty("bloco")}{data.GetProperty("apt")}";

                var produtos = CacheMP.Instance.Db.Estoque
                    .Where(e => e.EnderecoId == enderecoId && e.Produto != null)
                    .Select(e => new
                    {
                        e.Produto.ProdutoId,
                        e.Produto.Codigo,
                        e.Produto.Descricao,
                        e.Produto.Produto,
                        e.DataL,
                        e.DataF,
                        e.SemF,
                        e.Lote,
                        e.Quantidade,
                        e.EstoqueId
                    })
                    .Distinct()
                    .ToList();

                if (produtos.Any())
                {
                    return new WebSocketResponse
                    {
                        type = "get_address_resposta",
                        status = "ok",
                        mensagem = "Produtos encontrados",
                        dados = produtos
                    };
                }

                return new WebSocketResponse
                {
                    type = "get_address_resposta",
                    status = "ok",
                    mensagem = "Nenhum produto encontrado neste endereço"
                };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse
                {
                    type = "get_address_resposta",
                    status = "erro",
                    mensagem = ex.Message
                };
            }
        }


    }

    public class ProdutoHandler : IActionHandler
    {
        public string ActionName => ActionsWs.GET_PRODUTO;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                if (!data.TryGetProperty("codigo", out var codigoProp))
                {
                    return new WebSocketResponse
                    {
                        type = "get_produto_resposta",
                        status = "erro",
                        mensagem = "Campo 'codigo' ausente no JSON"
                    };
                }

                string cod = data.GetProperty("codigo").ToString();
                if (string.IsNullOrWhiteSpace(cod))
                {
                    return new WebSocketResponse
                    {
                        type = "get_produto_resposta",
                        status = "erro",
                        mensagem = "Código vazio"
                    };
                }

                var produto = CacheMP.Instance.Db.Produtos
                    .FirstOrDefault(x => x.Codigo == cod);

                if (produto is null)
                {
                    return new WebSocketResponse
                    {
                        type = "get_produto_resposta",
                        status = "ok",
                        mensagem = "Nenhum produto encontrado com esse código"
                    };
                }

                // 🔹 Mapeia só os campos necessários
                var dto = new ProdutoWsDto
                {

                    ProdutoId = produto.ProdutoId,
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao
                };

                return new WebSocketResponse
                {
                    type = "get_produto_resposta",
                    status = "ok",
                    mensagem = "Produto encontrado",
                    dados = dto
                };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse
                {
                    type = "get_produto_resposta",
                    status = "erro",
                    mensagem = ex.Message
                };
            }
        }


    }

    public class ProdutoEanHandler : IActionHandler
    {
        public string ActionName => ActionsWs.GET_PRODUTO_EAN;

        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                if (!data.TryGetProperty("codigo", out var codigoProp))
                {
                    return new WebSocketResponse
                    {
                        type = "get_produto_cod_resposta",
                        status = "erro",
                        mensagem = "Campo 'codigo' ausente no JSON"
                    };
                }

                string cod = data.GetProperty("codigo").ToString();
                if (string.IsNullOrWhiteSpace(cod))
                {
                    return new WebSocketResponse
                    {
                        type = "get_produto_cod_resposta",
                        status = "erro",
                        mensagem = "Código vazio"
                    };
                }

                var produto = CacheMP.Instance.Db.Produtos
                    .FirstOrDefault(x =>
                        x.UCodigoBarras == cod ||
                        x.DCodigoBarras == cod ||
                        x.CCodigoBarras == cod
                    );


                if (produto is null)
                {
                    return new WebSocketResponse
                    {
                        type = "get_produto_cod_resposta",
                        status = "ok",
                        mensagem = "Nenhum produto encontrado com esse código"
                    };
                }

                var dto = new ProdutoWsDto
                {

                    ProdutoId = produto.ProdutoId,
                    Codigo = produto.Codigo,
                    Descricao = produto.Descricao
                };

                return new WebSocketResponse
                {
                    type = "get_produto_cod_resposta",
                    status = "ok",
                    mensagem = "Produto encontrado",
                    dados = dto
                };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse
                {
                    type = "get_produto_cod_resposta",
                    status = "erro",
                    mensagem = ex.Message
                };
            }
        }


    }

    public class SaidaHandler : IActionHandler
    {

        public string ActionName => ActionsWs.SAIDA;
        public EstoqueService estoqueService = new();


        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };

                SaidaDto saida = JsonSerializer.Deserialize<SaidaDto>(data.GetRawText(), options);

                if (saida != null)
                {
                    saida.observacao = $"(REMOTO) - {saida.observacao}";
                    if (estoqueService.SetSaida(saida))
                    {
                        return new WebSocketResponse { type = "saida_resposta", status = "ok", mensagem = "Saída realizado com sucesso", dados = null };
                    }


                }
                return new WebSocketResponse { type = "saida_resposta", status = "erro", mensagem = "Algum dado errado" };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = "saida_resposta", status = "erro", mensagem = ex.Message };
            }

        }
    }

    public class TransferenciaHandler : IActionHandler
    {

        public string ActionName => ActionsWs.TRANSFERENCIA;
        public EstoqueService estoqueService = new();


        public async Task<WebSocketResponse?> ExecuteAsync(JsonElement data, WebSocket socket)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters = { new JsonStringEnumConverter() }
                };

                TranferenciaDto transferencia = JsonSerializer.Deserialize<TranferenciaDto>(data.GetRawText(), options);

                if (transferencia != null)
                {
                    transferencia.observacao = $"(REMOTO) - {transferencia.observacao}";
                    if (estoqueService.SetTransferencia(transferencia))
                    {
                        return new WebSocketResponse { type = "transferencia_resposta", status = "ok", mensagem = "Tranferência realizado com sucesso", dados = null };
                    }


                }
                return new WebSocketResponse { type = "transferencia_resposta", status = "erro", mensagem = "Algum dado errado" };
            }
            catch (Exception ex)
            {
                return new WebSocketResponse { type = "transferencia_resposta", status = "erro", mensagem = ex.Message,dados= ex.ToString() };
            }

        }
    }

}
