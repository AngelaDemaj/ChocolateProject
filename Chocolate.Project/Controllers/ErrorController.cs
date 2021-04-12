using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ChocolateProject.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        [Route("Error")]
        [AllowAnonymous]
        [Route("Error/{statusCode}")]
        public IActionResult ErrorCodeHandler(int? statusCode)
        {
            // If there is 404 status code, the route path will become Error/404
            if (statusCode == 404)
            {
                return View("PageNotFound");
            }

            // Retrieve the exception Details
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ExceptionPath = exceptionHandlerPathFeature.Path;
            var ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            var StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            // Send the exception Details
            MailMessage errorMessage = new MailMessage("kamaterotakis@gmail.com", "kamaterotakis@gmail.com");
            errorMessage.Subject = "Logic Not Found";
            errorMessage.Body = "<!DOCTYPE html>" +
                                "<html>" +                                
                                "<body>" +
                                    "<h5>A Wild Exception Has Appeared</h5>" +
                                    "<hr/>" +
                                    "<h3>Exception Details:</h3>" +
                                    "<div>" +
                                        "<h5>Exception Path</h5>" +
                                        "<hr/>" +
                                       $"<p>{ExceptionPath}</p>" +
                                    "</div> " +
                                    "<div>" +
                                        "<h5>Exception Message</h5>" +
                                        "<hr/>" +
                                       $"<p>{ExceptionMessage}</p>" +
                                    "</div>" +
                                    "<div>" +
                                        "<h5>Exception Stack Trace</h5>" +
                                        "<hr/>" +
                                       $"<p>{StackTrace}</p>" +
                                    "</div>" +
                                "</body>" +
                                "</html>";

            errorMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 25);/* smtp.gmail.com ports: 25, 465, 587 */
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "kamaterotakis@gmail.com",
                Password = "Xhd7[cY-"
            };

            smtpClient.EnableSsl = true;

            /*
             * https://www.google.com/settings/security/lesssecureapps
             */

            smtpClient.Send(errorMessage);

            return View("LogicNotFound");

        }
    }
}