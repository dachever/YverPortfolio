using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using MyPortfolio.Models; 

namespace MyPortfolio.Controllers  
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _config;

        public ContactController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ContactFormModel model)
        {
            if (ModelState.IsValid)
            {
                var emailSettings = _config.GetSection("EmailSettings");

                string smtpServer = emailSettings["SmtpServer"]!;
                int port = int.Parse(emailSettings["Port"]!);   // ✅ Added
                string senderName = emailSettings["SenderName"]!; // ✅ Added
                string senderEmail = emailSettings["SenderEmail"]!;
                string username = emailSettings["Username"]!;
                string password = emailSettings["Password"]!;

                try
                {
                    var client = new SmtpClient(smtpServer, port)
                    {
                        Credentials = new NetworkCredential(username, password),
                        EnableSsl = true
                    };

                    var mail = new MailMessage();
                    mail.From = new MailAddress(senderEmail, senderName);
                    mail.To.Add(senderEmail); 
                    mail.Subject = model.Subject;
                    mail.Body = $"From: {model.Name} ({model.Email})\n\n{model.Message}";

                    client.Send(mail);

                    ViewBag.Message = "✅ Your message has been sent!";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "❌ Error sending message: " + ex.Message;
                }
            }

            return View();
        }
    }
}
