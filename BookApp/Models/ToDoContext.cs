using Microsoft.EntityFrameworkCore;

namespace BookApp.Models
{
    public class ToDoContext : DbContext
    {
     public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) 
        { }
        public DbSet<TodoItemBook> TodoItems { get; set; }
    }
}
