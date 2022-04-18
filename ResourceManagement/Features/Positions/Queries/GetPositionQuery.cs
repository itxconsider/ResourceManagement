using MediatR;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Features.Positions.Queries
{
    public class GetPositionQuery : IRequest<IResult<PositionResponse>>
    {
    }
}
