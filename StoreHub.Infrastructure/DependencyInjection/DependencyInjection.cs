using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoreHub.Core.Entities;
using StoreHub.Core.Interfaces;
using StoreHub.Infrastructure.Data;
using StoreHub.Infrastructure.Identity.Implementation;
using StoreHub.Infrastructure.Identity.Interfaces;
using StoreHub.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
		{
			// تسجيل DbContext
			services.AddDbContext<StoreHubDb>(options =>
				options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			// تسجيل Repositories
			services.AddScoped<IRoleService, RoleService>();
			services.AddScoped<IAuthService, AuthService>();
			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IBrandRepository, BrandRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IParentCategoryRepository, ParentCategoryRepository>();


			return services;
		}
	}
}

