var builder = DistributedApplication.CreateBuilder(args);


var sql = builder.AddSqlServer("sql")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("demodb");

builder.AddProject<Projects.BlazorApp1>("blazorapp1").WithReference(db);



builder.Build().Run();
