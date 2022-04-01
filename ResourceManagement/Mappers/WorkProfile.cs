using AutoMapper;
using ResourceManagement.Models;
using ResourceManagement.Request;
using ResourceManagement.Response;

namespace ResourceManagement.Mappers
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<WorkResponse, Working>().ReverseMap();
            CreateMap<WorkRequest, Working>().ReverseMap();
        }
    }
}
