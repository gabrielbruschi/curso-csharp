using FluentValidation;
public class DiretorInputPutDTO
{
    public string Nome { get; set; }
}

public class DiretorInputPutDTOValidator : AbstractValidator<DiretorInputPutDTO>
{
    public DiretorInputPutDTOValidator()
    {
        RuleFor(diretor => diretor.Nome).NotNull().NotEmpty();
        RuleFor(diretor => diretor.Nome).Length(2, 40).WithMessage("Tamanho {TotalLength} inválido");
    }
}