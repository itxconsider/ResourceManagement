using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Repositories.Implement;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;

namespace ResourceManagement.Endpionts
{
    public class DepartmentEndpoints : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("/department/{id}", async ([FromServices] IDepartmentService repo, Guid id) =>
            {
                var dep = await repo.Get(id);
                return dep is not null ? Results.Ok(dep) : Results.NotFound($"record not found for {nameof(id)}");
            });

            app.MapGet("/departments", ([FromServices] IDepartmentService repo) => repo.GetAll());

            app.MapPost("/department", ([FromServices] IDepartmentService repo, [FromBody] DepartmentRequest department) =>
            {
                if (department == null) return Results.BadRequest(nameof(department));
                var op = repo.AddUpdate(department);
                return Results.Ok(op);
            });

            app.MapPut("/department", ([FromServices] IDepartmentService repo, [FromBody] DepartmentRequest department) =>
            {
                if (department == null) return Results.BadRequest(nameof(department));
                var op = repo.AddUpdate(department);
                return Results.Ok(op);
            });

            app.MapDelete("/department/{id}", ([FromServices] IDepartmentService repo, [FromRoute] Guid id) =>
            {
                if (id.Equals(Guid.Empty)) return Results.BadRequest(nameof(id));
                repo.Delete(id);
                return Results.Ok();
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentRepository>();
        }
    }
}
