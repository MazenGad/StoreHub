using StoreHub.Core.DTOs.ProductDto;
using StoreHub.Core.DTOs.ProductImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Core.Interfaces
{
	public interface IProductRepository
    {
		Task<IEnumerable<GetProductDto>> GetAllAsync();
		Task<GetProductDto?> GetByIdAsync(int id);
		Task AddAsync(CreateProductDto productDto);
		Task UpdateAsync(int id, UpdateProductDto productDto);
		Task DeleteAsync(int id);

		// Images
		Task AddProductImagesAsync( IEnumerable<UpdateProductImageDto> imageUrls);
		Task RemoveProductImageAsync(int imageId);


	}
}
