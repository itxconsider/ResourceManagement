using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Repositories.Implement;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;

namespace ResourceManagement.Endpionts
{
    public class PositionEndPionts : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("api/position/{id}", GetPosition);
            app.MapGet("api/positions", GetPositions);
            app.MapPost("api/position", CreatePosition);
            app.MapPut("api/position", UpdatePosition);
        }

        internal IResult GetPosition(IPositionService service, [FromRoute] Guid id)
        {
            if (id.Equals(Guid.Empty)) return Results.BadRequest();
            var resource = service.Get(id);
            return resource is not null ? Results.Ok(resource) : Results.NotFound();
        }
        internal IResult GetPositions([FromServices] IPositionService service)
        {
            return Results.Ok(service.GetAll());
        }
        internal IResult CreatePosition([FromServices] IPositionService service, [FromBody] PositionRequest request)
        {
            return Results.Ok();
        }
        internal IResult UpdatePosition([FromServices] IPositionService service, [FromBody] PositionRequest request)
        {
            return Results.Ok();
        }

        internal IResult DeletePosition([FromServices] IPositionService service, [FromBody] PositionRequest request)
        {
            return Results.Ok();
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IPositionService, PositionRepository>();
        }
    }
}
