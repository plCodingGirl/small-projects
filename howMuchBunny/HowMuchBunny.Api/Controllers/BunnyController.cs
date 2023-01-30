using HowMuchBunny.Api.Model;
using Microsoft.AspNetCore.Mvc;

namespace HowMuchBunny.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BunnyController : ControllerBase
{
    private static readonly List<Bunny> Bunnies = new List<Bunny>();

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

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AddWeight(int id, AddWeightRequest newWeight)
    {
        var bunny = Bunnies.FirstOrDefault(bunny => bunny.Id == id);
        if (bunny == null)
        {
            return NotFound();
        }
        bunny.Weight.Add(new Weight() {Date = DateTime.Now, Value = newWeight.Weight});
        return Created("", bunny);
    }
}