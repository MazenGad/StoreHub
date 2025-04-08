using Microsoft.AspNetCore.Mvc;
using StoreHub.Application.DTOs.ParentCategoryDto;
using StoreHub.Core.Interfaces;

namespace StoreHub.Api.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class ParentCategoryController : Controller
    {
		private IParentCategoryRepository _parentCategoryRepository;

		public ParentCategoryController(IParentCategoryRepository parentCategoryRepository)
		{
			_parentCategoryRepository = parentCategoryRepository;
		}

		[HttpGet("GetAllParentCategories")]
		public async Task<IActionResult> GetAllParentCategories()
		{
			var parentCategories = await _parentCategoryRepository.GetAllAsync();
			return Ok(parentCategories);
		}

		[HttpGet("GetParentCategoryById/{id}")]

		public async Task<IActionResult> GetParentCategoryById(int id)
		{
			var parentCategory = await _parentCategoryRepository.GetByIdAsync(id);

			if (parentCategory == null)
			{
				return NotFound();
			}

			return Ok(parentCategory);
		}

		[HttpPost("AddParentCategory")]

		public async Task<IActionResult> AddParentCategory([FromBody] AddParentCategoryDto parentCategoryDto)
		{
			//await _parentCategoryRepository.AddAsync(parentCategoryDto);
			return Ok();
		}

		[HttpDelete("DeleteParentCategory/{id}")]

		public async Task<IActionResult> DeleteParentCategory(int id)
		{
			await _parentCategoryRepository.DeleteAsync(id);

			return Ok();
		}

		[HttpPut("UpdateParentCategory/{id}")]
		public async Task<IActionResult> UpdateParentCategory(int id, [FromBody] UpdateParentCategoryDto parentCategoryDto)
		{
			var parentCategory = await _parentCategoryRepository.GetByIdAsync(id);
			if (parentCategory == null)
			{
				return NotFound();
			}
			//await _parentCategoryRepository.UpdateAsync(id, parentCategoryDto);
			return Ok();
		}


	}
}
