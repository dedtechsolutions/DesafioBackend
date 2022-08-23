using Microsoft.EntityFrameworkCore;
using Shedule.Domain;
using Shedule.Repository;
using Shedule.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("SheduleConnection");
builder.Services.AddSqlServer<SheduleContext>(connectionString);
builder.Services.AddTransient<IRepositoryAssignment, RepositoryAssignment>();
builder.Services.AddTransient<IServiceAssignment, ServiceAssignment>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
await ValidateDatabase(app.Services, app.Logger);
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/Task", async (IServiceAssignment service) =>
    await service.Get())
    .WithName("GetTask");

app.MapGet("/task/{id}", async (Guid id, IServiceAssignment service) =>
    await service.Get(id)
        is Assignment assignment
            ? Results.Ok(assignment)
            : Results.NotFound())
    .WithName("GetTaskById")
    .Produces<Assignment>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);


app.MapPost("/task", async (Assignment assignment, IServiceAssignment service) =>
 await service.Create(assignment)
        is Assignment result
            ? Results.Created($"/task/{result.Id}", result)
            : Results.BadRequest("Request invalid")
).WithName("CreateTask")
 .ProducesValidationProblem()
 .Produces<Assignment>(StatusCodes.Status201Created);

app.MapPut("/task/{id}", async (Guid id, Assignment assignment, IServiceAssignment service) =>
    await service.Update(id,assignment)
           is Assignment result
               ? Results.Accepted($"/task/{result.Id}", result)
               : Results.NotFound("Request invalid")
)
    .WithName("UpdateTask")
    .ProducesValidationProblem()
    .Produces(StatusCodes.Status202Accepted)
    .Produces(StatusCodes.Status404NotFound);
app.MapDelete("/task/{id}", async (Guid id, IServiceAssignment service) =>
    await service.Delete(id)
           is bool result
               ? Results.NoContent()
               : Results.NotFound("Request invalid"))
    .WithName("DeleteTask")
    .Produces(StatusCodes.Status204NoContent)
    .Produces(StatusCodes.Status404NotFound);

app.Run();




async Task ValidateDatabase(IServiceProvider services, ILogger logger)
{
    using var db = services.CreateScope().ServiceProvider.GetRequiredService<SheduleContext>();
    await db.Database.EnsureCreatedAsync();
    await db.Database.MigrateAsync();
}