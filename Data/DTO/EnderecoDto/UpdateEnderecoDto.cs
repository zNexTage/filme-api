using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.EnderecoDto;

public class UpdateEnderecoDto
{
    [Required(ErrorMessage = "O campo logradouro é obrigatório")]
    [StringLength(100, ErrorMessage = "O logradouro deve ter no máximo 100 caracteres")]
    public string Logradouro { get; set; }
    public int Numero { get; set; }
}
