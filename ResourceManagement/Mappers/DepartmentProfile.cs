using AutoMapper;
using ResourceManagement.Models;
using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Mappers
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
