
namespace STILA.Domain.Common
{
	public class BaseEntity
	{
		public int Id { get; set; }
		public bool Status { get; set; } = false;
		public DateTime Created { get; set; } = DateTime.UtcNow.AddHours(4);
	}
}
