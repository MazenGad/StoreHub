using Microsoft.AspNetCore.Mvc;
using StoreHub.Core.DTOs.BrandDto;
using StoreHub.Core.Interfaces;

namespace StoreHub.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BrandController : Controller
    {
		private IBrandRepository _brandRepository;

		public BrandController(IBrandRepository brandRepository)
		{
			_brandRepository = brandRepository;
		}

		[HttpGet("GetBrands")]
		public async Task<IActionResult> GetBrands()
		{
			var brands = await _brandRepository.GetAllAsync();

			if(brands == null)
			{
				return NotFound();
			}

			return Ok(brands);
		}

		[HttpPost("AddBrand")]
		public async Task<IActionResult> AddBrand([FromBody] CreateBrandDto brandDto)
		{
			await _brandRepository.AddAsync(brandDto);
			return Ok();
		}

		[HttpDelete("DeleteBrand/{id}")]
		public async Task<IActionResult> DeleteBrand(int id)
		{
			await _brandRepository.DeleteAsync(id);
			return Ok();
		}

		[HttpGet("GetBrandById/{id}")]
		public async Task<IActionResult> GetBrandById(int id)
		{
			var brand = await _brandRepository.GetByIdAsync(id);

			if (brand == null)
			{
				return NotFound();
			}

			return Ok(brand);
		}

		[HttpPut("UpdateBrand/{id}")]
		public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandDto brandDto)
		{
			await _brandRepository.UpdateAsync(id, brandDto);
			return Ok();
		}


	}
}
