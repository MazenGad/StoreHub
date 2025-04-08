using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
	public interface IBrandRepository
    {
		Task<IEnumerable<Brand>> GetAllAsync();
		Task<Brand?> GetByIdAsync(int id);
		Task AddAsync(Brand brandDto);
		Task UpdateAsync( Brand brandDto);
		Task DeleteAsync(int id);
	}
}
