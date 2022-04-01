using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IResource
    {
        Task<ResourceResponse> Get(string id);
        Task<List<ResourceResponse>> GetAll();
        Task<string> AddUpdate(ResourceRequest request);
        void Delete(string id);
    }
}
