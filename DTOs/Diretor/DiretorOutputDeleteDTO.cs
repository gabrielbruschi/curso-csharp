public class DiretorOutputDeleteDTO
{
    long Id  { get; set; }
    string Nome { get; set; }

    public DiretorOutputDeleteDTO(string nome)
    {
        Nome = nome;
    }

}