using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Course_API.Models;
using Course_API.Services;
using Course_API.DTOs;
using Course_API.Services.Interace;

namespace Course_API.Controllers
{
    [Route("iGuru/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBaseService<Book> _bookService;

        public BookController(IBaseService<Book> bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetAll();
            var bookDTOs = books.Select(b => new 
            {
                b.BookId,
                b.BookName,
                b.AuthorName,
                b.AuthorDetails,
                b.AuthorAffliation,
                b.Status
            });
            return Ok(bookDTOs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _bookService.Get(id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookDTO bookDTO)
        {
            var book = new Book
            {
                BookName = bookDTO.BookName,
                AuthorName = bookDTO.AuthorName,
                AuthorDetails = bookDTO.AuthorDetails,
                AuthorAffliation = bookDTO.AuthorAffliation,
                Boardname = bookDTO.Boardname,
                ClassName = bookDTO.ClassName,
                CourseName = bookDTO.CourseName,
                SubjectName = bookDTO.SubjectName,
                Status = bookDTO.Status
            };
            await _bookService.Add(book);
            return Ok(book);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BookDTO bookDTO)
        {
            var book = new Book
            {
                BookId = bookDTO.BookId,
                BookName = bookDTO.BookName,
                AuthorName = bookDTO.AuthorName,
                AuthorDetails = bookDTO.AuthorDetails,
                AuthorAffliation = bookDTO.AuthorAffliation,
                Boardname = bookDTO.Boardname,
                ClassName = bookDTO.ClassName,
                CourseName = bookDTO.CourseName,
                SubjectName = bookDTO.SubjectName,
                Status = bookDTO.Status
            };
            var updatedBook = await _bookService.Update(book.BookId, book);
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookService.Delete(id);
            if (book == null)
                return NotFound();
            return Ok();
        }
    }
}
