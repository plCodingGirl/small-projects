using Microsoft.EntityFrameworkCore;

namespace HowMuchBunny.Api.Model;

public class BunnyWeightContext : DbContext
{
    public DbSet<Bunny> Bunnies { get; set; } 
    public DbSet<Weight> Weights { get; set; } 
    
    public string DbPath { get; }

    public BunnyWeightContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "bunnies.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
