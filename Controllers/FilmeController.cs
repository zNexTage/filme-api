using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase {

    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(201)]
    public IActionResult Adicionar([FromBody]CreateFilmeDTO filmeDto){
        Filme filme = _mapper.Map<Filme>(filmeDto);

        _context.Filmes.Add(filme);
        _context.SaveChanges();

        /*
        new { id = filme.Id} -> Parâmetros do método ObterFilme.

        Esse método define um cabeçalho chamado location; o location é a URL onde podemos
        consultar as informações do item criado. 
        location	https://localhost:7013/Filme/1        
        */
        return CreatedAtAction(nameof(ObterFilme), new { id = filme.Id }, filme );
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDTO> ObterFilmes(
        [FromQuery]int skip = 0,
        [FromQuery]int take = 50,
        [FromQuery] string? nomeCinema = null
        ){
            if(string.IsNullOrEmpty(nomeCinema)){
                /*Não usamos 404 aqui, pois essa requisição devolve uma lista de filmes, e não uma busca. */
                return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes.Skip(skip).Take(take).ToList());
            }

            return _mapper.Map<List<ReadFilmeDTO>>(_context.Filmes
            .Skip(skip)
            .Take(take)
            .Where(filme => filme.Sessoes.Any(sessao => sessao.Cinema.Nome == nomeCinema))
            .ToList());
        
    }

    [HttpGet("{id}")] //recebe o id via parâmetro
    public IActionResult ObterFilme(int id){
        var filme= _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if(filme == null){
            return this.NotFound();
        }

        var filmeDto = _mapper.Map<ReadFilmeDTO>(filme);

        return this.Ok(filmeDto);
    }

    [HttpPut("{id}")] 
    public IActionResult AtualizarFilme(int id, [FromBody]UpdateFilmeDTO filmeDto){
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if(filme == null) return NotFound();

        _mapper.Map(filmeDto, filme);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizarFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDTO> patch){
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if(filme == null) return NotFound();

        var filmeAtualizar = _mapper.Map<UpdateFilmeDTO>(filme);

        patch.ApplyTo(filmeAtualizar, ModelState);

        if(!TryValidateModel(filmeAtualizar)){
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeAtualizar, filme);

        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult RemoverFilme(int id){
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

        if(filme == null) return NotFound();

        _context.Remove(filme);

        _context.SaveChanges();

        return NoContent();
    }
}