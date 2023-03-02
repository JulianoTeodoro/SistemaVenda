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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationDbContext context):base(context) { }
        public double LerValorProduto(int id)
        {
            return _context.Produtos.Where(p => p.Id == id).Select(p => p.Valor).FirstOrDefault();
        }
    }
}
