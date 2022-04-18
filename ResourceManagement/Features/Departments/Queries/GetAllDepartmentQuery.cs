using MediatR;
using ResourceManagement.Extensions;
using ResourceManagement.Models;
using ResourceManagement.Repositories;
using ResourceManagement.Specifications.Catalog;
using Shared.Models.Response;
using Shared.Utilities;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;

namespace ResourceManagement.Features.Departments.Queries
{
    public class GetAllDepartmentQuery : IRequest<PaginatedResult<DepartmentResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchString { get; set; }
        public string[]? OrderBy { get; set; }
        public GetAllDepartmentQuery(int pageNumber, int pageSize, string? searchString, string? orderBy)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                OrderBy = orderBy.Split(',');
            }
        }

        public class Handler : IRequestHandler<GetAllDepartmentQuery, PaginatedResult<DepartmentResponse>>
        {
            private readonly IUnitOfWork<Guid> _unit;

            public Handler(IUnitOfWork<Guid> unit)
            {
                _unit = unit;
            }

            public async Task<PaginatedResult<DepartmentResponse>> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
            {
               Expression<Func<Department,DepartmentResponse>> expression = e => new DepartmentResponse
               {
                   Id = e.Id,
                   Name = e.Name,
                   Description = e.Description
               };

                var filterSpecification = new DepartmentFilterSpecification(request.SearchString);
                if(request.OrderBy?.Any() != true)
                {
                    var data = await _unit.Repository<Department>().Entities
                        .Specify(filterSpecification)
                        .Select(expression)
                        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return data;
                }
                else
                {
                    var ordering = string.Join(",", request.OrderBy); // of the form field name [ascending|descending], ...
                    var data = await _unit.Repository<Department>().Entities
                        .Specify(filterSpecification)
                        .OrderBy(ordering) // require system.linq.dynamic.core
                        .Select(expression)
                        .ToPaginatedListAsync(request.PageNumber, request.PageSize);
                    return data;
                }
            }
        }
    }
}
