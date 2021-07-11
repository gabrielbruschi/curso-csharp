public class FilmeOutputGetAllDTO
{
    public long Id { get; private set; }
    public string Titulo { get; private set; }

    public FilmeOutputGetAllDTO(long id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}