public class FilmeOutputGetByIdDTO
{
    public long Id { get; private set; }
    public string Titulo { get; private set; }

    public FilmeOutputGetByIdDTO(long id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}