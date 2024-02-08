using STILA.Domain.Common;

namespace STILA.Domain.Entities
{
	public class Gender : BaseEntity
	{
		public string Name { get; set; }
		public ICollection<Gender> Genders { get; set;}
	}
}
