using ResourceManagement.Repositories.Interface;
using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Repositories.Implement
{
    public class ResponsibilityRepository : IResponsibityService
    {
        public Task<string> AddUpdate(ResponsibilityRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponsibilityResponse?> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResponsibilityResponse>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
