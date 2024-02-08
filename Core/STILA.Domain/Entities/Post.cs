using STILA.Domain.Common;
using STILA.Domain.Identity;

namespace STILA.Domain.Entities
{
	public class Post : BaseEntity
	{
		public int UserId { get; set; }
		   
		public string PostText { get; set; }
		public string? PostImage { get; set; }

		public AppUser User { get; set; }
	}
}
