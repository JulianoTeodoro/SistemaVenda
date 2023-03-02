using Domain.Entidades;
using Repositorio.DAL;
using Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.Repositories
{
    public class VendaProdutosRepository : Repository<VendaProdutos>, IVendaProdutoRepository
    {
        public VendaProdutosRepository(ApplicationDbContext context):base(context) { }

        public List<Grafico> Grafico()
        {
            return _context.VendaProdutos.GroupBy(p => p.ProdutoId)
                                                 .Select(y => new Grafico
                                                 {
                                                     CodigoProduto = y.First().ProdutoId,
                                                     Descricao = y.First().Produto.Nome,
                                                     TotalVendido = y.Sum(z => z.Quantidade)
                                                 }).ToList();
        }
    }
}
