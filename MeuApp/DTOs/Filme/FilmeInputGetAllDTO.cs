public class FilmeOutputGetAllDTO
{
    public long Id { get; private set; }
    public string Titulo { get; private set; }
    public string Ano { get; private set; }

    public FilmeOutputGetAllDTO(long id, string titulo, string ano)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
    }
}