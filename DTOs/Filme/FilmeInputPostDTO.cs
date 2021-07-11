public class FilmeInputPostDTO {
    public string Titulo { get; set; }
    public long DiretorId { get; set; }
    public FilmeInputPostDTO(string titulo, long diretorId) {
        Titulo = titulo;
        DiretorId = diretorId;
    }
}