using System.Collections.Generic;
public class FilmeListOutputGetAllDTO
{
    public FilmeListOutputGetAllDTO(int currentpage, int totalitems, int totalpages, List<FilmeOutputGetAllDTO> items)
    {
        CurrentPage = currentpage;
        TotalItems = totalitems;
        TotalPages = totalpages;
        Items = items;
    }

    public int CurrentPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public List<FilmeOutputGetAllDTO> Items { get; set; }

}