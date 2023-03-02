using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entidades
{
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataVenda { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public double ValorTotal { get; set; }

        [Required]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public ICollection<VendaProdutos> Produtos { get; set; }



    }
}
