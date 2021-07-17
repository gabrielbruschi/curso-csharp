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
    private readonly IDiretorService _DiretorService;

    public DiretorController(IDiretorService DiretorService)
    {
        _DiretorService = DiretorService;
    }

    // GET api/diretores
    [HttpGet]
    public async Task<ActionResult<List<DiretorOutputGetAllDTO>>> Get()
    {
        var diretores = await _DiretorService.GetAll();

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
        var diretor = await _DiretorService.GetById(id);

        if (diretor == null)
        {
            return NotFound("Diretor não encontrado!");
        }

        var outputDto = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);
        return Ok(outputDto);
    }

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
    /// <param name="diretorInputDto">Nome do diretor</param>
    /// <returns>O diretor criado</returns>
    /// <response code="200">Diretor foi criado com sucesso</response>
    /// <response code="400">Bad Request</response>
    /// <response code="404">Not Found</response>
    /// <response code="500">Erro interno inesperado</response>
    /// 
    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputDto)
    {
        var diretor = new Diretor(diretorInputDto.Nome);
        await _DiretorService.Add(diretor);

        var diretorOutputDto = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }


    // PUT api/diretores/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOuputPutDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputDto)
    {
        var diretor = new Diretor(diretorInputDto.Nome);
        diretor.Id = id;
        await _DiretorService.Update(diretor);

        var diretorOutputDto = new DiretorOuputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }

    // DELETE api/diretores/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _DiretorService.Delete(id);
        return Ok();
    }

}