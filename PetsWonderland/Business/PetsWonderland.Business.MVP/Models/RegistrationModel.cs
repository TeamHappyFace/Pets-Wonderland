using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PetsWonderland.Business.MVP.Models
{
	public class RegistrationModel
	{
		public IdentityResult Result { get; set; }

		public IEnumerable<IdentityRole> UserRoles { get; set; }
	}
}
