using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Entities
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int ParentCategoryId { get; set; }
		public ParentCategory? ParentCategory { get; set; }
		public ICollection<Product>? Products { get; set; }
	}
}
