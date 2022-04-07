using Newtonsoft.Json;
using ResourceManagement.Serializers;

namespace ResourceManagement.Serialization.Settings
{
    public class NewtonsoftJsonSettings : IJsonSerializerSettings
    {
        public JsonSerializerSettings JsonSerializerSettings { get; } = new();
    }
}