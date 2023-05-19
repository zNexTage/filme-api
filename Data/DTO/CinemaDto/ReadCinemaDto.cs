using System;
using FilmesAPI.Data.DTO.SessaoDto;

namespace FilmesAPI.Data.DTO.CinemaDto;

public class ReadCinemaDto
{
    public int Id { get; set; }
 
    public string Nome { get; set; }   

    public ReadEnderecoDto Endereco { get; set; }     

    public ICollection<ReadSessaoDto> Sessoes {get;set;}
}