using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreHub.Core.Entities;
using StoreHub.Infrastructure.Data;
using StoreHub.Infrastructure.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Infrastructure.Identity.Implementation
{
	public class RoleService : IRoleService
	{
		private RoleManager<IdentityRole> _roleManager;
		private UserManager<ApplicationUser> _userManager;

		public RoleService(RoleManager<IdentityRole> roleManager , UserManager<ApplicationUser> userManager)
		{
			_roleManager = roleManager;
			_userManager = userManager;
		}

		public async Task<bool> AddToRoleAsync(string userId, string roleName)
		{
			var user = await _userManager.FindByIdAsync(userId);
			if (user == null)
			{
				return false;
			}
			var result = await _userManager.AddToRoleAsync(user, roleName);
			return result.Succeeded;
		}

		public async Task<bool> CreateRoleAsync(string roleName)
		{
			if(! await _roleManager.RoleExistsAsync(roleName))
			{
				var role = new IdentityRole(roleName);
				var resutl = await _roleManager.CreateAsync(role);
				return resutl.Succeeded;
			}
			return false;
		}

		public async Task<List<string>> GetRolesAsync()
		{
			return await _roleManager.Roles.Select(x =>x.Name).ToListAsync();
		}


	}
}
