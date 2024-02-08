using STILA.Application.DTOs.Gender;
using STILA.Application.Repositories;
using STILA.Domain.Entities;

namespace STILA.Application.Abstract
{
	public interface IGenderWriteRepository : IWriteRepository<Gender>
	{
		Task AddDtoAsync(GenderAddDto genderAddDto);
		Task ActivityAsync(Gender gender);
	}
}
