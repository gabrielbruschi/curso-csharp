using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]

public class MovieController : ControllerBase
{
    public MovieController()
    {

    }

    [HttpPost] //criar
    public string Post()
    {
        return "Post";
    }

    [HttpPut] // atualizar
    public string Put()
    {
        return "Put";
    }

    [HttpGet]
    public string Get()
    {
        return "Get";
    }

    [HttpDelete]
    public string Delete()
    {
        return "Delete";
    }
}