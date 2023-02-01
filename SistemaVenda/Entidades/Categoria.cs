using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Entidades
{
    public class Categoria
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome is required")]
        [MinLength(1)]
        [MaxLength(80)]
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Categoria()
        {
            Produtos = new List<Produto>();
        }
    }
}
