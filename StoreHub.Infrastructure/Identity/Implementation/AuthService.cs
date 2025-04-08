using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StoreHub.Application.Identity.DTOs;
using StoreHub.Core.Entities;
using StoreHub.Infrastructure.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Infrastructure.Identity.Implementation
{
	public class AuthService : IAuthService
	{
		private UserManager<ApplicationUser> _userManager;
		private RoleManager<IdentityRole> _roleManager;
		private IConfiguration _config;
		private IMapper _mapper;
		public AuthService(UserManager<ApplicationUser> userManager, IConfiguration configuration , RoleManager<IdentityRole> roleManager , IMapper mapper)
		{
			_userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
			_config = configuration ?? throw new ArgumentNullException(nameof(configuration));
			_roleManager = roleManager;
			_mapper = mapper;
		}

		public async Task<string> GenerateJwtToken(IdentityUser user)
		{
			var jwtSettings = _config.GetSection("AppSettings");

			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));
			var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Id),
			new Claim(JwtRegisteredClaimNames.Email, user.Email),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Unique ID
        };

			// إضافة الأدوار إذا كان عند المستخدم أدوار
			var userRoles = _userManager.GetRolesAsync((ApplicationUser)user).Result;
			foreach (var role in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryMinutes"])),
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public async Task<List<GetUserDto>> GetUsers()
		{
			var users = await _userManager.Users.ToListAsync();

			var usersDto = new List<GetUserDto>();

			foreach (var user in users)
			{
				var roles = await _userManager.GetRolesAsync(user);
				var userDto = _mapper.Map<GetUserDto>(user);
				userDto.Roles = roles;

				usersDto.Add(userDto);
			}

			return usersDto;
		}

		public async Task<string> Login(LoginDto model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user != null)
			{
				var result = await _userManager.CheckPasswordAsync(user, model.Password);
				if (result)
				{
					return await GenerateJwtToken(user);
				}
				else
				{
					return null;

				}

			}
			return null;

		}

		public async Task<IdentityResult> Register(RegisterDto model)
		{
			var emailExist = await _userManager.FindByEmailAsync(model.Email);
			if (emailExist != null)
			{
				return IdentityResult.Failed(new IdentityError { Description = "Email already exists" });
			}
			else
			{
				var user = new ApplicationUser
				{
					UserName = model.UserName,
					Email = model.Email,
					PhoneNumber = model.PhoneNumber,
				};

				var result = await _userManager.CreateAsync(user, model.ConfirmPassword);

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "Customer");
					return result;
				}
				else
				{
					return result;
				}

			}


		}
	}
}
