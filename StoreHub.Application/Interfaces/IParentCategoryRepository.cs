using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
    public interface IParentCategoryRepository
    {
		Task<IEnumerable<ParentCategory>> GetAllAsync();
		Task<ParentCategory?> GetByIdAsync(int id);
		Task AddAsync(ParentCategory parentCategoryDto);
		Task UpdateAsync(ParentCategory parentCategoryDto);
		Task DeleteAsync(int id);
	}
}
