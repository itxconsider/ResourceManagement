using Shared.Models.Request;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Repositories.Interface
{
    public interface IDepartmentService
    {
        Task<IResult<DepartmentResponse>> Get(Guid id);
        Task<PaginatedResult<DepartmentResponse>> GetAll(int pageNumber, int pageSize, string? searchString = null, string? orderBy = null);
        Task<IResult<DepartmentResponse>> AddUpdate(DepartmentRequest request);
        Task<IResult<Guid>> Delete(Guid id);
    }
}
