using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaVenda.Entidades
{
    public class Produto
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(1)]
        [MaxLength(80)]
        public string Nome { get; set; }

        [StringLength(100)]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "Quantidade is required")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Precisa de categoria")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Valor is required")]
        [Column(TypeName = "decimal(10,2)")]
        public double Valor { get; set; }

        public ICollection<VendaProdutos> Vendas { get; set; }

    }
}
