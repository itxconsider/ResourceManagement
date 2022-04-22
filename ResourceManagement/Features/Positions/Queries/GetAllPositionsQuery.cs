using MediatR;
using ResourceManagement.Repositories;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Features.Positions.Queries
{
    public class GetAllPositionsQuery : IRequest<PaginatedResult<PositionResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchString { get; set; }
        public string[]? OrderBy { get; set; }
        public GetAllPositionsQuery(int pageNumber, int pageSize, string? searchString, string? orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }
        internal class Hanlder : IRequestHandler<GetAllPositionsQuery, PaginatedResult<PositionResponse>>
        {
            private readonly IUnitOfWork<Guid> _unitOfWork;

            public Hanlder(IUnitOfWork<Guid> unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public Task<PaginatedResult<PositionResponse>> Handle(GetAllPositionsQuery request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
