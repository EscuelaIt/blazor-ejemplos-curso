using System.Text.Json;
using Microsoft.Extensions.Options;
using TodoList.Client.Pages;
using TodoList.Config;
using TodoList.Models;

namespace TodoList.Services;

public class FileTodoService : ITodoService
{
    private readonly TodoServiceConfig _config;
    public FileTodoService(IOptions<TodoServiceConfig> config)
    {
        _config = config.Value;
    }

    public async Task<IEnumerable<TodoTask>> GetAll()
    {
        var json = await File.ReadAllTextAsync(_config.FileName);
        var tasks = JsonSerializer.Deserialize<IEnumerable<TodoTask>>(json, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        return tasks;
    }

    public async Task MarkAsDone(int id)
    {
        var json = await File.ReadAllTextAsync(_config.FileName);
        var tasks = JsonSerializer.Deserialize<IEnumerable<TodoTask>>(json, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });
        var todo = tasks.FirstOrDefault(t => !t.IsDone && t.Id == id);
        if (todo is not null)
        {
            todo.MarkDone();
        }

        var json2 = JsonSerializer.Serialize(tasks, new JsonSerializerOptions() {PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
        await File.WriteAllTextAsync(_config.FileName, json2);
    }
}
