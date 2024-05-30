using API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalutController : ControllerBase
{
    //Controller Example
    [HttpGet("Salut")]
    public string Salut()
    {
        Console.WriteLine("SalutController");
        return $"Salut !";
    }

    //Attribute Example
    [HttpGet("")]
    [MyLogging("Test Attributes")]
    public string TestAttributes()
    {
        Console.WriteLine("Ceci est un test de l'attribute");
        return "Ceci est un test de l'attribute";
    }

    //Async Attribute Example
    [HttpGet("Async")]
    [MyLoggingAsync("Test Async")]
    public string TestAsyncAttribute()
    {
        Console.WriteLine("Ceci est un test de l'attribute Async");
        return "Ceci est un test de l'attribute";
    }
}
