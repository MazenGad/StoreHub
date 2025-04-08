using StoreHub.Application.DTOs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.DTOs.CategoryDto
{
	public class GetCategoryDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public int ParentCategoryId { get; set; }
		public ICollection<GetProductDto>? Products { get; set; }
	}
}
