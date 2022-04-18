using AutoMapper;
using MediatR;
using ResourceManagement.Models;
using ResourceManagement.Repositories;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Features.Departments.Queries
{
    public class GetByIdDepartmentQuery : IRequest<IResult<DepartmentResponse>>
    {
        private Guid id;

        public GetByIdDepartmentQuery(Guid id)
        {
            this.id = id;
        }

        public class Handler : IRequestHandler<GetByIdDepartmentQuery, IResult<DepartmentResponse>>
        {

            private readonly IUnitOfWork<Guid> _unitOfWork;
            private readonly IMapper _mapper;

            public Handler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<IResult<DepartmentResponse>> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
            {
                var department = await _unitOfWork.Repository<Department>().GetByIdAsync(request.id);
                if (department == null) return Result<DepartmentResponse>.Fail("record not found.");
                var map = _mapper.Map<DepartmentResponse>(department);
                return Result<DepartmentResponse>.Success(map);
            }
        }

    }
}
