using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreHub.Core.DTOs.CategoryDto;
using StoreHub.Core.DTOs.ParentCategoryDto;
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
	public class ParentCategoryRepository : IParentCategoryRepository
	{
		private StoreHubDb _context;
		private IMapper _mapper;

		public ParentCategoryRepository(StoreHubDb context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task AddAsync(AddParentCategoryDto parentCategoryDto)
		{
			var category = _mapper.Map<ParentCategory>(parentCategoryDto);

			await _context.ParentCategories.AddAsync(category);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var category = await _context.ParentCategories.FindAsync(id);

			if (category == null)
			{
				throw new Exception("Category not found");
			}

			_context.ParentCategories.Remove(category);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<GetParentCategoryDto>> GetAllAsync()
		{
			var categories = await _context.ParentCategories.Include(c=>c.Categories).ToListAsync();

			return _mapper.Map<IEnumerable<ParentCategory>, IEnumerable<GetParentCategoryDto>>(categories);
		}

		public async Task<GetParentCategoryDto?> GetByIdAsync(int id)
		{
			var parentCategory = await _context.ParentCategories.Include(c => c.Categories).FirstOrDefaultAsync(c => c.Id == id);

			if (parentCategory == null)
			{
				return null;
			}

			return _mapper.Map<GetParentCategoryDto>(parentCategory);
		}

		public async Task UpdateAsync(int id, UpdateParentCategoryDto parentCategoryDto)
		{
			var parentCategory = await _context.ParentCategories.FindAsync(id);

			if (parentCategory == null)
			{
				throw new Exception("Category not found");
			}

			_mapper.Map(parentCategoryDto, parentCategory);

			await _context.SaveChangesAsync();
		}
	}
}
