using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using StoreHub.Core.DTOs.ProductDto;
using StoreHub.Core.DTOs.ProductImageDto;
using StoreHub.Core.Entities;
using StoreHub.Core.Interfaces;
using StoreHub.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Infrastructure.Repositories
{
   public class ProductRepository : IProductRepository
	{
        private StoreHubDb _context;
		private IMapper _mapper;

		public ProductRepository(StoreHubDb context , IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddAsync(CreateProductDto productDto)
		{
			var product = _mapper.Map<CreateProductDto, Product>(productDto);
			product.UpdateStock(productDto.StockQuantity);
			await _context.Products.AddAsync(product);
			await _context.SaveChangesAsync();
		}

		public async Task AddProductImagesAsync( IEnumerable<UpdateProductImageDto> imageUrls)
		{
			var productImages = _mapper.Map<IEnumerable<ProductImages>>(imageUrls);
			await _context.ProductImages.AddRangeAsync(productImages);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var deletedProduct = await _context.Products.FindAsync(id);

			if (deletedProduct == null)
			{
				throw new Exception("Product not found");
			}

			_context.Products.Remove(deletedProduct);
			await _context.SaveChangesAsync();

		}

		public async Task<IEnumerable<GetProductDto>> GetAllAsync()
		{
			var products = await _context.Products
				.Include(p => p.ProductImages)
				.ProjectTo<GetProductDto>(_mapper.ConfigurationProvider)
				.ToListAsync();

			if (products == null)
			{
				throw new Exception("Products not found");

			}

			return _mapper.Map(products, new List<GetProductDto>());
		}

		public async Task<GetProductDto?> GetByIdAsync(int id)
		{
			var product = await _context.Products
				.Include(p => p.ProductImages)
				.Where(p => p.Id == id)
				.ProjectTo<GetProductDto>(_mapper.ConfigurationProvider) 
				.FirstOrDefaultAsync();

			if (product == null)
			{
				throw new Exception("Product not found");
			}

			return product;
		}

		public async Task RemoveProductImageAsync(int imageId)
		{
			var productImage = await _context.ProductImages.FindAsync(imageId);

			if (productImage == null)
			{
				throw new Exception("Product Image not found");
			}

			_context.ProductImages.Remove(productImage);

			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(int id, UpdateProductDto productDto)
		{
			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				throw new Exception("Product not found");
			}

			_mapper.Map(productDto, product);
			product.UpdateStock(productDto.StockQuantity);

			await _context.SaveChangesAsync();

		}
	}
}
