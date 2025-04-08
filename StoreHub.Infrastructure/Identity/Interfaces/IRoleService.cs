namespace StoreHub.Infrastructure.Identity.Interfaces
{
	public interface IRoleService
	{
		Task<bool> CreateRoleAsync(string roleName);

		Task<List<string>> GetRolesAsync();

		Task<bool> AddToRoleAsync(string userId, string roleName);
	}
}
