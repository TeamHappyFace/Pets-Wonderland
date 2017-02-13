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

			string userRole = "User";
			string adminRole = "Admin";
			string hotelManagerRole = "Hotel manager";

			if (context != null && roleManager.Roles.Count() == 0)
			{
				roleManager.Create(new ApplicationRole(userRole));
				roleManager.Create(new ApplicationRole(adminRole));
				roleManager.Create(new ApplicationRole(hotelManagerRole));
			}

			return roleManager;
		}
	}
}