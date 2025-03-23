using Microsoft.AspNetCore.Mvc;
using StoreHub.Core.DTOs.ProductDto;
using StoreHub.Core.DTOs.ProductImageDto;
using StoreHub.Core.Interfaces;

namespace StoreHub.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : Controller
    {
		private IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository) 
		{
			_productRepository = productRepository;
		}

		[HttpGet("GetAll")]

		public async Task<IActionResult> GetProducts()
		{
			var products = await _productRepository.GetAllAsync();

			if(products == null)
			{
				return NotFound();
			}

			return Ok(products);
		}

		[HttpGet("GetProductById{id}")]

		public async Task<IActionResult> GetProduct(int id)
		{
			var product = await _productRepository.GetByIdAsync(id);
			if(product == null) {
				return NotFound();
			}
			return Ok(product);
		}

		[HttpPost("AddProduct")]
		public async Task<IActionResult> AddProduct([FromBody] CreateProductDto productDto)
		{
			await _productRepository.AddAsync(productDto);
			return Ok();
		}
	

		[HttpPut("UpdateProductById{id}")]
		public async Task<IActionResult> UpdateProduct(int id , [FromBody] UpdateProductDto productDto)
		{
			await _productRepository.UpdateAsync(id, productDto);
			return Ok();
		}

		[HttpDelete("DeleteProduct{id}")]
		public async Task<IActionResult> DeleteProduct(int id)
		{
			if (id == 0)
			{
				return NotFound();
			}

			return Ok();
		}

		[HttpPost("AddProductImages{id}")]

		public async Task<IActionResult> AddProductImages( [FromBody] IEnumerable<UpdateProductImageDto> imageUrls)
		{
			await _productRepository.AddProductImagesAsync( imageUrls);
			return Ok();
		}

		[HttpDelete("DeleteProductImage")]

		public async Task<IActionResult> DeleteProductImage(int ImageId)
		{
			await _productRepository.RemoveProductImageAsync( ImageId);
			return Ok();
		}

	

	}
}
