using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;

namespace BookApp.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /* private static List<TodoItemBook> _books = new List<TodoItemBook>()
         {
             new TodoItemBook { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Genre 1", Price = 10.99m },
             new TodoItemBook { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Genre 2", Price = 12.99m },
             new TodoItemBook { Id = 3, Title = "Book 3", Author = "Author 3", Genre = "Genre 3", Price = 9.99m }
         };*/
        private readonly ToDoContext _context;

        public BookController(ToDoContext context)
        {
            _context = context;
        }


        // GET /api/books
        /*[HttpGet]
        public ActionResult<IEnumerable<TodoItemBook>> GetBooks()
        {
            return Ok(_books);
        }*/
        [HttpGet]
        public IActionResult GetBooks()
        {
            var books = _context.TodoItemBooks.ToList();
            return Ok(books);
        }


        // GET /api/books/{id}
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            var book = _context.TodoItemBooks.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }


        // POST /api/books
         [HttpPost]
        public IActionResult AddBook(TodoItemBook book)
        {
            if (string.IsNullOrWhiteSpace(book.Title) || string.IsNullOrWhiteSpace(book.Author) || string.IsNullOrWhiteSpace(book.Genre))
            {
                return BadRequest("Invalid data for a new book");
            }

            _context.TodoItemBooks.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id}, book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, TodoItemBook updatedBook)
        {
            var book = _context.TodoItemBooks.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.Price = updatedBook.Price;

            _context.SaveChanges();
            return NoContent();
        }


        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.TodoItemBooks.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.TodoItemBooks.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
