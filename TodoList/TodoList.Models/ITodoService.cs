using TodoList.Models;

public interface ITodoService
{
    Task<IEnumerable<TodoTask>> GetAll();
    Task MarkAsDone(int id);
}

