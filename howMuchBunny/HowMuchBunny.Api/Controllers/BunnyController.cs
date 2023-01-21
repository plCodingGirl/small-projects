using Microsoft.AspNetCore.Mvc;

namespace HowMuchBunny.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BunnyController : ControllerBase
{
    private static readonly List<Bunny> Bunnies = new List<Bunny>()
    {
        new Bunny()
        {
            Name = "Amelia",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023,01,21), Value = 1.3m }
            }
        },
        
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Bunny>))]
    public IActionResult GetBunnies()
    {
        return Ok(Bunnies);
    }
}