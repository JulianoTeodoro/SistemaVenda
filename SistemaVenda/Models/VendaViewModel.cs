using Domain.Entidades;
using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class VendaViewModel
    {

        public int Id { get; set; }

        public DateTime? DataVenda { get; set; }

        [Required(ErrorMessage = "Precisa de valor total")]
        public double ValorTotal { get; set; }


        [Required(ErrorMessage = "Precisa de cliente")]
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        public string JsonProdutos { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }

    }
}
