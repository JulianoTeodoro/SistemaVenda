using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Servicos
{
    public class CategoriaService : ICategoriaService
    {
        public void Cadastrar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public Categoria CarregarCategoria(int? id)
        {
            throw new NotImplementedException();
        }

        public void Excluir(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Categoria> Listagem()
        {
            List<Categoria> lista = new List<Categoria>();

            return lista;
        }
    }
}
