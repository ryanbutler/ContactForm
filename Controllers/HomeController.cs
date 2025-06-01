using System.Diagnostics;
using System.Net.Mail;
using System.Text;
using ContactForm.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    MailAddress from = new MailAddress(contact.Email.ToString());
                    StringBuilder sb = new StringBuilder();
                    msg.To.Add("youremail@email.com");
                    msg.From = from;
                    msg.Subject = "Contact Us";
                    msg.IsBodyHtml = false;
                    smtp.Host = "mail.yourdomain.com";
                    smtp.Port = 25;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
