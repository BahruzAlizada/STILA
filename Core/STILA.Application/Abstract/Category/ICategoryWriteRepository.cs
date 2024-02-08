using STILA.Application.Repositories;
using STILA.Domain.Entities;

namespace STILA.Application.Abstract
{
	public interface ICategoryWriteRepository : IWriteRepository<Category>
	{
		Task ActivityAsync(Category category);
	}
}
