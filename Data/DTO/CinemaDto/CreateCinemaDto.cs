using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.CinemaDto;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe o endereço do cinema")]
    public int EnderecoId {get;set;}
}