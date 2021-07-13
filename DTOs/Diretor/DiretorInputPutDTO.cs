using FluentValidation;
public class DiretorInputPutDTO
{
    public string Nome { get; set; }
}

public class DiretorInputPutDTOValidator : AbstractValidator<DiretorInputPutDTO>
{
    public DiretorInputPutDTOValidator()
    {
        //RuleFor(diretor => diretor.Nome)
    }
}