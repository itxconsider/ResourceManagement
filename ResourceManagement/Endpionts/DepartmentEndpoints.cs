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
            app.MapGet("/department/{id}", GetDepartment);
            app.MapGet("/departments", GetDepartments);
            app.MapPost("/department", AddDepartment);
            app.MapPut("/department", UpdateDepartment);
            app.MapDelete("/department/{id}", DeleteDapartment);
        }
        
        internal  IResult GetDepartment([FromServices] IDepartmentService repo, Guid id)
        {
            var dep =  repo.Get(id);
            return dep is not null ? Results.Ok(dep) : Results.NotFound($"record not found for {nameof(id)}");
        }
        internal IResult GetDepartments([FromServices] IDepartmentService repo, [FromQuery] int page, [FromQuery] int size, [FromQuery] string? search)
        {
            return Results.Ok(repo.GetAll(page, size, search, ""));
        }

        internal IResult AddDepartment([FromServices] IDepartmentService repo, [FromBody] DepartmentRequest department)
        {
            if (department == null) return Results.BadRequest(nameof(department));
            var op = repo.AddUpdate(department);
            return Results.Ok(op);
        }

        internal IResult UpdateDepartment([FromServices] IDepartmentService repo, [FromBody] DepartmentRequest department)
        {
            if (department == null) return Results.BadRequest(nameof(department));
            var op = repo.AddUpdate(department);
            return Results.Ok(op);
        }
        internal IResult DeleteDapartment([FromServices] IDepartmentService repo, [FromRoute] Guid id)
        {
            if (id.Equals(Guid.Empty)) return Results.BadRequest(nameof(id));
            repo.Delete(id);
            return Results.Ok();
        }

        public void DefineServices(IServiceCollection services)
        { 
            services.AddScoped<IDepartmentService, DepartmentRepository>();
        }
    }
}
