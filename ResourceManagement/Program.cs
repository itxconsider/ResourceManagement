using Microsoft.EntityFrameworkCore;
using ResourceManagement.EndpiontDefinitions;
using ResourceManagement.Extensions;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddApplicationServices(connectionString);
builder.Services.AddEndpointDefinitions(typeof(IEndpointDefinition));

var app = builder.Build();

app.UseHttpsRedirection();
app.UseEndpiontDefinitions();
app.Run();
