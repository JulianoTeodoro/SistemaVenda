using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVenda.Entidades
{
    public class VendaProdutos
    {


        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Precisa ser id para venda")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "Precisa de id para produto")]
        public int ProdutoId { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Precisa ser 1 ou mais")]
        public int Quantidade { get; set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double ValorUnitario { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double ValorTotal { get; set; }
    }
}
