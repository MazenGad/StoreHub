using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Entities
{
	public class ParentCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Category>? Categories { get; set; }
	}
}
