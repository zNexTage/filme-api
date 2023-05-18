using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo logradouro é obrigatório")]
    [MaxLength(100, ErrorMessage = "O logradouro deve ter no máximo 100 caracteres")]
    public string Logradouro { get; set; }
    public int Numero { get; set; }

    public virtual Cinema Cinema {get;set;}
}
