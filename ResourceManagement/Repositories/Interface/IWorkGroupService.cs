using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IWorkGroupService
    {
        Task<WorkGroupResponse?> Get(Guid id);
        Task<List<WorkGroupResponse>> GetAll();
        Task<string> AddUpdate(WorkGroupRequest request);
        void Delete(Guid id);
    }
}
