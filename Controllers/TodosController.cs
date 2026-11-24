using Microsoft.AspNetCore.Mvc;

using todoapi.Models;
using todoapi.Services;

namespace todoapi.Controllers;

[ApiController]
[Route("api/v1.0/todos")]
public class TodosController : ControllerBase
{
   private readonly ITodoService _todoService;
   public TodosController(ITodoService todoService) {
       this._todoService = todoService;
   }

    [HttpGet(Name = "GetTodos")]
    public async Task<IEnumerable<Todo>> Get()
    {
        return await _todoService.GetTodosAsync();
    }
    [HttpGet("completed")]
    public async Task<IEnumerable<Todo>> GetCompleted()
    {
        return await _todoService.GetCompletedTodosAsync();
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetTodo(int id)
    {
        var todo = await _todoService.GetTodoAsync(id);
        if (todo == null)
        {
            return NotFound();
        }
        return todo;
    }
    [HttpPost]
    public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
    {
        var createdTodo = await _todoService.CreateTodoAsync(todo);
        return CreatedAtAction(nameof(GetTodo), new { id = createdTodo.Id }, createdTodo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, Todo todo)
    {
        var updatedTodo = await _todoService.UpdateTodoAsync(id, todo);
        if (updatedTodo == null)
        {
            return NotFound();
        }
        return Ok(updatedTodo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var result = await _todoService.DeleteTodoAsync(id);
        if (!result)
        {
            return NotFound();
        }
        return NoContent();
    }
}
