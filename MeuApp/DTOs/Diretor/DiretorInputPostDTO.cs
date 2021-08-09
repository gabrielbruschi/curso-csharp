using FluentValidation;
public class DiretorInputPostDTO
{
    public string Nome { get; set; }
}

public class DiretorInputPostDTOValidator : AbstractValidator<DiretorInputPostDTO>
{
    public DiretorInputPostDTOValidator()
    {
        RuleFor(x => x.Nome)
          .NotEmpty()
          .WithMessage("O nome do diretor é obrigatorio");
    }
}