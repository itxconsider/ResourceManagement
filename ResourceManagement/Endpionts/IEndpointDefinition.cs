namespace ResourceManagement.Endpionts
{
    public interface IEndpointDefinition
    {
        void DefineEndtpoints(WebApplication app);
        void DefineServices(IServiceCollection services);
    }
}