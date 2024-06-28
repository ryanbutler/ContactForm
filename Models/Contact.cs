using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ContactForm.Models
{
	public class Contact
	{
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.MultilineText)]
		public string Comment { get; set; }

	}
}