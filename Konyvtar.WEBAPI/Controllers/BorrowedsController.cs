using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Konyvtar.WEBAPI;
using Konyvtar.WEBAPI.Repositories;

namespace Konyvtar.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BorrowedsController : ControllerBase
    {
        private readonly KonyvtarContext _context;

        public BorrowedsController(KonyvtarContext context)
        {
            _context = context;
        }

        // GET: api/Borroweds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Borrowed>>> GetBorroweds()
        {
          if (_context.Borroweds == null)
          {
              return NotFound();
          }
            return await _context.Borroweds.ToListAsync();
        }

        // GET: api/Borroweds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Borrowed>> GetBorrowed(long id)
        {
          if (_context.Borroweds == null)
          {
              return NotFound();
          }
            var borrowed = await _context.Borroweds.FindAsync(id);

            if (borrowed == null)
            {
                return NotFound();
            }

            return borrowed;
        }

        // PUT: api/Borroweds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBorrowed(long id, Borrowed borrowed)
        {
            if (id != borrowed.Id)
            {
                return BadRequest();
            }

            _context.Entry(borrowed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BorrowedExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Borroweds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Borrowed>> PostBorrowed(Borrowed borrowed)
        {
          if (_context.Borroweds == null)
          {
              return Problem("Entity set 'KonyvtarContext.Borroweds'  is null.");
          }
            _context.Borroweds.Add(borrowed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBorrowed", new { id = borrowed.Id }, borrowed);
        }

        // DELETE: api/Borroweds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBorrowed(long id)
        {
            if (_context.Borroweds == null)
            {
                return NotFound();
            }
            var borrowed = await _context.Borroweds.FindAsync(id);
            if (borrowed == null)
            {
                return NotFound();
            }

            _context.Borroweds.Remove(borrowed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BorrowedExists(long id)
        {
            return (_context.Borroweds?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
