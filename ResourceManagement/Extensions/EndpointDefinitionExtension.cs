using ResourceManagement.EndpiontDefinitions;

namespace ResourceManagement.Extensions
{
    public static class EndpointDefinitionExtension
    {
        public static void AddEndpointDefinitions(this IServiceCollection services, params Type[] scanMarkers)
        {
            var endpointDefintions = new List<IEndpointDefinition>();
            foreach (var scanMarker in scanMarkers)
            {
                endpointDefintions.AddRange(scanMarker.Assembly.ExportedTypes
                    .Where(e => typeof(IEndpointDefinition).IsAssignableFrom(e) && !e.IsInterface && !e.IsAbstract)
                    .Select(Activator.CreateInstance).Cast<IEndpointDefinition>());
            }
            foreach (var endpointDefintion in endpointDefintions) 
            {
                endpointDefintion.DefineServices(services);
            }

            services.AddSingleton(endpointDefintions as IReadOnlyCollection<IEndpointDefinition>);
        }
        public static void UseEndpiontDefinitions(this WebApplication app)
        {
            var defintions = app.Services.GetRequiredService<IReadOnlyCollection<IEndpointDefinition>>();
            foreach (var defintion in defintions)
            {
                defintion.DefineEndtpoints(app);
            }
        }
    }
}
 