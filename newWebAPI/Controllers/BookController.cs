using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using newWebAPI.Models;

namespace newWebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext _context;

    public BookController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Book>> Get()
    {
        return await _context.Books.ToListAsync();
    }
    [HttpPost]
    public async Task<IEnumerable<Book>> Post()
    {
        return await _context.Books.ToListAsync();
    }

}