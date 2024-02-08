using STILA.Application.Repositories;
using STILA.Domain.Entities;

namespace STILA.Application.Abstract
{
	public interface IPostWriteRepository : IWriteRepository<Post>
	{
		Task ActivityAsync(Post post);
	}
}
