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
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var books = BookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(long id)
        {
            var book = BookRepository.GetBook(id);

            if (book != null)
            {
                return Ok(book);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult Post(Book book)
        {
            BookRepository.AddBook(book);
            return Ok();
        }   
            
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Book book, long id)
        {
            var bookToUpdate = BookRepository.GetBook(id);

            if (bookToUpdate != null)
            {
                BookRepository.UpdateBook(book);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var bookToDelete = BookRepository.GetBook(id);

            if (bookToDelete != null)
            {
                BookRepository.DeleteBook(bookToDelete);
                return Ok();
            }

            return NotFound();
        }
    }
}
