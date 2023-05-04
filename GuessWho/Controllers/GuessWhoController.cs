using Microsoft.AspNetCore.Mvc;

namespace GuessWho.Controllers;

[ApiController]
public class GuessWhoController : ControllerBase
{
    private HttpClient httpClient;

    public GuessWhoController(IConfiguration config)
    {
        httpClient = new()
        {
            BaseAddress = new Uri("https://api.themoviedb.org/3/"),
            DefaultRequestHeaders = { { "Authorization", $"Bearer {config["TbdbKey"]}" } }
        };
    }
    
    [HttpGet("")]
    public async Task<IActionResult> GetMovie()
    {
        using HttpResponseMessage response = await httpClient.GetAsync("movie/550");
        
        response.EnsureSuccessStatusCode();
    
        var jsonResponse = await response.Content.ReadAsStringAsync();

        return Ok(jsonResponse);
    }
}