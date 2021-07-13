using FluentValidation;
public class FilmeInputPostDTO
{
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPostDTO(string titulo, long diretorId)
    {
        Titulo = titulo;
        DiretorId = diretorId;
    }
}

public class FilmeInputPostDTOValidator : AbstractValidator<FilmeInputPostDTO>
{
    public FilmeInputPostDTOValidator()
    {
        RuleFor(filme => filme.Titulo).NotNull().NotEmpty();
        RuleFor(filme => filme.Titulo).Length(2, 250).WithMessage("Tamanho {TotalLength} inválido");
        RuleFor(filme => filme.DiretorId).NotNull();
    }
}