using AutoMapper;
using Chocolate.DataAccess.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ChocolateProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public AdministrationController(
            RoleManager<IdentityRole> roleManager, 
            UserManager<IdentityUser> userManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult RoleIndex()
        {
            return View();
        }


        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityRole = new IdentityRole
                {
                    Name = model.Name
                };

                var result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("RoleIndex", "Administration");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _roleManager.Roles
                .FirstOrDefaultAsync(r => r.Id == id);

            if (role == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<RoleViewModel>(role);

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(RoleViewModel viewModel)
        {
            if (viewModel == null)
            {
                return NotFound();
            }

            var role = await _roleManager.FindByIdAsync(viewModel.Id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = viewModel.Name;
            await _roleManager.UpdateAsync(role);

            return View("RoleIndex");
        }

        [HttpGet]
        public IActionResult UserIndex()
        {
            var users = _userManager.Users;

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> UserDetails(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var viewModel = _mapper.Map<UsersDetailsViewModel>(user);
            //oi roloi tou xrhsth
            viewModel.RoleNames = userRoles.ToList();
            //oloi oi roloi ths efarmoghs
            viewModel.Roles = await _roleManager.Roles.ToListAsync();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserDetails(UsersDetailsViewModel viewModel)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == viewModel.UserName);

            var userRoles = await _userManager.GetRolesAsync(user);

            //roles that already exist in db but did not get here after posting, must be removed
            foreach (var roleToRemove in userRoles.Except(viewModel.RoleNames))
            {
                await _userManager.RemoveFromRoleAsync(user, roleToRemove);
            }

            //roles that do not exist in db must be added to the user
            foreach (var roleName in viewModel.RoleNames)
            {
                if (!userRoles.Contains(roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return View("UserIndex");
        }
    }
}
