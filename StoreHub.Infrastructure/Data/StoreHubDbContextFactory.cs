using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.IO;

namespace StoreHub.Infrastructure.Data
{
	public class StoreHubDbContextFactory : IDesignTimeDbContextFactory<StoreHubDb>
	{
		public StoreHubDb CreateDbContext(string[] args)
		{
			IConfigurationRoot configuration = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.Build();

			var optionsBuilder = new DbContextOptionsBuilder<StoreHubDb>();
			var connectionString = configuration.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(connectionString);

			return new StoreHubDb(optionsBuilder.Options);
		}
	}
}
