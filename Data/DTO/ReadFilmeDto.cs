namespace FilmesAPI.Data;

public class ReadFilmeDTO {
    public int Id { get; set; }
    public string Titulo {get;set;}
    public string Genero { get; set; }
    public int Duracao { get; set; }
    public string Sinopse { get;set; }

    public DateTime HoraDaConsulta { get;set; } = DateTime.Now;
}