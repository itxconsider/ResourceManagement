using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IResponsibityService
    {
        Task<ResponsibilityResponse?> Get(Guid id);
        Task<List<ResponsibilityResponse>> GetAll();
        Task<string> AddUpdate(ResponsibilityRequest request);
        void Delete(Guid id);
    }
}
