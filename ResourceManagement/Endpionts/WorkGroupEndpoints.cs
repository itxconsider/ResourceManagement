using ResourceManagement.Repositories.Implement;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;

namespace ResourceManagement.Endpionts
{
    public class WorkGroupEndpoints : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            app.MapGet("/work-group/{id}", GetWorkGroup);
            app.MapGet("/work-groups", GetWorkGroups);
            app.MapPost("/work-group", CreateWorkGroup);
            app.MapPut("/work-group", UpdateWorkGroup);
            app.MapDelete("/work-group/{id}", DeleteWorkGroup);
        }

        internal IResult GetWorkGroup(IWorkGroupService service, Guid id)
        {
            var result = service.Get(id);
            return result is not null ? Results.Ok(result) : Results.NotFound();
        }

        internal IResult GetWorkGroups(IWorkGroupService service) => Results.Ok(service.GetAll());
        internal IResult CreateWorkGroup(IWorkGroupService service, WorkGroupRequest request)
        {
            request.Id = Guid.Empty;
            return Results.Ok(service.AddUpdate(request));
        }

        internal IResult UpdateWorkGroup(IWorkGroupService service, WorkGroupRequest request)
        {
            if(request.Id == Guid.Empty)   return Results.BadRequest();
            return Results.Ok(service.AddUpdate(request));
        }

        internal IResult DeleteWorkGroup(IWorkGroupService service, Guid id)
        {
            var workGroup = service.Get(id);
            if (workGroup is not null)
            {
                service.Delete(id);
                return Results.Ok(workGroup);
            }
            return Results.NotFound(nameof(workGroup));
        }
        public void DefineServices(IServiceCollection services)
        {
            services.AddScoped<IWorkGroupService, WorkGroupRepository>();
        }
    }
}
