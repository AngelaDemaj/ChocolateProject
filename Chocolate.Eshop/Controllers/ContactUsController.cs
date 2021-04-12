using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chocolate.DataAccess.ViewModels;
using System.Net.Mail;

namespace Chocolate.Eshop.Controllers
{
    public class ContactUsController : Controller
    {

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ContactUs(ContactMessageViewModel viewModel)
        {
            MailMessage mail = new MailMessage("automatedmail@gmail.com", "lozancb12@gmail.com");
            mail.Subject = viewModel.Subject;
            mail.Body = $"The user {viewModel.Email} had the following question: \n" +
                $"{viewModel.Description}";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);/* smtp.gmail.com ports: 25, 465, 587 */
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "kamaterotakis@gmail.com",
                Password = "Xhd7[cY-"
            };

            TempData["Message"] = "Request Sent Successfully";

            smtpClient.EnableSsl = true;

            smtpClient.Send(mail);

            return RedirectToAction("Index", "Home");
        }
    }
}
