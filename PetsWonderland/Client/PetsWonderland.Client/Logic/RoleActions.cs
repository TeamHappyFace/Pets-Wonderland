using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsWonderland.Client.Models;

namespace PetsWonderland.Client.Logic
{
	internal class RoleActions
	{
		internal void AddUserAndRole()
		{
			//Roles.CreateRole("admin");
			//Roles.AddUserToRole("Admin", "admin");


			// Access the application context and create result variables.
			ApplicationDbContext context = new ApplicationDbContext();
			IdentityResult IdRoleResult;
			IdentityResult IdUserResult;

			// Create a RoleStore object by using the ApplicationDbContext object. 
			// The RoleStore is only allowed to contain IdentityRole objects.
			var roleStore = new RoleStore<IdentityRole>(context);

			// Create a RoleManager object that is only allowed to contain IdentityRole objects.
			// When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
			var roleManager = new RoleManager<IdentityRole>(roleStore);

			// Then, you create the "canEdit" role if it doesn't already exist.
			if (!roleManager.RoleExists("canEdit"))
			{
				IdRoleResult = roleManager.Create(new IdentityRole { Name = "canEdit" });
			}

			// Create a UserManager object based on the UserStore object and the ApplicationDbContext  
			// object. Note that you can create new objects and use them as parameters in
			// a single line of code, rather than using multiple lines of code, as you did
			// for the RoleManager object.
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
			var appUser = new ApplicationUser
			{
				UserName = "canEditUser@petswonderland.com",
				Email = "canEditUser@petswonderland.com"
			};
			IdUserResult = userManager.Create(appUser, "Pa$$word1");

			// If the new "canEdit" user was successfully created, 
			// add the "canEdit" user to the "canEdit" role. 
			if (!userManager.IsInRole(userManager.FindByEmail("canEditUser@wingtiptoys.com").Id, "canEdit"))
			{
				IdUserResult = userManager.AddToRole(userManager.FindByEmail("canEditUser@petswonderland.com").Id, "canEdit");
			}
		}
	}
}