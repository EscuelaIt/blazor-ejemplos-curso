using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoList.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(sp => new HttpClient()
{
    BaseAddress = new Uri(builder.Configuration["Api:Server"])
});
builder.Services.AddScoped<ITodoService, ApiTodoService>();

await builder.Build().RunAsync();
