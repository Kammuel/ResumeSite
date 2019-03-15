using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ResumeSite.Models
{
	public class UserCreateModel
	{
		public string Username { get; set; }

		[Required]
		[StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
		[RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Required]
		[Compare("Password", ErrorMessage = "Passwords must match.")]
		public string RepeatPassword { get; set; }

		[EmailAddress]
		public string EmailAddress { get; set; }



	}
}