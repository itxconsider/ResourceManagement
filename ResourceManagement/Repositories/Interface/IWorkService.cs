using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IWorkService
    {
        int Count();
        Task<WorkResponse?> Get(Guid id);
        Task<List<WorkResponse>> GetAll();
        Task<string> AddUpdate(WorkRequest request);
        void Delete(Guid id);
    }
}
