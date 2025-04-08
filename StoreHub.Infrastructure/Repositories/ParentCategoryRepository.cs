using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

		public async Task AddAsync(ParentCategory parentCategoryDto)
		{
			await _context.ParentCategories.AddAsync(parentCategoryDto);

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

		public async Task<IEnumerable<ParentCategory>> GetAllAsync()
		{
			var categories = await _context.ParentCategories.Include(c=>c.Categories).ToListAsync();

			return categories;
		}

		public async Task<ParentCategory?> GetByIdAsync(int id)
		{
			var parentCategory = await _context.ParentCategories.Include(c => c.Categories).FirstOrDefaultAsync(c => c.Id == id);

			if (parentCategory == null)
			{
				return null;
			}

			return parentCategory;
		}

		public async Task UpdateAsync(ParentCategory parentCategoryDto)
		{
			_context.ParentCategories.Update(parentCategoryDto);

			await _context.SaveChangesAsync();
		}
	}
}
