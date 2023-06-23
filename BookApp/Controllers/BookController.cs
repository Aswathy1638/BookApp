using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BookApp.Models;

namespace BookstoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<TodoItemBook> _books = new List<TodoItemBook>()
        {
            new TodoItemBook { Id = 1, Title = "Book 1", Author = "Author 1", Genre = "Genre 1", Price = 10.99m },
            new TodoItemBook { Id = 2, Title = "Book 2", Author = "Author 2", Genre = "Genre 2", Price = 12.99m },
            new TodoItemBook { Id = 3, Title = "Book 3", Author = "Author 3", Genre = "Genre 3", Price = 9.99m }
        };

        // GET /api/books
        [HttpGet]
        public ActionResult<IEnumerable<TodoItemBook>> GetBooks()
        {
            return Ok(_books);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<TodoItemBook> GetBook(int id)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST /api/books
        [HttpPost]
        public ActionResult<TodoItemBook> AddBook(TodoItemBook book)
        {
            book.Id = _books.Count + 1;
            _books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, TodoItemBook updatedBook)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Genre = updatedBook.Genre;
            book.Price = updatedBook.Price;
            return NoContent();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _books.Find(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            _books.Remove(book);
            return NoContent();
        }
    }
}
