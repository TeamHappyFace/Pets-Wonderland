using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;
using PetsWonderland.Business.Models.UserRoles;

namespace PetsWonderland.Business.Services.Contracts
{
	public interface IRegistrationService
	{
		IEnumerable<ApplicationRole> GetAllUserRoles();

		void CreateRegularUser(string userId);

		void CreateHotelManager(string hotelManagerId);
	}
}
