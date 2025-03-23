using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.DTOs.CategoryDto
{
    public class UpdateCategoryDto
    {
		public string Name { get; set; }
		public int ParentCategoryId { get; set; }

	}
}
