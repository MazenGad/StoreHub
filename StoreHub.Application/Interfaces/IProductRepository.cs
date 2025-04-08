using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
	public interface IProductRepository
    {
		Task<IEnumerable<Product>> GetAllAsync();
		Task<Product?> GetByIdAsync(int id);
		Task AddAsync(Product productDto);
		Task UpdateAsync( Product productDto);
		Task DeleteAsync(int id);

		// Images
		Task AddProductImagesAsync( IEnumerable<ProductImages> imageUrls);
		Task RemoveProductImageAsync(int imageId);


	}
}
