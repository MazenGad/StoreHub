using AutoMapper;
using Microsoft.AspNetCore.Identity;
using StoreHub.Application.DTOs.BrandDto;
using StoreHub.Application.DTOs.CategoryDto;
using StoreHub.Application.DTOs.ParentCategoryDto;
using StoreHub.Application.DTOs.ProductDto;
using StoreHub.Application.DTOs.ProductImageDto;
using StoreHub.Application.Identity.DTOs;
using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.Mapping
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Product, GetProductDto>()
					.ForMember(dest => dest.IsAvailable, opt => opt.MapFrom(src => src.StockQuantity > 0))
					  .ForMember(dest => dest.MainImageUrl,
					   opt => opt.MapFrom(src => src.ProductImages.FirstOrDefault() != null
						   ? src.ProductImages.First().ImageUrl
						   : null))

					  .ForMember(dest => dest.BrandName,
					   opt => opt.MapFrom(src => src.Brand.Name))

					  .ForMember(dest => dest.CategoryName,
					   opt => opt.MapFrom(src => src.Category.Name));

			CreateMap<CreateProductDto, Product>();
			CreateMap<UpdateProductDto, Product>();

			CreateMap<ProductImages , GetProductImageDto>();
			CreateMap<GetProductImageDto, ProductImages>();
			CreateMap<UpdateProductImageDto, ProductImages>();

			CreateMap<Brand, BrandDto>().ReverseMap();
			CreateMap<CreateBrandDto, Brand>();
			CreateMap<UpdateBrandDto, Brand>();

			CreateMap<Category, GetCategoryDto>();
			CreateMap<AddCategoryDto, Category>();
			CreateMap<UpdateCategoryDto, Category>();

			CreateMap<ParentCategory, GetParentCategoryDto>();
			CreateMap<AddParentCategoryDto, ParentCategory>();
			CreateMap<UpdateParentCategoryDto, ParentCategory>();

			CreateMap<IdentityUser , GetUserDto>()
					.ForMember(dest => dest.Roles, opt => opt.Ignore());

		}

	}
}
