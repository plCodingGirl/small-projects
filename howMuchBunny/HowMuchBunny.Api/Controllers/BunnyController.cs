using HowMuchBunny.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HowMuchBunny.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BunnyController : ControllerBase
{
    private readonly BunnyWeightContext _bunnyContext;

    public BunnyController(BunnyWeightContext bunnyContext)
    {
        _bunnyContext = bunnyContext;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Bunny>))]
    public IActionResult GetBunnies()
    {
        return Ok(_bunnyContext.Bunnies.Include(b => b.Weight).AsNoTracking());
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Bunny))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBunny(int id)
    {
        var bunny = _bunnyContext.Bunnies.Include(b => b.Weight).FirstOrDefault(bunny => bunny.Id == id);
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
        var bunny = _bunnyContext.Bunnies.Include(b => b.Weight).FirstOrDefault(bunny => bunny.Id == id);
        if (bunny == null)
        {
            return NotFound();
        }

        _bunnyContext.Bunnies.Remove(bunny);
        _bunnyContext.SaveChanges();
        return NoContent();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddBunny(AddBunnyRequest newBunny)
    {
        var bunny = new Bunny()
        {
            Name = newBunny.Name,
            Weight = new List<Weight>()
            {
                new Weight() { Date = DateTime.Now, Value = newBunny.Weight }
            }
        };
        _bunnyContext.Add(bunny);
        _bunnyContext.SaveChanges();
        return Created("", bunny);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult AddWeight(int id, AddWeightRequest newWeight)
    {
        var bunny = _bunnyContext.Bunnies.Include(b => b.Weight).FirstOrDefault(bunny => bunny.Id == id);
        if (bunny == null)
        {
            return NotFound();
        }
        bunny.Weight.Add(new Weight() {Date = DateTime.Now, Value = newWeight.Weight});
        _bunnyContext.SaveChanges();
        return Created("", bunny);
    }
}