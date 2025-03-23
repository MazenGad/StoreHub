using StoreHub.Core.DTOs.ProductImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.DTOs.ProductDto
{
	public class CreateProductDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int StockQuantity { get; set; }
		public int BrandId { get; set; }
		public int CategoryId { get; set; }
		public ICollection<GetProductImageDto>? ProductImages { get; set; }
	}
}
