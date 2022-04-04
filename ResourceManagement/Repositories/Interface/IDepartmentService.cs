using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IDepartmentService
    {
        Task<DepartmentResponse?> Get(Guid id);
        Task<List<DepartmentResponse>> GetAll();
        Task<string> AddUpdate(DepartmentRequest request);
        void Delete(Guid id);
    }
}
