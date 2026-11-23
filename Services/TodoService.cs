using System;
using Microsoft.EntityFrameworkCore;
using todoapi.Models;

namespace todoapi.Services;

public class TodoService: ITodoService {

    private readonly TodoDbContext _db;
    public TodoService(TodoDbContext db) {
        this._db = db;
    }

    public async Task<IEnumerable<Todo>> GetTodosAsync() {
        return await _db.Todos.ToListAsync();
    }
    public async Task<Todo> GetTodoAsync(int id) {
        return await _db.Todos.FindAsync(id);
    }
    public async Task<Todo> CreateTodoAsync(Todo todo) {
        _db.Todos.Add(todo);
        await _db.SaveChangesAsync();
        return todo;
    }

}