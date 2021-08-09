using System;

public class DiretorOutputGetByIdDTO
{
    public long Id { get; private set; }
    public string Nome { get; private set; }

    public DiretorOutputGetByIdDTO(long id, string nome)
    {
        Id = id;
        Nome = nome;
    }
}