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
	public class CategoryRepository : ICategoryRepository
	{
		private StoreHubDb _context;
		private IMapper _mapper;

		public CategoryRepository(StoreHubDb context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task AddAsync(Category categoryDto)
		{
			await _context.Categories.AddAsync(categoryDto);

			_context.SaveChangesAsync();

		}

		public async Task DeleteAsync(int id)
		{
			var deletedCategory = await _context.Categories.FindAsync(id);

			_context.Categories.Remove(deletedCategory);

			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Category>> GetAllAsync()
		{
			var categories = await _context.Categories.ToListAsync();

			return categories;

		}

		public async Task<Category?> GetByIdAsync(int id)
		{
			var category = await _context.Categories.Include(p => p.Products).FirstOrDefaultAsync(c => c.Id == id);

			if (category == null)
			{
				return null;
			}

			return category;

		}

		public async Task UpdateAsync( Category categoryDto)
		{
			_context.Categories.Update(categoryDto);

			await _context.SaveChangesAsync();
		}
	}
}
