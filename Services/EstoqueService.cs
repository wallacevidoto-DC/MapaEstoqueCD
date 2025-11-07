using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace MapaEstoqueCD.Services
{
    public class EstoqueService
    {
        public EstoqueService()
        {

        }
        public List<Estoque> GetAll()
        {
            return CacheMP.Instance.Db.Estoque.ToList();
        }


        public List<EstoqueWsDto> GetAllProd()
        {
            return CacheMP.Instance.Db.Estoque
                .Include(e => e.Produto)
                .Include(e => e.Endereco)
                .AsEnumerable() 
                .Select(e => new EstoqueWsDto
                {
                    estoqueId = e.EstoqueId,
                    enderecoId = e.EnderecoId ?? $"{e.Endereco?.Rua}{e.Endereco?.Coluna}{e.Endereco?.Palete}",
                    produtoId = e.ProdutoId ?? 0,
                    semF = e.SemF ?? 0,
                    quantidade = e.Quantidade ?? 0,
                    dataF = e.DataF,
                    dataL = (e.DataL ?? DateTime.MinValue).Date,
                    lote = e.Lote,
                    obs = e.Obs,
                    createAt = e.CreateAt ?? DateTime.MinValue,
                    updateAt = e.UpdateAt ?? DateTime.MinValue,
                    produto = e.Produto == null ? null : new ProdutoWsDto
                    {
                        codigo = e.Produto.Codigo,
                        descricao = e.Produto.Descricao
                    }
                })
                .ToList();
        }


    }
}
