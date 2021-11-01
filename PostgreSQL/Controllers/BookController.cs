using ApiPostgreSQL;
using APIPostgreSQLModelos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PostgreSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {

        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCars()
        {
            return Ok(await _bookRepository.GetAllBooks());
        }

        [HttpGet("{title}")]
        public async Task<ActionResult> GetBookByTitle(string title)
        {
            return Ok(await _bookRepository.GetBookByTitle(title));
        }
            


        [HttpPost]
        public async Task<ActionResult> CreateBook([FromBody] Book book)
        {
            if (book == null)
                return BadRequest();
             

            if (!ModelState.IsValid)
                return BadRequest();

      
            var editorial = new Editorial
            {
                Name = "Editorial",
                Date = DateTime.Now,
                Summary = "Something"
            };

            string jsonString = JsonSerializer.Serialize(editorial);
            book.Data = jsonString;

            var created = await _bookRepository.InsertBook(book);

            return Created("created", created);
        }


    }
}
