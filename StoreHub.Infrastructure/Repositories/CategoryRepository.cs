using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreHub.Core.DTOs.CategoryDto;
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
	public class CategoryRepository : ICategoryRepository
	{
		private StoreHubDb _context;
		private IMapper _mapper;

		public CategoryRepository(StoreHubDb context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task AddAsync(AddCategoryDto categoryDto)
		{
			var category = _mapper.Map<Category>(categoryDto);

			await _context.Categories.AddAsync(category);

			_context.SaveChangesAsync();

		}

		public async Task DeleteAsync(int id)
		{
			var deletedCategory = await _context.Categories.FindAsync(id);

			_context.Categories.Remove(deletedCategory);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<GetCategoryDto>> GetAllAsync()
		{
			var categories = await _context.Categories.ToListAsync();

			var categoriesDto = _mapper.Map<IEnumerable<GetCategoryDto>>(categories);

			return categoriesDto;

		}

		public async Task<GetCategoryDto?> GetByIdAsync(int id)
		{
			var category = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == id);

			if (category == null)
			{
				return null;
			}

			var categoryDto = _mapper.Map<GetCategoryDto>(category);

			return categoryDto;

		}

		public async Task UpdateAsync(int id, UpdateCategoryDto categoryDto)
		{
			var category = await _context.Categories.FindAsync(id);

			if (category == null)
			{
				throw new Exception("Category not found");
			}

			_mapper.Map(categoryDto, category);

			await _context.SaveChangesAsync();
		}
	}
}
