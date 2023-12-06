namespace newWebAPI.Models;
 
public class Book
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    public int Price { get; set; }
    public DateTime PublishDate { get; set; }
    public string? Description { get; set; }
    string? Remarks {get;set;}
    
    public Book(int id, string? title, string? author, string? genre, int price, DateTime publishDate, string? description, string? remarks)
    {
        Id=id;
        Title=title;
        Author=author;
        Genre=genre;
        Price=price;
        PublishDate=publishDate;
        Description=description;
        Remarks=remarks;
    }

}
