﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SistemaVenda.Entidades
{
    public class Cliente
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Minimo de 2 caracteres")]
        [StringLength(80, ErrorMessage = "Maximo de 80 caracteres")]
        public string Name { get; set; }

        [Required]
        [StringLength(14)]
        public string CNPJ_CPF { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Celular { get; set; }

        public ICollection<Venda> Compras { get; set; }

        public Cliente()
        {
            Compras = new List<Venda>();
        }

    }
}