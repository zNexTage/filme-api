using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.CinemaDto;

public class UpdateCinemaDto
{
    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }        
}