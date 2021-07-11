using System.Collections.Generic;
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
    public async Task<List<Filme>> Get()
    {
        return await _context.Filmes.ToListAsync();
    }

    // GET api/filmes/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Filme>> Get(long id)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
        return Ok(filme);
    }

    // POST api/filmes
    [HttpPost]
    public async Task<ActionResult<Filme>> Post([FromBody] FilmeInputPostDTO inputDTO)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == inputDTO.DiretorId);

        if (diretor == null)
        {
            return NotFound("Diretor informado não encontrado!");
        }


        var filme = new Filme(inputDTO.Titulo);
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
    }

    // PUT api/filmes/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<Filme>> Put(long id, [FromBody] Filme filme)
    {
        filme.Id = id;
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();

        return Ok(filme);
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