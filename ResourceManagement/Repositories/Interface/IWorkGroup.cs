using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IWorkGroup
    {
        Task<WorkGroupResponse> Get(string id);
        Task<List<WorkGroupResponse>> GetAll();
        Task<string> AddUpdate(WorkGroupRequest request);
        void Delete(string id);
    }
}
