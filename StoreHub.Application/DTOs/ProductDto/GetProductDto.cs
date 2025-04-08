using StoreHub.Application.DTOs.ProductImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.DTOs.ProductDto
{
	public class GetProductDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public bool IsAvailable { get; set; }
		public int BrandId { get; set; }
		public int CategoryId { get; set; }

		public string BrandName { get; set; }
		public string CategoryName { get; set; }

		public DateTime CreatedAt { get; set; } 
		public DateTime UpdatedAt { get; set; }
		public string? MainImageUrl { get; set; } 
		public ICollection<GetProductImageDto>? ProductImages { get; set; }
	}
}
