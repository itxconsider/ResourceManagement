using AutoMapper;
using MediatR;
using ResourceManagement.Constants;
using ResourceManagement.Models;
using ResourceManagement.Repositories;
using Shared.Models.Response;
using Shared.Utilities;

namespace ResourceManagement.Features.Departments.Commands
{
    public class AddUpdateDepartmentCommand : IRequest<IResult<DepartmentResponse>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; } = Guid.NewGuid().ToString();

        public AddUpdateDepartmentCommand(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }   
        internal class Hanlder : IRequestHandler<AddUpdateDepartmentCommand, IResult<DepartmentResponse>>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork<Guid> _unitOfWork;
            public Hanlder(IMapper mapper, IUnitOfWork<Guid> unitOfWork)
            {
                _mapper = mapper;
                _unitOfWork = unitOfWork;
            }
           
            public async Task<IResult<DepartmentResponse>> Handle(AddUpdateDepartmentCommand request, CancellationToken cancellationToken)
            {
                if (request.Id.Equals(Guid.Empty))
                {
                    var dep = _mapper.Map<Department>(request);
                    await _unitOfWork.Repository<Department>().AddAsync(dep);
                    _unitOfWork.Commit();
                    return await Result<DepartmentResponse>.SuccessAsync("record has been added.");
                }
                else
                {
                    var dep = await _unitOfWork.Repository<Department>().GetByIdAsync(request.Id);
                    if(dep != null)
                    {
                        dep.Name = request.Name ?? dep.Name;
                        dep.Description = request.Description ?? dep.Description;
                        dep.CreatedBy = request.CreatedBy ?? dep.CreatedBy;
                        await _unitOfWork.Repository<Department>().UpdateAsync(dep);
                        await _unitOfWork.CommitAndRemoveCacheAsync(cancellationToken, ApplicationConstants.Cache.GetAllDepartmentsCacheKey);
                        return await Result<DepartmentResponse>.SuccessAsync("record has been updated.");
                    }
                    return await Result<DepartmentResponse>.FailAsync("record not found.");

                }
            }
        }
    }
}
