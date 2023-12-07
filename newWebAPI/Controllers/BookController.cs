using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newWebAPI.Models;
using newWebAPI.Models.DTOs;
using AutoMapper;

namespace newWebAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public BookController(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Book>>> Get()
    {
        var temp = await _context.Books.ToListAsync();
        var bookMap = _mapper.Map<IEnumerable<BookUpdateDTO>>(temp);
        return Ok(bookMap);
    }


    // GET: api/Book/[id]
    [HttpGet("ById/{id}", Name = nameof(GetBook))]
    public async Task<ActionResult<Book>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return book;
/*
        var response = new BookDetailDto
        {
            Id = book. Id,
            Title = book. Title,
            Author = book. Author,
            Genre = book. Genre,
            Price = book.Price,
            Publishbate = book. PublishDate,
            Description = book.Description,
            Remarks = book. Remarks
        }
*/
    }

    // POST: api/Book
    // BODY: Book (JSON)
    [HttpPost]
    [ProducesResponseType(201, Type = typeof(Book))]
    [ProducesResponseType(400)]
    public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
    {
        // we check if the parameter is null
        if (book == null)
        {
            return BadRequest();
        }
        // we check if the book already exists
        Book? addedBook = await _context.Books.FirstOrDefaultAsync(b => b.Title == book.Title);
        if (addedBook != null)
        {
            return BadRequest("Book already exists");
        }
        else
        {
            // we add the book to the database
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }
            // we return the book
            return CreatedAtRoute(
                routeName: nameof(GetBook),
                routeValues: new { id = book.Id },
                value: book);
    }

    // TODO: PUT: api/Book/[id] creer la route qui permet de mettre a jour un livre existant
    // TODO: utilisez des annotations pour valider les donnees entrantes avec ModelState
    // TODO: utilisez le package AutoMapper pour mapper les donnees de BookUpdateDTO vers Book
    [HttpPut("{id}/{Price}")]
    public async Task<ActionResult<Book>> PutBook(int id, [FromBody] BookUpdateDTO book, string price)
    {
        if(book == null)
        {
            return BadRequest();
        }
        var book2 = await _context.Books.FindAsync(id);
        if(book2 == null)
        {
            return NotFound();
        }
        var bookMap = _mapper.Map<Book>(book);
        book2.Price = bookMap.Price;
        await _context.SaveChangesAsync();
        return NoContent();
    }


    [HttpDelete("{id}")]
    // TODO: DELETE: api/Book/[id] creer la route qui permet de supprimer un livre existant
    public async Task<ActionResult<Book>> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        _context.Books.Remove(book);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}