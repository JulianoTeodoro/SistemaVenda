using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome is required")]
        [MinLength(1)]
        [MaxLength(80)]
        public string Nome { get; set; }

    }
}
