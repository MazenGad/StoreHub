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
	public class BrandRepository : IBrandRepository
	{
		private StoreHubDb _context;
		private IMapper _mapper;
		public BrandRepository(StoreHubDb context , IMapper mapper) 
		{
			_context = context;
			_mapper = mapper;
		}
		public async Task AddAsync(Brand brandDto)
		{

			await _context.Brands.AddAsync(brandDto);

			await _context.SaveChangesAsync();

		}

		public async Task DeleteAsync(int id)
		{
			var brand = await _context.Brands.FindAsync(id);

			if (brand == null)
			{
				throw new Exception("Brand not found");
			}

			_context.Brands.Remove(brand);

			 await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Brand>> GetAllAsync()
		{
			var brands = await _context.Brands.ToListAsync();
			if (brands == null)
			{
				return null;
			}


			return brands;
		}

		public async Task<Brand?> GetByIdAsync(int id)
		{
			var brand = await _context.Brands.Include(p=>p.Products).FirstOrDefaultAsync(b => b.Id == id);

			if (brand == null)
			{
				return null;
			}


			return brand;
		}

		public async Task UpdateAsync( Brand brandDto)
		{
		
			_context.Brands.Update(brandDto);

			await _context.SaveChangesAsync();
		}
	}
}
