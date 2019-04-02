using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ResumeSite.Models
{
	public class User
	{
		[Key]
		public int UserID { get; set; }

		[Required]
		
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		public int ConfirmationNo { get; set; }

		[DefaultValue(false)]
		public bool EmailConfirmed { get; set; }


	}
}