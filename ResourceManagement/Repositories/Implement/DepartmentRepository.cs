using MediatR;
using ResourceManagement.Features.Departments.Commands;
using ResourceManagement.Features.Departments.Queries;
using ResourceManagement.Repositories.Interface;
using Shared.Models.Request;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Repositories.Implement
{
    public class DepartmentRepository : IDepartmentService
    {

        private readonly IMediator _mediator;

        public DepartmentRepository(IMediator mediator)
        {

            _mediator = mediator;
        }

        public async Task<IResult<DepartmentResponse>> AddUpdate(DepartmentRequest request)
        {
            if(request == null) throw new ArgumentNullException(nameof(request));
        
            return await _mediator.Send(new AddUpdateDepartmentCommand(request.Id, request.Name, request.Description));
        }

        public  async Task<IResult<Guid>> Delete(Guid id)
        {
            if (id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            return await  _mediator.Send(new DeleteDepartmentCommand(id));
        }

        public async Task<IResult<DepartmentResponse>> Get(Guid id)
        {
            if(id.Equals(Guid.Empty)) throw new ArgumentNullException(nameof(id));
            return await _mediator.Send(new GetByIdDepartmentQuery(id));        
        }

        public async Task<PaginatedResult<DepartmentResponse>> GetAll(int pageNumber, int pageSize, string? searchString, string? orderBy = null)
        {
            return await _mediator.Send(new GetAllDepartmentQuery(pageNumber, pageSize, searchString, searchString));
        }
    }
}
