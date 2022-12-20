using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OOP2.Domain.Models;
using OOP2.Infrastructure.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OOP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GanresController : ControllerBase
    {
        private readonly Context db;
        public GanresController(Context context)
        {
            db = context;
            /*if (!db.Genres.Any())
            {
                db.Genres.Add(new Genre { Content = "Рассказ" });
                db.Genres.Add(new Genre { Content = "Комедия" });
                db.SaveChanges();
            }*/
        }
        [HttpGet]
        public async Task<ActionResult<List<Genre>>> Get()
        {
            return await db.Genres.ToListAsync();
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Genre>>> Get(Guid id)
        {
            Genre genre = await db.Genres.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (genre == null)
                return NotFound();
            return new ObjectResult(genre);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Genre>> Post(Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }

            db.Genres.Add(genre);
            await db.SaveChangesAsync();
            return Ok(genre);
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Genre>> Put(Genre genre)
        {
            if (genre == null)
            {
                return BadRequest();
            }
            if (!db.Genres.Any(x => x.Id == genre.Id))
            {
                return NotFound();
            }

            db.Update(genre);
            await db.SaveChangesAsync();
            return Ok(genre);
        }
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Genre>> Delete(Guid id)
        {
            Genre genre = db.Genres.FirstOrDefault(x => x.Id == id);
            if (genre == null)
            {
                return NotFound();
            }
            db.Genres.Remove(genre);
            await db.SaveChangesAsync();
            {
                return Ok(genre);
            }

        }
    }
}
