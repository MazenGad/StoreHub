using MediatR;
using StoreHub.Application.DTOs.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.CQRS.Brand.Commands.AddBrand
{
    public class CreateBrandCommand : IRequest<int>
    {
        public CreateBrandDto BrandDto { get; set; }

		public CreateBrandCommand(CreateBrandDto brandDto)
		{
			BrandDto = brandDto;
		}
	}
}
