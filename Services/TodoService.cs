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
    public async Task<Todo> UpdateTodoAsync(int id, Todo todo) {
        var existingTodo = await _db.Todos.FindAsync(id);
        if (existingTodo == null) {
            return null;
        }
        existingTodo.Task = todo.Task;
        existingTodo.Completed = todo.Completed;
        await _db.SaveChangesAsync();
        return existingTodo;
    }
    public async Task<bool> DeleteTodoAsync(int id) {
        var todo = await _db.Todos.FindAsync(id);
        if (todo == null) {
            return false;
        }
        _db.Todos.Remove(todo);
        await _db.SaveChangesAsync();
        return true;
    }

}