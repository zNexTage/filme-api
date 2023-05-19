using System;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Sessao
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int FilmeId { get; set; }

    public virtual Filme Filme { get; set; }
    

    public int? CinemaId { get; set; } /* Definimos como nullable, para solucionar o erro:
    Cannot add or update a child row: a foreign key constraint fails (`filme`.`#sql-541_c`, CONSTRAINT `FK_Sessoes_Cinemas_CinemaId` FOREIGN KEY (`CinemaId`) REFERENCES `Cinemas` (`Id`) ON DELETE CASCADE)

    ao rodar a migration!! Esse erro ocorreu, pois, durante a execução da migration, foi adicionado a coluna CinemaId
    com Id zero, e não há nenhum Cinema cadastro em nosso DB com Id zero.
    
     */
    public virtual Cinema Cinema { get; set; }

}
