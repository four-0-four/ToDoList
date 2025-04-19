namespace ToDoAPI.Data;

using Microsoft.EntityFrameworkCore;
using ToDoAPI.Models;

public class ToDoDbContext : DbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    public DbSet<ToDoItem> ToDos { get; set; } // This becomes a "ToDos" table in the DB
}
