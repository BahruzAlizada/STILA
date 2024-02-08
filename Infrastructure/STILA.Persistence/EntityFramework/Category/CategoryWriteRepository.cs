using STILA.Application.Abstract;
using STILA.Application.Repositories;
using STILA.Domain.Entities;
using STILA.Persistence.Concrete;
using STILA.Persistence.Repositories;

namespace STILA.Persistence.EntityFramework
{
	public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
	{
		public async Task ActivityAsync(Category category)
		{
			using var context = new Context();

			if (category.Status)
				category.Status = false;
			else
				category.Status = true;

			await context.SaveChangesAsync();
		}
	}
}
