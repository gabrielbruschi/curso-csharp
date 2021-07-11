public class DiretorOuputPutDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public DiretorOuputPutDTO(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}