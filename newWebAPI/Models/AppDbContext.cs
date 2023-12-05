using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace newWebAPI.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }
    //private const string ConnectionString=@"Server=localhost;Database=BookDb;Trusted_Connection=True;";
    private const string ConnectionString="Data Source = Books.db;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var currentDir = Directory. GetCurrentDirectory();
        var dbPath = Path.Combine(currentDir, "Books.db");
        optionsBuilder.UseSqlite($"Filename={dbPath}");
    }
       /*
     new Book
    {
        Id = 2,
        Title = "Professional C# 7 and .NET Core 2.0",
        Author = "Christian Nagel",
        Description = "A true masterclass in C# and .NET programming",
        Genre = "Software",
        Price = 50,
        PublishDate = new DateTime(2018, 04, 18)
    },

        new Book
        {
        Id = 3,
        Title = "Professional C# 8 and .NET Core 3.0",
        Author = "Christian Nagel",
        Description = "A true masterclass in C# and .NET programming",
        Genre = "Software",
        Price = 50,
        PublishDate = new DateTime(2019, 10, 30)
        }
*/
    public DbSet<Book> Books {get;set;} = default!;
    
}