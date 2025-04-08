using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreHub.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace StoreHub.Infrastructure.Data
{
    public class StoreHubDb : IdentityDbContext<ApplicationUser>
	{
		public StoreHubDb(DbContextOptions<StoreHubDb> options) : base(options) { }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ProductImages> ProductImages { get; set; }
		public DbSet<ParentCategory> ParentCategories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Brand>()
				.HasMany(b => b.Products)
				.WithOne(p => p.Brand)
				.HasForeignKey(p => p.BrandId).
				OnDelete(DeleteBehavior.Restrict);


			modelBuilder.Entity<Category>()
				.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Category>()
				.HasOne(c => c.ParentCategory)
				.WithMany(pc => pc.Categories)
				.HasForeignKey(c => c.ParentCategoryId)
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Product>()
				.HasMany(p => p.ProductImages)
				.WithOne(pi => pi.Product)
				.HasForeignKey(pi => pi.ProductId)
				.OnDelete(DeleteBehavior.Cascade);


		}




	}
}
