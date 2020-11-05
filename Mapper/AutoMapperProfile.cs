using AutoMapper;
using HashtagManager.Models;

namespace HashtagManager.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
