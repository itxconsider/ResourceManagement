using Shared.Models.Request;
using Shared.Models.Response;
using Shared.Utilities;

namespace Web.Client.Managers
{
    public interface IDepartmentManager : IManager
    {
        Task<PaginatedResult<DepartmentResponse>> GetAllDepartmentsAsync(GetAllPagedDepartmentRequest request);

        Task<IResult<Guid>> SaveAsync(DepartmentRequest request);

        Task<IResult<Guid>> DeleteAsync(Guid id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
        Task<IResult<List<DepartmentResponse>>> GetAllAsync();
    }
}
