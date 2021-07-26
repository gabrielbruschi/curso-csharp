public class FilmeOutputPostDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Ano { get; set; }
    public FilmeOutputPostDTO(long id, string titulo, string ano)
    {
        Id = id;
        Titulo = titulo;
        Ano = ano;
    }
}