using STILA.Application.Abstract;
using STILA.Domain.Entities;
using STILA.Persistence.Repositories;

namespace STILA.Persistence.EntityFramework
{
	public class GenderReadRepository :ReadRepository<Gender>,IGenderReadRepository
	{
	}
}
