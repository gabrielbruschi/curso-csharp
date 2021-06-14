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
    public async Task<List<Diretor>> Get()
    {
        return await _context.Diretores.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Diretor>> Post([FromBody] Diretor diretor)
    {
        if (diretor.Nome == null || diretor.Nome == "")
        {
            return Conflict("O diretor não pode ser vazio!");
        }
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }

    [HttpPut] // atualizar
    public async Task<ActionResult<Diretor>> Put([FromBody] Diretor diretor)
    {
        if (diretor.Nome == null || diretor.Nome == "")
        {
            return Conflict("O diretor não pode ser vazio!");
        }
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }

    [HttpDelete]
    public async Task<ActionResult<Diretor>> Delete([FromBody] Diretor diretor)
    {
        _context.Diretores.Remove(diretor);
        await _context.SaveChangesAsync();

        return Ok(diretor);
    }
}