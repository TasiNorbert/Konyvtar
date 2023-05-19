using Konyvtar.WEBAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly KonyvtarContext _context;
        private readonly ILogger<BooksController> _logger;

        public BooksController(KonyvtarContext context, ILogger<BooksController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }

            _context.Books.Remove(existingBook);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            _logger.LogInformation("People endpoint was called");
            var books = await _context.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

     /*   [HttpGet("{id}/items")]
        public async Task<ActionResult<Book>> GetItems(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)                                       // ehez még kell egy másik tábla
            {
                return NotFound();
            }

            return Ok(person.Items);
        }*/

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            var existingBook = await _context.Books.FindAsync(id);

            if (existingBook is null)
            {
                return NotFound();
            }
            existingBook.Id = book.Id;
            existingBook.Author = book.Author;
            existingBook.Title = book.Title;
            existingBook.IsBorrowed = book.IsBorrowed;
            existingBook.NameOfBorrower = book.NameOfBorrower;
            existingBook.DateOfBorrowing = book.DateOfBorrowing;
            existingBook.DateOfReturn = book.DateOfReturn;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}