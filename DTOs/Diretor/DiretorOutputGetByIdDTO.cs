using System;
public class DiretorOutputGetByIdDTO
{
    public long Id { get; set; }
    public string Nome { get; set; }
    public DiretorOutputGetByIdDTO(long id, string nome )
    {
        if (nome == null)
        {
            throw new ArgumentNullException("Nome não informado");
        }
        
        Id = id;
        Nome = nome;
    }
}