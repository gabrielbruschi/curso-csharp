using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DiretorController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET api/diretores
    [HttpGet]
    public async Task<ActionResult<List<DiretorOutputGetAllDTO>>> Get()
    {
        var diretores = await _context.Diretores.ToListAsync();

        if (!diretores.Any())
        {
            return NotFound("Não existem diretores cadastrados!");
        }

        var outputDTOList = new List<DiretorOutputGetAllDTO>();

        foreach (Diretor diretor in diretores)
        {
            outputDTOList.Add(new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome));
        }

        return outputDTOList;
    }

    // GET api/diretores/1
    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> Get(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);

        if (diretor == null)
        {
            return NotFound("Diretor não encontrado!");
        }

        var outputDto = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);
        return Ok(outputDto);
    }

    // POST api/diretores
    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputDto)
    {
        /// <summary>
        /// Cria um diretor
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /diretor
        ///     {
        ///        "nome": "Martin Scorsese",
        ///     }
        ///
        /// </remarks>
        /// <param name="nome">Nome do diretor</param>
        /// <returns>O diretor criado</returns>
        /// <response code="200">Diretor foi criado com sucesso</response>

        var diretor = new Diretor(diretorInputDto.Nome);
        _context.Diretores.Add(diretor);

        await _context.SaveChangesAsync();

        var diretorOutputDto = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }

    // PUT api/diretores/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOuputPutDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputDto)
    {
        var diretor = new Diretor(diretorInputDto.Nome);
        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputDto = new DiretorOuputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }

    // DELETE api/diretores/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        _context.Remove(diretor);
        await _context.SaveChangesAsync();
        return Ok();
    }
}