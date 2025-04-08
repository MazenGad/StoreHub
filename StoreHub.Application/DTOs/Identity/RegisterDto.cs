using CommandLine.Text;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreHub.Application.Identity.DTOs
{
	public class RegisterDto
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string UserName { get; set; }

		[Required]
		[RegularExpression(@"^\d{7,15}$", ErrorMessage = "The phone number must contain only digits and be between 7 and 15 digits long.")]
		public string PhoneNumber { get; set; }

		[Required]
		public string Password { get; set; }

		[Required]
		[Compare("Password")]
		public string ConfirmPassword { get; set; }
	}
}
