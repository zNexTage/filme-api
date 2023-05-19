using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo nome é obrigatório")]
    public string Nome { get; set; }
    public int EnderecoId { get; set; } // Um cinema precisa ter um endereço.

    public virtual Endereco Endereco { get; set; } // Relacionamento 1 para 1; É necessário fazer o mesmo no modelo Endereco

    public virtual ICollection<Sessao> Sessoes { get; set; }
}