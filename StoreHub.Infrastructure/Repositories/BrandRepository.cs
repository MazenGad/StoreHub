using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StoreHub.Core.DTOs.BrandDto;
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
		public async Task AddAsync(CreateBrandDto brandDto)
		{
			var brand = _mapper.Map<Brand>(brandDto);

			await _context.Brands.AddAsync(brand);

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

		public async Task<IEnumerable<BrandDto>> GetAllAsync()
		{
			var brands = await _context.Brands.ToListAsync();
			if (brands == null)
			{
				return null;
			}

			var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);

			return brandDtos;
		}

		public async Task<BrandDto?> GetByIdAsync(int id)
		{
			var brand = await _context.Brands.Include(p=>p.Products).FirstOrDefaultAsync(b => b.Id == id);

			if (brand == null)
			{
				return null;
			}

			var brandDto = _mapper.Map<BrandDto>(brand);

			return brandDto;
		}

		public async Task UpdateAsync(int id, UpdateBrandDto brandDto)
		{
			var brand = await _context.Brands.FirstOrDefaultAsync(b => b.Id == id);

			if (brand == null)
			{
				throw new Exception("Brand not found");
			}

			_mapper.Map(brandDto, brand);

			await _context.SaveChangesAsync();
		}
	}
}
