using Microsoft.EntityFrameworkCore;

namespace newWebAPI.Models;


public class AppDbContext : DbContext
{

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDir = Directory.GetCurrentDirectory();
        var dbPath = Path.Combine(currentDir, "Books.db");
        Console.WriteLine($"using db at {dbPath}");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }

    public DbSet<Book> Books { get; set; } = default!;
}