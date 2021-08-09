using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IFilmeService
{
    Task<FilmeListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    Task<Filme> GetById(long id);
    Task<Filme> Add(Filme filme);
    Task<Diretor> GetDiretorId(long id);
    Task<Filme> Update(Filme filme, long id);
    Task<Filme> Delete(long id);

}