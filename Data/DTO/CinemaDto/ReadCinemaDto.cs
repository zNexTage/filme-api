using System;

namespace FilmesAPI.Data.DTO.CinemaDto;

public class ReadCinemaDto
{
    public int Id { get; set; }
 
    public string Nome { get; set; }   

    public ReadEnderecoDto Endereco { get; set; }     
}