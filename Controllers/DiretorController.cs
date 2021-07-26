using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("[controller]")]
public class DiretorController : ControllerBase
{
    private readonly IDiretorService _diretorService;

    public DiretorController(IDiretorService DiretorService)
    {
        _diretorService = DiretorService;
    }


    /// <summary>
    /// O método Get retorna uma lista de todos os diretores do banco.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET/diretor
    ///     {
    ///        "id": 1,
    ///        "nome": "James Cameron"
    ///     },
    ///     {
    ///        "id": 2,
    ///        "nome": "Benito Deltoro"
    ///     } 
    ///       
    /// </remarks>
    /// <returns>Todos os diretores já cadastrados no banco</returns>
    /// <response code="200">Diretores listados com sucesso</response>
    [HttpGet]
    public async Task<ActionResult<DiretorListOutputGetAllDTO>> Get(CancellationToken cancellationToken, int limit = 5, int page = 1)
    {
        return await _diretorService.GetByPageAsync(limit, page, cancellationToken);
    }

    /// <summary>
    /// O método Get retorna um registro do diretor de acordo com o parâmetro id informado.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     GET/diretor/id
    ///     {
    ///        "id": 2,
    ///        "nome": "Benito Deltoro"
    ///     } 
    ///       
    /// </remarks>
    /// <param name="id">Id do diretor</param>
    /// <returns>Registro do diretor informado como parâmetro</returns>
    /// <response code="200">Diretor localizado sucesso</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> Get(long id)
    {
        var diretor = await _diretorService.GetById(id);

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
        var diretor = await _diretorService.Add(new Diretor(diretorInputDto.Nome));

        var diretorOutputDto = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);
    }


    /// <summary>
    /// O método Put atualiza o nome do diretor no banco de acordo com o id informado.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     PUT/diretor/id
    ///     {
    ///        "id": 5,
    ///        "nome": "Bernardo Bertolucci Atualizado"
    ///     } 
    ///       
    /// </remarks>
    /// <param name="diretorInputDto">Nome do diretor</param>
    /// <param name="id">Id do diretor</param>
    /// <returns>O diretor atualizado no banco</returns>
    /// <response code="200">Diretor atualizado com sucesso</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<DiretorOuputPutDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputDto)
    {
        var diretor = await _diretorService.Update(new Diretor(diretorInputDto.Nome), id);

        var diretorOutputDto = new DiretorOuputPutDTO(diretor.Id, diretor.Nome);
        return Ok(diretorOutputDto);

    }

    /// <summary>
    /// O método Delete remove um diretor no banco de acordo com o id informado.
    /// </summary>
    /// <remarks>
    /// Sample request:
    ///
    ///     DELETE/diretor/id
    ///     {
    ///        "id": 7,
    ///        "nome": "Michael Mann",
    ///        "filmes": []
    ///     } 
    ///       
    /// </remarks>
    /// <param name="id">Id do diretor</param>
    /// <returns>O diretor excluido</returns>
    /// <response code="200">Diretor removido com sucesso</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        await _diretorService.Delete(id);
        return Ok();
    }

}