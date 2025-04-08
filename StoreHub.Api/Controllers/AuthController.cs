using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreHub.Application.Identity.DTOs;
using StoreHub.Core.Entities;
using StoreHub.Infrastructure.Identity.Interfaces;

namespace StoreHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
		private readonly IAuthService _authService;
		

		public AuthController(UserManager<ApplicationUser> userManager , IAuthService authService )
		{
			_userManager = userManager;
			_authService = authService;
		}

		[HttpPost("register")]

		public async Task<IActionResult> Register([FromBody] RegisterDto model)
		{
			if (ModelState.IsValid)
			{
				var result = await _authService.Register(model);
				if (result.Succeeded)
				{
					return Ok("User Created Successfully");
				}
				else
				{
					return BadRequest(result.Errors);
				}
			}

			return BadRequest(ModelState);
		}

		[HttpPost("login")]

		public async Task<IActionResult> Login([FromBody] LoginDto model)
		{
			var result = await _authService.Login(model);
			if (result != null)
			{
				return Ok($"Login Succeeded with Token : {result}");
			}
			return BadRequest("Invalid Email Or Password");
		}


		[Authorize(Roles = "admin")]
		[HttpGet("users")]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _authService.GetUsers();
			return Ok(users);
		}


	}
}
