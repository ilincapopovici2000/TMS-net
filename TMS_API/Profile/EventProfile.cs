using AutoMapper;
using TMS_API.Models;
using TMS_API.Models.Dto;

namespace TMS_API.Profiles;
public class EventProfile : Profile
{
    public EventProfile()
    {
        CreateMap<Event, EventDto>().ReverseMap();
        CreateMap<Event, EventPatchDto>().ReverseMap();
    }
}

