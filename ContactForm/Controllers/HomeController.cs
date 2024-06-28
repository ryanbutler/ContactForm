using ContactForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ContactForm.Controllers
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
		public ActionResult Contact(Contact contact)
		{
			if (ModelState.IsValid)
			{
				try
				{
					MailMessage msg = new MailMessage();
					SmtpClient smtp = new SmtpClient();
					MailAddress from = new MailAddress(contact.Email.ToString());
					StringBuilder sb = new StringBuilder();
					NetworkCredential creds = new NetworkCredential("email@domain.com", "Password");
					msg.To.Add("youremail@email.com");
					msg.From = from;
					msg.Subject = "Contact Us";
					msg.IsBodyHtml = false;
					smtp.Host = "mail.yourdomain.com";
					smtp.Port = 25;
					smtp.Port = 587;
					smtp.EnableSsl = true;
					smtp.Credentials = creds;
					sb.Append("First name: " + contact.FirstName);
					sb.Append(Environment.NewLine);
					sb.Append("Last name: " + contact.LastName);
					sb.Append(Environment.NewLine);
					sb.Append("Email: " + contact.Email);
					sb.Append(Environment.NewLine);
					sb.Append("Comments: " + contact.Comment);
					msg.Body = sb.ToString();
					smtp.Send(msg);
					msg.Dispose();
					return View("Success");
				}
				catch (Exception e)
				{
					return View("Error");
				}
			}
			return View();
		}

	}
}