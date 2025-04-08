using AutoMapper;
using MediatR;
using StoreHub.Application.DTOs.BrandDto;
using StoreHub.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.CQRS.Brand.Queries.GetBrand
{
	public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, BrandDto>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;

		public GetBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}
		public async Task<BrandDto> Handle(GetBrandQuery request, CancellationToken cancellationToken)
		{
			var brand = await _brandRepository.GetByIdAsync(request.Id);
			var brandDto = _mapper.Map<BrandDto>(brand);
			return brandDto;
		}
	}

}
