using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Repositories.Implement;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;

namespace ResourceManagement.Endpionts
{
    public class WorkEndpoints : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("api/work/{id}", GetWork);
            app.MapGet("api/works", GetWorks);
            app.MapPost("api/work", CreateWork);
            app.MapPut("api/work", UpdateWork);
            app.MapDelete("api/work/{id}", DeleteWork);
        }

        internal IResult GetWork([FromServices] IWorkService service, [FromRoute] Guid Id)
        {
            return Results.Ok(service.Get(Id));
        }

        internal IResult GetWorks([FromServices] IWorkService service)
        {
            return Results.Ok(service.GetAll());
        }
        internal IResult CreateWork([FromServices] IWorkService service, [FromBody] WorkRequest request)
        {
            if(request == null) return Results.BadRequest();
            request.Id = Guid.Empty;
            return Results.Ok(service.AddUpdate(request));
        }
        internal IResult UpdateWork([FromServices] IWorkService service, [FromBody] WorkRequest request)
        {
            if (request == null) return Results.BadRequest();
            var work = service.Get(request.Id);
            if(work == null) return Results.NotFound();
            return Results.Ok(service.AddUpdate(request));
        }
        internal IResult DeleteWork([FromServices] IWorkService service,[FromRoute] Guid id)
        {
            var work = service.Get(id);
            if( work == null) return Results.NotFound();    
            service.Delete(id);
            return Results.Ok();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IWorkService, WorkRepository>();
        }
    }
}
