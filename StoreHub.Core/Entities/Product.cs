using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Entities
{
	public class Product
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; private set; }
		public bool IsAvailable { get; private set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
		public int CategoryId { get; set; }
		public Category? Category { get; set; }
		public int BrandId { get; set; }
		public Brand? Brand { get; set; }

		public ICollection<ProductImages>? ProductImages { get; set; }

		public void UpdateStock(int quantity)
		{
			StockQuantity = quantity;
			IsAvailable = StockQuantity > 0;
		}
	}
}
