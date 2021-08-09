using System.Collections.Generic;

public class Diretor
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public ICollection<Filme> Filmes { get; set; }

    public Diretor(string nome)
    {
        Nome = nome;
        Filmes = new List<Filme>();
    }
}