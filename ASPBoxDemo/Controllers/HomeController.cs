using ASPBoxDemo.Class;
using ASPBoxDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace ASPBoxDemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpPost]
		public ActionResult FormSubmit(LoginModel loginModel)
		{		
			var response = Request["g-recaptcha-response"];			
			string secretKey = "6LdxC7QZAAAAANijw6b9anRrYGVMr-Xk-0P75DC_";
			//read the values from appconfig , secretKey, https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}
			var client = new WebClient();
			var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
			
			var captResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptcha>(result);			

			if (!captResponse.Sucess)
			{
				string errorList = String.Empty;
				foreach (string error in captResponse.ErrorCodes)
				{
					errorList = error;
				}
				this.ModelState.AddModelError(String.Empty, "Invalid Captcha " + errorList);		
			}			

			if (loginModel.email.Length == 0 || loginModel.email == null)
			{
				this.ModelState.AddModelError(String.Empty, "invalue email");
			}

			if (loginModel.password.Length ==0  || loginModel.password == null)
			{
				this.ModelState.AddModelError(String.Empty, "invalue password");
			}
			return View("Index");
		}


	}
}