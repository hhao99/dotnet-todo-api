using System;

namespace todoapi.Models;

public class Todo {
    public int Id { get; set; }
    public string Task { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }

    public Todo(string task, bool completed) {
        this.Task = task;
        this.Completed = completed;
    }
}