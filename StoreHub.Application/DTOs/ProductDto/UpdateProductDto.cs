﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.DTOs.ProductDto
{
	public class UpdateProductDto
    {
		public string Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int BrandId { get; set; }
		public int CategoryId { get; set; }
		public int StockQuantity { get; set; }
	}
}
