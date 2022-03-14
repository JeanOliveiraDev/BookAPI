using BookAPI.Model;
using BookAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> Create([FromBody] Book book)
        {
            var newBook = await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _bookRepository.GetById(id);

            if (bookToDelete == null)
                return NotFound();

            await _bookRepository.Delete(bookToDelete.Id);

            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> Update(int Id, [FromBody] Book book)
        {
            if (Id != book.Id)
                return BadRequest();

            await _bookRepository.Update(book);

            return NoContent();
        }
    }
}
