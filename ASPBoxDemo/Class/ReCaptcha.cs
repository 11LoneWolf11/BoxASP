using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPBoxDemo.Class
{
	public class ReCaptcha
	{
		[JsonProperty("success")]
		public bool Sucess { get; set; }
		[JsonProperty("error-codes")]
		public List<string> ErrorCodes { get; set; }
	}
}