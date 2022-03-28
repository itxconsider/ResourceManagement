using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceManagement.Database;
using ResourceManagement.Models;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.IncludeFields = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new()
    {
        Title = builder.Environment.ApplicationName,
        Version = "v1"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/departments", (DataContext context) =>
{
    return context.Departments.ToList();
});

app.MapPost("/department", (DataContext context, [FromBody] Department department) =>
{
    if(department == null) return department;
    context.Departments.Add(department);
    context.SaveChanges();
    return department;
});

app.MapPut("/department", ([FromBody] Department department, DataContext context) =>
{
    if (department == null) return department;
     var dep =  context.Departments.Find(department.Id); 
     if (dep != null)
     {
        dep.Name = department.Name;
        dep.Description = department.Description;
        context.Departments.Update(dep);
        context.SaveChanges();
     }
     
    return department;
});

app.MapDelete("/department/{id}", ([FromRoute] int id, DataContext context) =>
{ 
    var dep = context.Departments.Find(id);
    if(dep != null)
    {
        context.Departments.Remove(dep);
        context.SaveChanges(true);
    }
    return ""; 
});

app.Run();
