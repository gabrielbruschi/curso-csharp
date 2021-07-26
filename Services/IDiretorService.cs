using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IDiretorService
{
    Task<DiretorListOutputGetAllDTO> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    Task<Diretor> GetById(long id);
    Task<Diretor> Add(Diretor diretor);
    Task<Diretor> Update(Diretor diretor, long id);
    Task<Diretor> Delete(long id);


}