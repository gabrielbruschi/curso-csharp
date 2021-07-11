public class Filme
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public Diretor Diretor { get; set; }

    public Filme(string titulo, long diretorId)
    {
        Titulo = titulo;
        DiretorId = diretorId;
    }
}