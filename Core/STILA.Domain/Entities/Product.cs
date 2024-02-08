using STILA.Domain.Common;

namespace STILA.Domain.Entities
{
	public class Product : BaseEntity
	{
		public int CategoryId { get; set; }
		public int GenderId { get; set; }

		public string Name { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }

		public Category Category { get; set; }
		public Gender Gender { get; set; }
	}
}
