using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class FilmeService : IFilmeService
{
    private readonly ApplicationDbContext _context;
    public FilmeService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Filme> Add(Filme filme)
    {
        _context.Filmes.Add(filme);
        await _context.SaveChangesAsync();
        return filme;
    }

    public async Task<Diretor> GetDiretorId(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        return diretor;
    }

    public async Task<Filme> Delete(long id)
    {
        var filme = await _context.Filmes.FirstOrDefaultAsync(filme => filme.Id == id);
        _context.Remove(filme);
        await _context.SaveChangesAsync();
        return filme;
    }

    public async Task<List<Filme>> GetAll()
    {
        var filmes = await _context.Filmes.ToListAsync();
        return filmes;
    }

    public async Task<Filme> GetById(long id)
    {
        var filme = await _context.Filmes.Include(filme => filme.Diretor).FirstOrDefaultAsync(filme => filme.Id == id);
        return filme;
    }

    public async Task<Filme> Update(Filme filme)
    {
        _context.Filmes.Update(filme);
        await _context.SaveChangesAsync();
        return filme;
    }
}