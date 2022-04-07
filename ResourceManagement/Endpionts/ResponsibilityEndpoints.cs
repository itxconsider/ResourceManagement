using Microsoft.AspNetCore.Mvc;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Endpionts
{
    public class ResponsibilityEndpoints : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("/api/responsibity/{id}", GetResponsibity);
            app.MapGet("/api/responsibities", GetResponsibities);
            app.MapPost("/api/responsibity", CreateResponsibitie);
            app.MapPut("/api/responsibity", UpdateResponsibitie);
            app.MapDelete("/api/responsibillty{id}", DeleteResponsibitie);
        }
        private IResult GetResponsibity([FromServices] IResponsibityService service, [FromRoute] Guid id)
        {
            var resource = service.Get(id);
            return resource is not null ? Results.Ok(resource) : Results.NotFound();
        }

        internal async Task<List<ResponsibilityResponse>> GetResponsibities([FromServices] IResponsibityService service)
        {
            return await service.GetAll();
        }

        internal IResult CreateResponsibitie([FromServices] IResponsibityService service,[FromBody] ResponsibilityRequest request)
        {
            request.Id = Guid.Empty;
            return Results.Ok(service.AddUpdate(request));
        }

        internal IResult UpdateResponsibitie([FromServices] IResponsibityService service,[FromBody] ResponsibilityRequest request)
        {
            if (request.Id == Guid.Empty) return Results.BadRequest(nameof(request.Id));
            return Results.Ok(service.AddUpdate(request));
        }

        internal IResult DeleteResponsibitie([FromServices] IResponsibityService service, [FromRoute] Guid id)
        {
            var responsibity = service.Get(id);
            if (responsibity is not null)
            {
                service.Delete(id);
                return Results.Ok(responsibity);
            }
            return Results.NotFound(nameof(responsibity));
        }

        public void DefineServices(IServiceCollection services)
        {
            
        }
    }
}
