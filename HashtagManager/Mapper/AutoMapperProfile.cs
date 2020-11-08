using AutoMapper;
using HashtagManager.Domain.DTO.Model;
using HashtagManager.Domain.Entities.Model;

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
