using AutoMapper;
using TMS_API.Models;
using TMS_API.Models.Dto;

namespace TMS_API.Profiles;
public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<Order, OrderDto>().ReverseMap();
        CreateMap <Order, OrderPatchDto > ().ReverseMap();
        CreateMap<OrderDto, OrderPostDto>().ReverseMap();
        CreateMap<OrderPostDto,Order>().ForMember(x => x.OrderedAt ,y =>y.MapFrom(_ => DateTime.Now)).ReverseMap();
    }
}

