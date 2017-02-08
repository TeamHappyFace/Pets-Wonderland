using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsWonderland.Business.Common.Constants;

namespace PetsWonderland.Business.Models.Users
{
	public class UserProfile : IdentityUser
	{
		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string FirstName { get; set; }

		[MinLength(ValidationConstants.NameMinLength)]
		[MaxLength(ValidationConstants.NameMaxLength)]
		public string LastName { get; set; }
		
		public int Age { get; set; }

		public string AvatarUrl { get; set; }

		public ClaimsIdentity GenerateUserIdentity(UserManager<UserProfile> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}

		public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<UserProfile> manager)
		{
			return Task.FromResult(GenerateUserIdentity(manager));
		}


	}
}
