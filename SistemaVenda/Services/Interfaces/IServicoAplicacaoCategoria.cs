using SistemaVenda.Models;

namespace Application.Services.Interfaces
{
    public interface IServicoAplicacaoCategoria
    {
        IEnumerable<CategoriaViewModel> Listagem();


    }
}
