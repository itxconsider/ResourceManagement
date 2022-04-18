using Newtonsoft.Json;
using System.Text.Json;

namespace ResourceManagement.Serializers
{
    public interface IJsonSerializerOptions
    {
         /// <summary>
        /// Options for <see cref="System.Text.Json"/>.
        /// </summary>
        public JsonSerializerOptions JsonSerializerOptions { get; }
    }
}
