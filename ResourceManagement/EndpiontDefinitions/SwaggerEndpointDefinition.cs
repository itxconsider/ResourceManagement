namespace ResourceManagement.EndpiontDefinitions
{
    public class SwaggerEndpointDefinition : IEndpointDefinition
    {
        public void DefineEndtpoints(WebApplication app)
        {
            // Configure the HTTP request pipeline.
           
             app.UseSwagger();    
             app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Resource Managment"));
        }

        public void DefineServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new()
                {
                    Title = "Resource Management API",
                    Version = "v1"
                });
            });
        }
    }
}
