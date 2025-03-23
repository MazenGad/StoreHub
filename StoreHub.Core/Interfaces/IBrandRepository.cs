using StoreHub.Core.DTOs.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
	public interface IBrandRepository
    {
		Task<IEnumerable<BrandDto>> GetAllAsync();
		Task<BrandDto?> GetByIdAsync(int id);
		Task AddAsync(CreateBrandDto brandDto);
		Task UpdateAsync(int id, UpdateBrandDto brandDto);
		Task DeleteAsync(int id);
	}
}
