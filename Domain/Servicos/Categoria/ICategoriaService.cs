using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entidades;

namespace Domain.Servicos
{
    public interface ICategoriaService
    {
        IEnumerable<Categoria> Listagem();

        void Cadastrar(Categoria categoria);
        Categoria CarregarCategoria(int? id);
        void Excluir(int id);




    }
}
