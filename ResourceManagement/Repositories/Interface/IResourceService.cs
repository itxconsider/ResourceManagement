using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IResourceService
    {
        Task<ResourceResponse?> Get(Guid id);
        Task<List<ResourceResponse>> GetAll();
        Task<string> AddUpdate(ResourceRequest request);
        void Delete(Guid id);
    }
}
