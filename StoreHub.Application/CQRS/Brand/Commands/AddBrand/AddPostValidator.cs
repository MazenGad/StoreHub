using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.CQRS.Brand.Commands.AddBrand
{
    public class AddPostValidator : AbstractValidator<CreateBrandCommand>
    {
        public AddPostValidator() 
        { 
            
            RuleFor(x=>x.BrandDto.Name)
				.NotEmpty()
				.NotNull()
				.WithMessage("Name is required")
				.MaximumLength(50)
				.WithMessage("Name must not exceed 50 characters");
			RuleFor(x => x.BrandDto.LogoUrl)
				.NotEmpty()
				.NotNull()
				.WithMessage("LogoUrl is required")
				.Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute))
				.WithMessage("LogoUrl must be a valid URL");


		}
    }
}
