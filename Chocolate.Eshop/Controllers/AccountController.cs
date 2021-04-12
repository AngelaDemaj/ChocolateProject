using Chocolate.Business.Services.Interfaces;
using Chocolate.DataAccess;
using Chocolate.DataAccess.Models;
using Chocolate.DataAccess.Models.Enums;
using Chocolate.DataAccess.ViewModels;
using Chocolate.Eshop.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Chocolate.Eshop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ChocolateDbContext _context;
        private readonly ICustomerService _service;

        //This will handle our login validation and registration of our user identity
        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ChocolateDbContext context,
            ICustomerService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _service = service;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult CustomerOrders()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> Details()
        {
            var viewModel = await _service.GetAccountDetails(User);
            if(viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var viewModel = await _service.GetAccountDetails(User);

            if(viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel viewModel)
        {
            
            if (viewModel == null)
            {
                return NotFound();
            }

            await _service.UpdateAccount(viewModel, User);

            return RedirectToAction("Details", "Account");
        }


        //This method will validate the input of a new user identity and register it to our database
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                var result = await _userManager.CreateAsync(user, model.Password);

                var mail = new Email
                {
                    CustomerId = model.Id,
                    Mail = model.Email,
                    MailType = MailType.Personal
                };
                _context.Emails.Add(mail);

                var phone = new Phone
                {
                    CustomerId = model.Id,
                    Number = model.Number,
                    PhoneType = PhoneType.Personal
                };
                _context.Phones.Add(phone);

                var address = new Address
                {
                    CustomerId = model.Id,
                    Location = model.Location,
                    AddressNumber = model.AddressNumber,
                    Country = model.Country,
                    PostCode = model.PostCode
                };
                _context.Addresses.Add(address);

                var customer = new Customer
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserId = user.Id,
                    Emails = { mail },
                    Phones = { phone },
                    Addresses = { address }
                };
                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();

                

                if (result.Succeeded)
                {
                    MailMessage mailMessage = new MailMessage("kamaterotakis@gmail.com", user.Email);
                    mailMessage.Subject = "Welcome to Lozan Chocolates";
                    mailMessage.Body = "Welcome to Lozan. Lozan was created by our lord and savior Takis Kamateros, founder and CEO of Lozan Chocolates. He was inspired " +
                                       "by his love for chocolate, and the joy it brought to people's lives. Lozan is a family business operating" +
                                       "in the Greek market since 2015. Over the course of those 6 years, through thick and thin, we have managed to " +
                                       "achieve significant recognition in the Greek market through the high quality of our products and the satisfaction of our customers. \n" +
                                       "By joining us, you took a step closer to a happier tomorrow, welcome to the family!";

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

                    smtpClient.Send(mailMessage);

                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(user.Input, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
