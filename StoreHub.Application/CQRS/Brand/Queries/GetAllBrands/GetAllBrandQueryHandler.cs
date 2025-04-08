using AutoMapper;
using MediatR;
using StoreHub.Application.DTOs.BrandDto;
using StoreHub.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.CQRS.Brand.Queries.GetAllBrands
{
	public class GetBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<BrandDto>>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;

		public GetBrandQueryHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}
		public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
		{
			var brands = await _brandRepository.GetAllAsync();
			var brandDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);
			return brandDtos;
		}
	}

}
