public class DiretorOutputDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public DiretorOutputDTO (long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}