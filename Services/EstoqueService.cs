using MapaEstoqueCD.Controller;
using MapaEstoqueCD.Database.Dto.Ws;
using MapaEstoqueCD.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                 .Include(x => x.Endereco)
                .Select(e => new EstoqueWsDto
                {
                    enderecoId = $"{e.Endereco.Rua}{e.Endereco.Coluna}{e.Endereco.Palete}",
                    produtoId = e.ProdutoId,
                    semF = e.SemF,
                    quantidade = e.Quantidade,
                    dataF = e.DataF,
                    dataL = e.DataL,
                    lote = e.Lote,
                    obs = e.Obs,
                    createAt = e.CreateAt,
                    updateAt = e.UpdateAt,
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
