using System.Collections.Generic;

public class DiretorListOutputGetAllDTO
{
    public DiretorListOutputGetAllDTO(int currentpage, int totalitems, int totalpages, List<DiretorOutputGetAllDTO> items)
    {
        CurrentPage = currentpage;
        TotalItems = totalitems;
        TotalPages = totalpages;
        Items = items;
    }

    public int CurrentPage { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public List<DiretorOutputGetAllDTO> Items { get; set; }

}