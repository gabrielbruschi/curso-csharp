using FluentValidation;
public class FilmeInputPutDTO
{
    public long Id { get; set; }
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPutDTO(long id, string titulo, long diretorId)
    {
        Id = id;
        Titulo = titulo;
        DiretorId = diretorId;
    }
}

public class FilmeInputPutDTOValidator : AbstractValidator<FilmeInputPutDTO>
{
    public FilmeInputPutDTOValidator()
    {
        RuleFor(filme => filme.Id).NotNull();
        RuleFor(filme => filme.Titulo).NotNull();
        RuleFor(filme => filme.Titulo).Length(2, 250).WithMessage("Tamanho {TotalLength} inválido");
        RuleFor(filme => filme.DiretorId).NotNull();
    }
}