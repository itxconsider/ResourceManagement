using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Interface
{
    public interface IPosition
    {
        Task<PositionResponse> Get(Guid id);
        Task<List<PositionResponse>> GetAll();
        Task<string> AddUpdate(PositionRequest request);
        void Delete(string id);
    }
}
