using Shared.Extensions;
using Shared.Models.Request;
using Shared.Models.Response;
using Shared.Utilities;
using Web.Client.Routes;

namespace Web.Client.Managers.Department
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly HttpClient _httpClient;

        public DepartmentManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public DepartmentManager()
        {

        }
        public Task<IResult<Guid>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IResult<string>> ExportToExcelAsync(string searchString = "")
        {
            throw new NotImplementedException();
        }

        public Task<IResult<List<DepartmentResponse>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PaginatedResult<DepartmentResponse>> GetAllDepartmentsAsync(GetAllPagedDepartmentRequest request)
        {
            HttpResponseMessage? response = await _httpClient.GetAsync(CustomerEndpoint.GetAllPaged(request.PageNumber, request.PageSize, request.SearchString, request.Orderby));
            return await response.ToPaginatedResult<DepartmentResponse>();
        }

        public Task<IResult<Guid>> SaveAsync(DepartmentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
