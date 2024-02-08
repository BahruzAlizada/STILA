using STILA.Application.Abstract;
using STILA.Application.Repositories;
using STILA.Domain.Entities;
using STILA.Persistence.Concrete;
using STILA.Persistence.Repositories;

namespace STILA.Persistence.EntityFramework
{
	public class PostWriteRepository : WriteRepository<Post>, IPostWriteRepository
	{
		public async Task ActivityAsync(Post post)
		{
			using var context = new Context();

			if (post.Status)
				post.Status = false;
			else
				post.Status=true;

			await context.SaveChangesAsync();
		}
	}
}
