using todoapi.Models;

namespace todoapi.Services;
public interface ITodoService {
    Task<IEnumerable<Todo>> GetTodosAsync();
    Task<IEnumerable<Todo>> GetCompletedTodosAsync();
    Task<Todo> GetTodoAsync(int id);
    Task<Todo> CreateTodoAsync(Todo todo);
    Task<Todo> UpdateTodoAsync(int id, Todo todo);
    Task<bool> DeleteTodoAsync(int id);
}