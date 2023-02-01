using System.ComponentModel.DataAnnotations;

namespace SistemaVenda.Models
{
    public class ClienteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Minimo de 2 caracteres")]
        [StringLength(80, ErrorMessage = "Maximo de 80 caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "CPF/CNPJ é obrigatório")]
        [StringLength(14)]
        public string CNPJ_CPF { get; set; }

        [Required(ErrorMessage = "Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }


    }
}
