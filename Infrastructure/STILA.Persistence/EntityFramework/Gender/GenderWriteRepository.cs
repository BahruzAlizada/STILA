using AutoMapper;
using STILA.Application.Abstract;
using STILA.Application.DTOs.Gender;
using STILA.Domain.Entities;
using STILA.Persistence.Concrete;
using STILA.Persistence.Repositories;

namespace STILA.Persistence.EntityFramework
{
	public class GenderWriteRepository : WriteRepository<Gender>, IGenderWriteRepository
	{
		private readonly IMapper mapper;
        public GenderWriteRepository(IMapper mapper)
        {
			this.mapper= mapper;	
        }

        public async Task ActivityAsync(Gender gender)
		{
			using var context = new Context();
			if (gender.Status)
				gender.Status = false;
			else
				gender.Status = true;

			await context.SaveChangesAsync();
		}

		public async Task AddDtoAsync(GenderAddDto genderAddDto)
		{
			using var context = new Context();
			Gender gender = mapper.Map<Gender>(genderAddDto);
			await context.SaveChangesAsync();
		}
	}
}
