using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Entities
{
	public class Brand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? LogoUrl { get; set; }

		public ICollection<Product>? Products { get; set; }
	}
}
