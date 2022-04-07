using ResourceManagement.Repositories.Implement;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Endpionts
{
    public class ResourceEndpoints : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("/resources", GetResources);
            app.MapGet("/resource/{id}", GetResource);
            app.MapPost("/resource", CreateResource);
            app.MapPut("/resource", UpdateResource);
            app.MapDelete("/resource{id}", DeleteResource);
        }

        private IResult GetResource(IResourceService service,Guid id)
        {
            var resource = service.Get(id);
            return resource is not null ? Results.Ok(resource) : Results.NotFound();
        }

        internal async Task<List<ResourceResponse>> GetResources(IResourceService service)
        {
            return await service.GetAll();
        }

        internal IResult CreateResource(IResourceService service, ResourceRequest request)
        {
            request.Id = Guid.Empty;
            return Results.Ok(service.AddUpdate(request));
        }

        internal IResult UpdateResource(IResourceService service, ResourceRequest request)
        {
           if(request.Id == Guid.Empty) return Results.BadRequest(nameof(request.Id));
            return Results.Ok(service.AddUpdate(request));
        }

        internal IResult DeleteResource(IResourceService service, Guid id)
        {
            var resource = service.Get(id);
            if(resource is not null)
            {
               service.Delete(id);
               return Results.Ok(resource);
            }
            return Results.NotFound(nameof(resource));
        }

        public void DefineServices(IServiceCollection services)
        {
           services.AddTransient<IResourceService, ResourceReposity>();   
        }
    }
}
