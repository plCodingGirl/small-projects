namespace GuessWho.Model;

public class Actor
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public List<Movie> Movie { get; set; }
}