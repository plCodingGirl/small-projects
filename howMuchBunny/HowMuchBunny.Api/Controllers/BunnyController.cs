using HowMuchBunny.Api.Model;
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
            Id = 1,
            Name = "Amelia",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023,01,21), Value = 1.3m }
            }
        },
        new Bunny()
        {
            Id = 2,
            Name = "Amelia",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023,01,21), Value = 1.5m }
            }
        },
        new Bunny()
        {
            Id = 3,
            Name = "Amelia",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023,01,21), Value = 1.0m }
            }
        },
        new Bunny()
        {
            Id = 4,
            Name = "Helena",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023,01,21), Value = 1.3m }
            }
        },
        new Bunny()
        {
            Id = 5,
            Name = "Helena",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023,01,21), Value = 1.5m }
            }
        },
        new Bunny()
        {
            Id = 6,
            Name = "Niko",
            Weight = new List<Weight>()
            {
                new Weight() { Date = new DateTime(2023, 01, 22), Value = 2.5m }
            }
        }
        
    };

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Bunny>))]
    public IActionResult GetBunnies()
    {
        return Ok(Bunnies);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Bunny))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBunny(int id)
    {
        var bunny = Bunnies.FirstOrDefault(bunny => bunny.Id == id);
        if (bunny == null)
        {
            return NotFound();
        }
        return Ok(bunny);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteBunny(int id)
    {
        var bunny = Bunnies.FirstOrDefault(bunny => bunny.Id == id);
        if (bunny == null)
        {
            return NotFound();
        }

        Bunnies.Remove(bunny);
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddBunny(AddBunnyRequest newBunny)
    {
        var bunny = new Bunny()
        {
            Id = Bunnies.Count + 1,
            Name = newBunny.Name,
            Weight = new List<Weight>()
            {
                new Weight() { Date = DateTime.Now, Value = newBunny.Weight }
            }
        };
        Bunnies.Add(bunny);
        return Created("", bunny);
    }
}