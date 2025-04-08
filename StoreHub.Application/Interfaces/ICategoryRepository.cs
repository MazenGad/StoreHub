using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
	public interface ICategoryRepository
    {
		Task<IEnumerable<Category>> GetAllAsync();
		Task<Category?> GetByIdAsync(int id);
		Task AddAsync(Category categoryDto);
		Task UpdateAsync(Category categoryDto);
		Task DeleteAsync(int id);
	}
}
