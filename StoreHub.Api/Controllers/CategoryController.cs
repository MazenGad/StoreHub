using Microsoft.AspNetCore.Mvc;
using StoreHub.Core.DTOs.CategoryDto;
using StoreHub.Core.Interfaces;

namespace StoreHub.Api.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
		public CategoryController(ICategoryRepository categoryRepository) 
        {
			_categoryRepository = categoryRepository;
		}

		[HttpGet("GetAllCategories")]
		public async Task<IActionResult> GetAll()
		{
			var categories = await _categoryRepository.GetAllAsync();
			return Ok(categories);
		}

		[HttpGet("GetCategoryById/{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var category = await _categoryRepository.GetByIdAsync(id);
			if (category == null)
			{
				return NotFound();
			}
			return Ok(category);
		}

		[HttpPost("AddCategory")]
		public async Task<IActionResult> Add([FromBody] AddCategoryDto categoryDto)
		{
			await _categoryRepository.AddAsync(categoryDto);
			return Ok();
		}


		[HttpDelete("DeleteCategory/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _categoryRepository.DeleteAsync(id);
			return Ok();
		}

		[HttpPut("UpdateCategory/{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateCategoryDto categoryDto)
		{
			await _categoryRepository.UpdateAsync(id, categoryDto);
			return Ok();
		}
	}
}
