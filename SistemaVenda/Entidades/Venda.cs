using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SistemaVenda.Entidades
{
    public class Venda
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataVenda
        {
            get
            {
                return DataVenda;
            }
            set
            {
                if (value == null)
                {
                    value = DateTime.Now;
                }
            }
        }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double ValorTotal { get; set; }

        [Required]
        [Range(1, double.PositiveInfinity, ErrorMessage = "Precisa ser 1 ou mais")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }
 


    }
}
