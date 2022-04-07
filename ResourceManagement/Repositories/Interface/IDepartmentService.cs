using Shared.Models.Request;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Repositories.Interface
{
    public interface IDepartmentService
    {
        Task<IResult<DepartmentResponse>> Get(Guid id);
        Task<PaginatedResult<DepartmentResponse>> GetAll();
        Task<IResult<DepartmentResponse>> AddUpdate(DepartmentRequest request);
        void Delete(Guid id);
    }
}
