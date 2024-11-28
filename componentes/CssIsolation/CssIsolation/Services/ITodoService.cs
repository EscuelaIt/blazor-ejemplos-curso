namespace CssIsolation.Services;

public interface ITodoService
{
    Task<IEnumerable<TodoTask>> GetAll();
    Task MarkAsDone(int id);
}

class InMemoryTodoService : ITodoService
{
    private List<TodoTask> _todos = [];

    public InMemoryTodoService()
    {
        _todos =
        [
            new TodoTask(1, "Task 1"),
            new TodoTask(2, "Task two", TaskType.Important),
            new TodoTask(3, "Task three", TaskType.NotImportant),
        ];
    }

    public async Task<IEnumerable<TodoTask>> GetAll()
    {
        // Este método sería el que accedería a base de datos
        return _todos;
    }

    public async Task MarkAsDone(int id)
    {
        var todo = _todos.FirstOrDefault(t => !t.IsDone && t.Id == id);
        if (todo is not null)
        {
            // Marcar la tarea como hecha
            todo.MarkDone();
        }
    }
}


