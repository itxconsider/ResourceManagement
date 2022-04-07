using Shared.Models.Request;
using Shared.Models.Response;

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
