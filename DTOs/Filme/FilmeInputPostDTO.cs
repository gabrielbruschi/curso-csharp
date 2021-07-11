public class FilmeInputPostDTO
{
    public string Titulo { get; private set; }
    public long DiretorId { get; private set; }

    public FilmeInputPostDTO(string titulo, long diretorId)
    {
        Titulo = titulo;
        DiretorId = diretorId;
    }
}