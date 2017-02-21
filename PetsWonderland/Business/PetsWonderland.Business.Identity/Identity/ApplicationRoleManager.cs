using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using PetsWonderland.Business.Data;
using PetsWonderland.Business.Models.UserRoles;

namespace PetsWonderland.Business.Identity
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(IRoleStore<ApplicationRole, string> store)
            : base(store)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context.Get<PetsWonderlandDbContext>()));

            const string UserRole = "User";
            const string AdminRole = "Admin";
            const string HotelManagerRole = "Hotel manager";

            if (roleManager.Roles.Any())
            {
                return roleManager;
            }

            roleManager.Create(new ApplicationRole(UserRole));
            roleManager.Create(new ApplicationRole(AdminRole));
            roleManager.Create(new ApplicationRole(HotelManagerRole));

            return roleManager;
        }
    }
}