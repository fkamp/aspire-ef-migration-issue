using AspireApp.Common;
using AspireApp.Common.Data;
using AspireApp.ServiceDefaults;
using AspireApp.Data.Postgres.Extensions;
using Dapper;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.AddPostgresInfrastructure();

// Add services to the container.
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();


app.MapPost("/employees", async (string name, IEmployeeRepo repo) =>
{
    var empl = new Employee { Id = Guid.NewGuid(), Name = name };
    await repo.AddEmployeeAsync(empl);
    return Results.Created($"/employees/{empl.Id}", empl);
}).WithOpenApi();

app.MapGet("/employees", async (ISqlConnectionFactory sqlFactory) =>
{
    using var connection = sqlFactory.CreateConnection();
    const string sql = """
            select * from "Employees" order by "Name"
            """;

    var empls = await connection.QueryAsync<Employee>(
        sql);
    return Results.Ok(empls);

}).WithOpenApi();

app.MapDefaultEndpoints();


app.Run();

