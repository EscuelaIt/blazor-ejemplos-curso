using System.Net.Http.Json;
using TodoList.Models;

namespace TodoList.Client.Services;

public class ApiTodoService : ITodoService
{
    private readonly HttpClient _client;
    public ApiTodoService(HttpClient client)
    {
        _client = client;
    }
    public async Task<IEnumerable<TodoTask>> GetAll()
    {
        var todos = await _client.GetFromJsonAsync<IEnumerable<TodoTask>>("/api/todos");
        return todos;
    }

    public async Task MarkAsDone(int id)
    {
        var response = await _client.PostAsync($"/api/todos/done/{id}", null);
        // Debería asegurarme que la respuesta es correcta
        if (response.IsSuccessStatusCode)
        {
            // ....
        }
    }
}
