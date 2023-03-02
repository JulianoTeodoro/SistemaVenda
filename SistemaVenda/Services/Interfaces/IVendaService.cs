using Domain.Entidades;
using SistemaVenda.Models;

namespace Application.Services.Interfaces
{
    public interface IVendaService
    {

        VendaFormViewModel Form();
        double LerValorProduto(int id);

        VendaViewModel Criacao(VendaFormViewModel vendaFormView);


    }
}
