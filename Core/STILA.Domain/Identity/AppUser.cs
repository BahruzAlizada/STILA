using STILA.Domain.Entities;

namespace STILA.Domain.Identity
{
	public class AppUser
	{
		public string Image { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }

		public bool Verify { get; set; } = false;

		public ICollection<Post> Posts { get; set; }
	}
}
