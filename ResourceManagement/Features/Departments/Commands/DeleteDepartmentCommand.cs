using MediatR;
using ResourceManagement.Models;
using ResourceManagement.Repositories;
using Shared.Utilities;

namespace ResourceManagement.Features.Departments.Commands
{
    public class DeleteDepartmentCommand : IRequest<IResult<Guid>>
    {
        private Guid id;

        public DeleteDepartmentCommand(Guid id)
        {
            this.id = id;
        }
        public class Handler : IRequestHandler<DeleteDepartmentCommand, IResult<Guid>>
        {
            private IUnitOfWork<Guid> _unitOfWork;

            public Handler(IUnitOfWork<Guid> unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public async Task<IResult<Guid>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
            {
                var department = await _unitOfWork.Repository<Department>().GetByIdAsync(request.id);
                if (department is null) return Result<Guid>.Fail("record not found.");
                await _unitOfWork.Repository<Department>().DeleteAsync(department);
                await _unitOfWork.CommitAsync(cancellationToken);
                return Result<Guid>.Success();
            }
        }
    }
}
