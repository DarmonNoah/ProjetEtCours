using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace newWebAPI.Models;

public class AppDbContext : DbContext
{
    private const string ConnectionString=@"Server=localhost;Database=BookDb;Trusted_Connection=True;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        optionBuilder.UseSqlite(ConnectionString);
    }

    public DbSet<Book> Books {get;set;}
    
}