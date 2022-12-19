using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP2.Domain;
using OOP2.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OOP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly Context db;
        public BooksController(Context context)
        {
            db = context;
            /*
            if (!db.Books.Any())
            {
                db.Books.Add(new Book { Title = "Преступление и наказание", ISBN = "999-999-9999" });
                db.Books.Add(new Book { Title = "Вишнёвый сад", ISBN = "888-888-8888" });
                db.SaveChanges();
            }
            */
        }
        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<Book?>> Get()
        {
            return await db.Books.ToListAsync();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<Book>> Get(Guid id)
        {
            Book book = await db.Books.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (book == null)
                return NotFound();
            return new ObjectResult(book);
        }


        [HttpPost]
        public async Task<ActionResult<Book>> Post(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Book>> Put(Writer book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            if (!db.Books.Any(x => x.Id == book.Id))
            {
                return NotFound();
            }

            db.Update(book);
            await db.SaveChangesAsync();
            return Ok(book);
        }
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> Delete(Guid id)
        {
            Book book = db.Books.FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            db.Books.Remove(book);
            await db.SaveChangesAsync();
            {
                return Ok(book);
            }

        }
    }
}
