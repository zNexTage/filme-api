using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme { 
    [Key]   
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O título do filme é obrigatório")]
    [MaxLength(80, ErrorMessage ="O título do filme deve ter no máximo 30 caracteres")]
    public string Titulo {get;set;}
    //MaxLength -> Define o tamanho da string no banco de dados; 
    
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    
    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
    
    [Required(ErrorMessage = "A sinopse do filme é obrigatório")]
    public string Sinopse { get;set; }

    public virtual ICollection<Sessao> Sessoes { get; set; }
}