using StoreHub.Application.DTOs.ProductDto;
using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.DTOs.BrandDto
{
    public class BrandDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string? LogoUrl { get; set; }

		public ICollection<GetProductDto>? Products { get; set; }
	}
}
