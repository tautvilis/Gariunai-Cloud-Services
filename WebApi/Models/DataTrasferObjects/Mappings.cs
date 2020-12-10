using AutoMapper;

namespace WebApi.Models.DataTransferObjects
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Shop, ShopDTO>().ReverseMap();

            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Produce, ProduceDTO>().ReverseMap();

            CreateMap<Notification, NotificationDTO>().ReverseMap();

            CreateMap<Follow, FollowDTO>().ReverseMap();
        }
    }
}