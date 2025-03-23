using StoreHub.Core.DTOs.ParentCategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
    public interface IParentCategoryRepository
    {
		Task<IEnumerable<GetParentCategoryDto>> GetAllAsync();
		Task<GetParentCategoryDto?> GetByIdAsync(int id);
		Task AddAsync(AddParentCategoryDto parentCategoryDto);
		Task UpdateAsync(int id, UpdateParentCategoryDto parentCategoryDto);
		Task DeleteAsync(int id);
	}
}
