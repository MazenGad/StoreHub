using AutoMapper;
using FluentValidation;
using MediatR;
using StoreHub.Application.DTOs.BrandDto;
using StoreHub.Core.Entities;
using StoreHub.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.CQRS.Brand.Commands.AddBrand
{
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, int>
	{
		private readonly IBrandRepository _brandRepository;
		private readonly IMapper _mapper;

		public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper)
		{
			_brandRepository = brandRepository;
			_mapper = mapper;
		}
		public async Task<int> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
		{
			var brand = _mapper.Map<Core.Entities.Brand>(request.BrandDto);

			var Vadidator = new AddPostValidator();

			var result = await Vadidator.ValidateAsync(request);

			if (!result.IsValid)
			{
				var errors = string.Join(" | ", result.Errors.Select(e => e.ErrorMessage));
				throw new ValidationException(errors);
			}

			await _brandRepository.AddAsync(brand);
			return brand.Id;
		}
	}
  
}
