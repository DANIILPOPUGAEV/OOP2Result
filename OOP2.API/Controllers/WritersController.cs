using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OOP2.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using OOP2.Infrastructure.Repository;
using OOP2.Domain.Models;

namespace OOP2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WritersController : ControllerBase
    {
        Context db;
        private readonly WriterRepository writerRepository;
        public WritersController(Context context)
        {
            db = context;
            writerRepository = new WriterRepository(context);
            /*if (writerRepository.GetAllWritersAsync() == null) {
                Task task = writerRepository.AddWriter(new Writer { SecondName = "Dostoevski", Name = "Fedor", Patronymic = "Mickhailovich"});
                Task task1 = writerRepository.AddWriter(new Writer { SecondName = "Chechov", Name = "Anton", Patronymic = "Pavlovich" });
            }*/
        }
        [HttpGet]
        public async Task<List<Writer>> Get()
        {
            return await writerRepository.GetAllWritersAsync();
        }
        // GET api/users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Writer?>> Get(Guid id)
        {
            return await writerRepository.GetWriterByIdAsync(id);
        }

        // POST api/users
        [HttpPost]
        public async Task<ActionResult<Writer>> Post(Writer writer)
        {
            if (writer == null)
            {
                return BadRequest();
            }
            await writerRepository.AddWriterAsync(writer);
            return Ok();
        }

        // PUT api/users/
        [HttpPut]
        public async Task<ActionResult<Writer>> Put(Writer writer)
        {
            if (writer == null)
            {
                return BadRequest();
            }
            await writerRepository.UpdateWriterAsync(writer);
            return Ok();
        }
        // DELETE api/users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Writer>> Delete(Guid id)
        {
            await writerRepository.DeleteWriterAsync(id);
            return Ok();

        }


    }
}

