public class Filme
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public string Ano { get; set; }
    public long DiretorId { get; set; }
    public Diretor Diretor { get; set; }

    public Filme(string titulo, long diretorId, string ano)
    {
        this.Titulo = titulo;
        DiretorId = diretorId;
        this.Ano = ano;
    }
}