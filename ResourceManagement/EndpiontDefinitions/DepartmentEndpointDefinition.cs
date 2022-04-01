using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Repositories.Implement;
using ResourceManagement.Repositories.Interface;
using ResourceManagement.Request;

namespace ResourceManagement.EndpiontDefinitions
{
    public class DepartmentEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("/department/{id}", async ([FromServices] IDepartment repo, Guid id) =>
            {
                var dep = await repo.Get(id);
                return dep is not null ? Results.Ok(dep) : Results.NotFound($"record not found for {nameof(id)}");
            });

            app.MapGet("/departments", ([FromServices] IDepartment repo) => repo.GetAll());

            app.MapPost("/department", ([FromServices] IDepartment repo, [FromBody] DepartmentRequest department) =>
            {
                if (department == null) return Results.BadRequest(nameof(department));
                var op = repo.AddUpdate(department);
                return Results.Ok(op);
            });

            app.MapPut("/department", ([FromServices] IDepartment repo, [FromBody] DepartmentRequest department) =>
            {
                if (department == null) return Results.BadRequest(nameof(department));
                var op = repo.AddUpdate(department);
                return Results.Ok(op);
            });

            app.MapDelete("/department/{id}", ([FromServices] IDepartment repo, [FromRoute] Guid id) =>
            {
                if (id.Equals(Guid.Empty)) return Results.BadRequest(nameof(id));
                repo.Delete(id);
                return Results.Ok();
            });
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IDepartment, DepartmentRepository>();
        }
    }
}
