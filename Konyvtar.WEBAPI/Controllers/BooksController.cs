using Konyvtar.Contracts;
using Konyvtar.WEBAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Konyvtar.WEBAPI.Repositories;

namespace Konyvtar.WEBAPI.Controllers
{

    
    [ApiController]
    [Route("book")]
    public class BooksController : Controller
    {
        private readonly KonyvtarContext _konyvtarcontext;
    public BooksController(KonyvtarContext konyvtarContext)
    {
            _konyvtarcontext = konyvtarContext;
    }
    
        
        [HttpGet]
        public async Task< ActionResult<IEnumerable<Book>>> GetAll ()
        {
            var books = await _konyvtarcontext.Books.ToListAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(long id)
        {
            var book = await _konyvtarcontext.Books.FindAsync(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Book book)
        {
            _konyvtarcontext.Books.Add(book);
            await _konyvtarcontext.SaveChangesAsync();
            return Ok();
        }   
            
        [HttpPut("{id}")]
        public async Task< ActionResult> Put([FromBody] Book book, long id)
        {
            var bookToUpdate = _konyvtarcontext.Books.FindAsync(id);

            if (bookToUpdate != null)
            {
                _konyvtarcontext.Books.Update(book);
                await _konyvtarcontext.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var bookToDelete = await _konyvtarcontext.Books.FindAsync(id);

            if (bookToDelete != null)
            {
                _konyvtarcontext.Books.Remove(bookToDelete);
                await _konyvtarcontext.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }
    }
}
