using System.Collections.Generic;
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

    [HttpGet]
    public async Task<List<DiretorOutputGetAllDTO>> Get()
    {
        var diretores = await _context.Diretores.ToListAsync();
        var outputDTOList = new List<DiretorOutputGetAllDTO>();

        foreach (Diretor diretor in diretores)
        {
            outputDTOList.Add(new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome));
        }

        return outputDTOList;
    }

    //GET api/diretores/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<DiretorOutputGetByIdDTO>> Get(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        var outputDto = new DiretorOutputGetByIdDTO(diretor.Id, diretor.Nome);

        return Ok(outputDto);
    }

    //POST api/diretores/
    [HttpPost]
    public async Task<ActionResult<DiretorOutputPostDTO>> Post([FromBody] DiretorInputPostDTO diretorInputPostDto)
    {
        var diretor = new Diretor(diretorInputPostDto.Nome);
        if (diretor.Nome == null || diretor.Nome == "")
        {
            return Conflict("O diretor não pode ser vazio!");
        }
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputPostDto = new DiretorOutputPostDTO(diretor.Id, diretor.Nome);

        return Ok(diretorOutputPostDto);
    }

    // Put api/diretores/{id}
    [HttpPut("{id}")] // atualizar
    public async Task<ActionResult<DiretorOutputPutDTO>> Put(long id, [FromBody] DiretorInputPutDTO diretorInputPutDto)
    {
        var diretor = new Diretor(diretorInputPutDto.Nome);
        diretor.Id = id;
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        var diretorOutputPutDto = new DiretorOutputPutDTO(diretor.Nome);
        return Ok(diretorOutputPutDto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }
}