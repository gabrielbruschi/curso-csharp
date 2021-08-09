public class FilmeOutPutGetAllDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }

    public FilmeOutPutGetAllDTO(long id, string titulo)
    {
        Id = id;
        Titulo = titulo;
    }
}