public class FilmeOutputGetByIdDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string NomeDoDiretor { get; set; }

    public FilmeOutputGetByIdDTO(long id, string titulo, string nomeDoDiretor)
    {
        Id = id;
        Titulo = titulo;
        NomeDoDiretor = nomeDoDiretor;
    }
}