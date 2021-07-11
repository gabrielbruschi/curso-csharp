public class DiretorOutputGetAllDTO
{
    public long Id { get; private set; }
    public string Nome { get; private set; }

    public DiretorOutputGetAllDTO(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}