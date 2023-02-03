using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVenda.Models
{
    public class ProdutoViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Nome is required")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "Quantidade is required")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Precisa de categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Valor is required")]
        public double Valor { get; set; }

    }
}
