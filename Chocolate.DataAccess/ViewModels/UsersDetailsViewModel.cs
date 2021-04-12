using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Chocolate.DataAccess.ViewModels
{
    public class UsersDetailsViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> RoleNames { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
