using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data;

public class UpdateFilmeDTO {
    // Aqui usamos StringLength em vez do MaxLength;
    // StringLength é mais semântico para esse caso e não realiza alocação de memória dentro do banco.
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    [StringLength(80, ErrorMessage ="O título do filme deve ter no máximo 30 caracteres")]
    public string Titulo {get;set;}
    
    [Required(ErrorMessage = "O gênero do filme é obrigatório")]
    [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres")]
    public string Genero { get; set; }
    
    [Required(ErrorMessage = "A duração do filme é obrigatória")]
    [Range(70, 600, ErrorMessage = "A duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
    
    [Required(ErrorMessage = "A sinopse do filme é obrigatório")]
    public string Sinopse { get;set; }
}

