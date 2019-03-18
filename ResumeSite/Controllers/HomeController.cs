using ResumeSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace ResumeSite.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public ActionResult PhaserGame()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		[HttpGet]
		public ActionResult BackgroundGreyscale()
		{
			return View();
		}

		[HttpGet]
		public ActionResult Login()
		{
			return View();
		}
		

		[HttpPost]
		public ActionResult Login(User u)
		{
			ResumeDB db = new ResumeDB();

			User loginUser = db.Users.Where(v => v.Username == u.Username).SingleOrDefault();

			if(loginUser == null)
			{
				ViewBag.ErrorMessage = "No user found with that name.";

				return View();
			}
			else
			{
				string pass = loginUser.Password;

				if(!u.Password.Equals(pass))
				{
					ViewBag.ErrorMessage = "That password is incorrect.";

					return View();
				}
				else if (u.Password.Equals(pass))
				{
					Session["Username"] = loginUser.Username;

					return RedirectToAction("Index", "Home");
				}
				

			}



			return View();
		}

		[HttpGet]
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> Register(UserCreateModel u)
		{
			if (ModelState.IsValid)
			{
				Random r = new Random();

				int confirmationCode = r.Next(0, 999999);

				User newUser = new User();

				newUser.ConfirmationNo = confirmationCode;
				newUser.Email = u.EmailAddress;
				newUser.Password = u.Password;
				newUser.Username = u.Username;


				var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
				var client = new SendGridClient(apiKey);
				var from = new EmailAddress("kammsresumesite.donotreply@example.com", "Kamm's Resume Site");
				var subject = "Confirmation Code";
				var to = new EmailAddress(newUser.Email, newUser.Username);
				var plainTextContent = "Here is your confirmation code: ";
				var htmlContent = $"<strong>{newUser.ConfirmationNo}</strong>";
				var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
				var response = await client.SendEmailAsync(msg);

				return RedirectToAction("ConfirmationCode", newUser);
			}
			else
			{
				return View();
			}
		}




		[HttpGet]
		public ActionResult ConfirmationCode(User newUser)
		{
			return View(newUser);
		}

		[HttpPost]
		public ActionResult ConfirmationCode()
		{
			return View();
		}

		/*RESEND CONFIRMATION CODE METHOD*/

		/*RESEND CONFIRMATION CODE METHOD*/





	}
}
