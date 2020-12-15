using AutoMapper;

namespace WebApi.Models.DataTransferObjects
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Shop, ShopDto>().ReverseMap();

            CreateMap<User, UserDto>().ReverseMap();

            CreateMap<Produce, ProduceDto>().ReverseMap();

            CreateMap<Notification, NotificationDto>().ReverseMap();

            CreateMap<Follow, FollowDto>().ReverseMap();
        }
    }
}