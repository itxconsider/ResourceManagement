using MediatR;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Repositories.Implement
{
    public class PositionRepository : IPositionService
    {
        private readonly IMediator _mediator;

        public PositionRepository(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<string> AddUpdate(PositionRequest request)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PositionResponse> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<PositionResponse>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
