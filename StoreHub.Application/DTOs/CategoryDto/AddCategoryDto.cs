using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.DTOs.CategoryDto
{
	public class AddCategoryDto
    {
		public string Name { get; set; }
		public int ParentCategoryId { get; set; }
	}
}
