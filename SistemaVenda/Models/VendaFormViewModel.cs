using Microsoft.AspNetCore.Mvc.Rendering;
using Domain.Entidades;

namespace SistemaVenda.Models
{
    public class VendaFormViewModel
    {

        public VendaViewModel Venda { get; set; }
        public IEnumerable<ClienteViewModel> ListaClientes { get; set; }
        public IEnumerable<ProdutoViewModel> ListaProdutos { get; set; }
    }
}
