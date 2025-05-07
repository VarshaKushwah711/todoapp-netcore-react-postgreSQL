using Microsoft.EntityFrameworkCore;
using TodoApp.API.Models;

namespace TodoApp.API.Data
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options) : base(options) {}

        public DbSet<TodoItem> TodoItems { get; set; }  = null!;
    }
}
// Yeh DB se connection aur table access handle karta hai using EF Core.