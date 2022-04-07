using ResourceManagement.Serializers;
using System.Text.Json;


namespace ResourceManagement.Serialization.Options
{
    public class SystemTextJsonOptions : IJsonSerializerOptions
    {
        public JsonSerializerOptions JsonSerializerOptions { get; } = new();

     }
}