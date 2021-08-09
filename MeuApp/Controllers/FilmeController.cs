using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Authorize]
[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly IFilmeService _filmeService;

    public FilmeController(IFilmeService FilmeService)
    {
        _filmeService = FilmeService;
    }

    /// <summary>
    /// O método Get retorna uma lista de todos os filmes do banco.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET/filme
    ///     {
    ///        "id": 1,
    ///        "titulo": "Filme Um",
    ///        "ano": null
    ///     },
    ///     {
    ///        "id": 2,
    ///        "titulo": "Filme Dois",
    ///        "ano": null
    ///     } 
    ///       
    /// </remarks>
    /// <returns>Todos os filmes já cadastrados no banco</returns>
    /// <response code="200">Filmes listados com sucesso</response>
    [HttpGet]
    public async Task<ActionResult<FilmeListOutputGetAllDTO>> Get(CancellationToken cancellationToken, int limit = 5, int page = 1)
    {
        return await _filmeService.GetByPageAsync(limit, page, cancellationToken);
    }

    /// <summary>
    /// O método Get retorna um registro do filme de acordo com o parâmetro id informado.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET/filme/id
    ///     {
    ///        "id": 2,
    ///        "titulo": "Filme Dois",
    ///        "nomeDoDiretor": "Tom Cavalts"
    ///     } 
    ///       
    /// </remarks>
    /// <param name="id">Id do filme</param>
    /// <returns>Registro do filme informado como parâmetro</returns>
    /// <response code="200">Filme localizado sucesso</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<FilmeOutputGetByIdDTO>> Get(long id)
    {
        var filme = await _filmeService.GetById(id);

        var outputDTO = new FilmeOutputGetByIdDTO(filme.Id, filme.Titulo, filme.Diretor.Nome);
        return Ok(outputDTO);
    }

    /// <summary>
    /// Cria um Filme
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /filmes
    ///     {
    ///        "nome": "O jogo da Vida"
    ///     }
    ///
    /// </remarks>
    /// <param name="inputDTO">Nome do Filme</param>
    /// <returns>O filme criado</returns>
    /// <response code="200">O filme foi criado com sucesso</response>
    [HttpPost]
    public async Task<ActionResult<FilmeOutputPostDTO>> Post([FromBody] FilmeInputPostDTO inputDTO)
    {
        var filme = await _filmeService.Add(new Filme(inputDTO.Titulo, inputDTO.DiretorId, inputDTO.Ano));

        var outputDTO = new FilmeOutputPostDTO(filme.Id, filme.Titulo, filme.Ano);

        return Ok(outputDTO);
    }

    /// <summary>
    /// O método Put atualiza o id do filme, titulo e id do diretor no banco de acordo com o id informado.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT/filme/id
    ///     {
    ///        "id": 2,
    ///        "titulo": "O jogo da vida",
    ///        "ano": "2014"
    ///     } 
    ///       
    /// </remarks>
    /// <param name="id">Id do filme</param>
    /// <param name="inputDTO">Titulo do filme</param>
    /// <returns>O filme atualizado no banco</returns>
    /// <response code="200">Filme atualizado com sucesso</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<FilmeOutputPutDTO>> Put(long id, [FromBody] FilmeInputPutDTO inputDTO)
    {
        var filme = new Filme(inputDTO.Titulo, inputDTO.DiretorId, inputDTO.Ano);

        await _filmeService.Update(filme, filme.Id);

        var outputDTO = new FilmeOutputPutDTO(filme.Id, filme.Titulo);
        return Ok(outputDTO);
    }


    /// <summary>
    /// O método Delete remove um filme no banco de acordo com o id informado.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE/filme/id
    ///     {
    ///        "id": 2,
    ///        "titulo": "O jogo da vida",
    ///        "ano": null
    ///     } 
    ///       
    /// </remarks>
    /// <param name="id">Id do filme</param>
    /// <returns>O filme excluido</returns>
    /// <response code="200">Filme removido com sucesso</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _filmeService.Delete(id);
        return Ok();
    }
}