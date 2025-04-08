using MediatR;
using StoreHub.Application.DTOs.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.CQRS.Brand.Queries.GetBrand
{
    public class GetBrandQuery : IRequest<BrandDto>
	{
		public int Id { get; set; }
	}
}
