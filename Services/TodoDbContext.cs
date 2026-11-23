
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using todoapi.Models;

namespace todoapi.Services;

public class TodoDbContext: DbContext {
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) {}
    public DbSet<Todo> Todos => Set<Todo>();
}