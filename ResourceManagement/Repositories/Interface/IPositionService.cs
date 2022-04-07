using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IPositionService
    {
        Task<PositionResponse> Get(Guid id);
        Task<List<PositionResponse>> GetAll();
        Task<string> AddUpdate(PositionRequest request);
        void Delete(Guid id);
    }
}
