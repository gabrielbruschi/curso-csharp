public class FilmeOutputPutDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public FilmeOutputPutDTO(long id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}