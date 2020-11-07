using AutoMapper;
using HashtagManager.Models;

namespace HashtagManager.Mapper
{
		public class AutoMapperProfile : Profile 
		{
			public AutoMapperProfile() 
			{
				CreateMap<Posteador, PosteadorDTO>().ReverseMap();
				CreateMap<User, UserDTO>().ReverseMap();
			}
		}
}
