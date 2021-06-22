public class DiretorOutputPostDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }

    public DiretorOutputPostDTO(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}