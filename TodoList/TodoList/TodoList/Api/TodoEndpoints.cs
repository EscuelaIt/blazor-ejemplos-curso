using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api;

public class TodoEndpoints
{
    public static async Task<IResult> GetAllTodos([FromServices] ITodoService svc)
    {
        var todos = await svc.GetAll();
        return Results.Ok(todos);
    }

    public static async Task MarkAsDone(int id, [FromServices] ITodoService svc)
    {
        await svc.MarkAsDone(id);
    }
}
