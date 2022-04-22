using AutoMapper;
using MediatR;
using ResourceManagement.Models;
using ResourceManagement.Repositories;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Features.Positions.Queries
{
    public class GetPositionQuery : IRequest<IResult<PositionResponse>>
    {
        private readonly Guid Id;

        public GetPositionQuery(Guid id)
        {
            Id = id;
        }
        internal class Handler : IRequestHandler<GetPositionQuery, IResult<PositionResponse>>
        {
            private readonly IUnitOfWork<Guid> _unitOfWork;
            private readonly IMapper _mapper;

            internal Handler(IUnitOfWork<Guid> unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public async Task<IResult<PositionResponse>> Handle(GetPositionQuery request, CancellationToken cancellationToken)
            {
                var department = await _unitOfWork.Repository<Position>().GetByIdAsync(request.Id);
                if (department == null) return Result<PositionResponse>.Fail("record not found.");
                var map = _mapper.Map<PositionResponse>(department);
                return Result<PositionResponse>.Success(map);
            }
        }
    }
}
