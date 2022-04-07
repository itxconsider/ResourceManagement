using AutoMapper;
using ResourceManagement.Models;
using Shared.Models.Request;
using Shared.Models.Response;

namespace Shared.Models.Mappers
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentResponse>().ReverseMap();
            CreateMap<Department, DepartmentRequest>().ReverseMap();
        }
    }
}
