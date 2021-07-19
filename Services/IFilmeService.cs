using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFilmeService
{
    Task<List<Filme>> GetAll();
    Task<Filme> GetById(long id);
    Task<Filme> Add(Filme filme);
    Task<Diretor> GetDiretorId(long id);
    Task<Filme> Update(Filme filme);
    Task<Filme> Delete(long id);

}