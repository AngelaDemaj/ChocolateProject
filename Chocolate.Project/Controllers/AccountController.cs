using ChocolateProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ChocolateProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        //This will handle our login validation and registration of our user identity
        public AccountController(UserManager<IdentityUser> userManager,
                                      SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
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

                    return RedirectToAction("UserIndex", "Administration");
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
        public async Task<IActionResult> Login(LoginViewModel user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(user.UserName, user.Password, user.RememberMe, false);

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

            return RedirectToAction("Login");
        }
    }
}
