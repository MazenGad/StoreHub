using StoreHub.Application.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.DTOs.ParentCategoryDto
{
	public class GetParentCategoryDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<GetCategoryDto>? Categories { get; set; }

	}
}
