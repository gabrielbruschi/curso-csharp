using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public FilmeController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET api/filmes
    [HttpGet]
    public async Task<ActionResult<List<FilmeOutPutGetAllDTO>>> Get()
    {
        var filmes = await _context.Filmes.ToListAsync();

        if (!filmes.Any())
        {
            return NotFound("Não existem diretores cadastrados!");
        }

        var outputDTOList = new List<FilmeOutPutGetAllDTO>();

        foreach (Filme filme in filmes)
        {
            outputDTOList.Add(new FilmeOutPutGetAllDTO(filme.Id, filme.Titulo));
        }

        return outputDTOList;
    }

    // GET api/filmes/1
    [HttpGet("{id}")]
    public async Task<ActionResult<FilmeOutputGetByIdDTO>> Get(long id)
    {
        var filme = await _context.Filmes.Include(filme => filme.Diretor).FirstOrDefaultAsync(filme => filme.Id == id);

        if (filme == null)
        {
            throw new ArgumentNullException("Filme não encontrado!");
        }

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
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == inputDTO.DiretorId);

        if (diretor == null)
        {
            return NotFound("Diretor informado não encontrado!");
        }

        var filme = new Filme(inputDTO.Titulo, diretor.Id);
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        var outputDTO = new FilmeOutputPostDTO(filme.Id, filme.Titulo);


        return Ok(outputDTO);
    }

    // PUT api/filmes/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<FilmeOutputPutDTO>> Put(long id, [FromBody] FilmeInputPutDTO inputDTO)
    {
        var filme = new Filme(inputDTO.Titulo, inputDTO.DiretorId);

        if (inputDTO.DiretorId == 0)
        {
            return NotFound("Id do diretor é inválido!");
        }

        filme.Id = id;
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        var outputDTO = new FilmeOutputPutDTO(filme.Id, filme.Titulo);
        return Ok(outputDTO);
    }

    // DELETE api/filmes/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
        _context.Remove(filme);
        await _context.SaveChangesAsync();
        return Ok(filme);
    }
}