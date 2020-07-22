using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPBoxDemo.Models
{
	public class LoginModel
	{
		//[Required(ErrorMessage = "Email is required")]
		public string email { get; set; }
		//[Required(ErrorMessage = "Password is required")]
		public string password { get; set; }				
	}
}