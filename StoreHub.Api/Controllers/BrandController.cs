using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StoreHub.Application.CQRS.Brand.Commands.AddBrand;
using StoreHub.Application.CQRS.Brand.Queries.GetAllBrands;
using StoreHub.Application.CQRS.Brand.Queries.GetBrand;
using StoreHub.Application.DTOs.BrandDto;
using StoreHub.Core.Interfaces;

namespace StoreHub.Api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BrandController : Controller
    {
		private IBrandRepository _brandRepository;
		private readonly IMediator _mediator;

		public BrandController(IBrandRepository brandRepository , IMediator mediator)
		{
			_mediator = mediator;
			_brandRepository = brandRepository;
		}

		[HttpGet("GetBrands")]
		public async Task<IActionResult> GetBrands()
		{
			var brands = await _mediator.Send(new GetAllBrandQuery());

			if(brands == null)
			{
				return NotFound();
			}

			return Ok(brands);
		}

		[HttpPost("AddBrand")]
		public async Task<IActionResult> AddBrand([FromBody] CreateBrandDto brandDto)
		{
			var brand = await _mediator.Send(new CreateBrandCommand(brandDto));
			if (brand == 0)
			{
				return BadRequest();
			}
			return CreatedAtAction(nameof(GetBrandById), new { id = brand }, $"Created Succeded with Id = {brand}");
		}

		[Authorize (Roles = "admin") ]
		[HttpDelete("DeleteBrand/{id}")]
		public async Task<IActionResult> DeleteBrand(int id)
		{
			await _brandRepository.DeleteAsync(id);
			return Ok();
		}

		[HttpGet("GetBrandById/{id}")]
		public async Task<IActionResult> GetBrandById(int id)
		{
			var brand = await _mediator.Send(new GetBrandQuery { Id = id });

			if (brand == null)
			{
				return NotFound();
			}

			return Ok(brand);
		}

		[HttpPut("UpdateBrand/{id}")]
		public async Task<IActionResult> UpdateBrand(int id, [FromBody] UpdateBrandDto brandDto)
		{
			//await _brandRepository.UpdateAsync(id, brandDto);
			return Ok();
		}


	}
}
