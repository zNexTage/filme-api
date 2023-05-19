using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.DTO.SessaoDto;

public class CreateSessaoDto
{
    [Required]
    public int FilmeId { get; set; }

    [Required]
    public int CinemaId { get; set; }
}
