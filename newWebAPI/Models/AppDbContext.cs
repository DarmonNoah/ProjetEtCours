using Microsoft<;<entityFrameworkCore;

namespace newWebAPI.Models;

public class AppDbContext : AppDbContext
{
    private const string ConnectionString=@"Server=localhost;Database=BookDb;Trusted_Connection=True;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
    {
        optionBuilder.UseSqlServer(ConnectionString);
    }

    public BdSet<Book> Books {get;set}
    
}