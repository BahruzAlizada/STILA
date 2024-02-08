using AutoMapper;
using STILA.Application.DTOs.Category;
using STILA.Application.DTOs.Gender;
using STILA.Domain.Entities;

namespace STILA.Application.Mappers.AutoMapper
{
	public class DtoMapper : Profile
	{
        public DtoMapper()
        {
            CreateMap<Category,CategoryAddDto>().ReverseMap();
            CreateMap<Gender,GenderAddDto>().ReverseMap();
        }
    }
}
