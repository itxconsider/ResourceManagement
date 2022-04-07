using AutoMapper;
using ResourceManagement.Models;
using Shared.Models.Request;
using Shared.Models.Response;

namespace ResourceManagement.Mappers
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<WorkResponse, Work>().ReverseMap();
            CreateMap<WorkRequest, Work>().ReverseMap();
        }
    }
}
