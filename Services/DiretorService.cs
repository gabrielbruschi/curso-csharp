using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;

public class DiretorService : IDiretorService
{
    private readonly ApplicationDbContext _context;
    public DiretorService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Diretor> Add(Diretor diretor)
    {
        _context.Diretores.Add(diretor);
        await _context.SaveChangesAsync();
        return diretor;
    }

    public async Task<Diretor> Delete(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        _context.Remove(diretor);
        await _context.SaveChangesAsync();
        return diretor;
    }

    public async Task<DiretorListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
    {
        var pagedModel = await _context.Diretores
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .PaginateAsync(page, limit, cancellationToken);

        if (!pagedModel.Items.Any())
        {
            throw new Exception("Não existem diretores cadastrados!");
        }

        var CurrentPage = pagedModel.CurrentPage;
        var TotalPages = pagedModel.TotalPages;
        var TotalItems = pagedModel.TotalItems;
        var Items = pagedModel.Items.Select(diretor => new DiretorOutputGetAllDTO(diretor.Id, diretor.Nome)).ToList();

        DiretorListOutputGetAllDTO listOutputGetAllDTO = new DiretorListOutputGetAllDTO(CurrentPage, TotalPages, TotalItems, Items);

        return listOutputGetAllDTO;
    }

    public async Task<Diretor> GetById(long id)
    {
        var diretor = await _context.Diretores.FirstOrDefaultAsync(diretor => diretor.Id == id);
        return diretor;
    }

    public async Task<Diretor> Update(Diretor diretor)
    {
        _context.Diretores.Update(diretor);
        await _context.SaveChangesAsync();
        return diretor;
    }
}