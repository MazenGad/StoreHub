using StoreHub.Core.DTOs.CategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
	public interface ICategoryRepository
    {
		Task<IEnumerable<GetCategoryDto>> GetAllAsync();
		Task<GetCategoryDto?> GetByIdAsync(int id);
		Task AddAsync(AddCategoryDto categoryDto);
		Task UpdateAsync(int id, UpdateCategoryDto categoryDto);
		Task DeleteAsync(int id);
	}
}
