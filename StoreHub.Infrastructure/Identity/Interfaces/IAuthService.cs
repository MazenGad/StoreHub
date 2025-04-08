using Microsoft.AspNetCore.Identity;
using StoreHub.Application.Identity.DTOs;
using StoreHub.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Infrastructure.Identity.Interfaces
{
    public interface IAuthService
    {
		Task<IdentityResult> Register(RegisterDto model);
		Task<string> Login(LoginDto model);

		Task<string> GenerateJwtToken(IdentityUser user);
	
		Task<List<GetUserDto>> GetUsers();

	}
}
