using System.Collections.Generic;
using PetsWonderland.Business.Models.UserRoles;

namespace PetsWonderland.Business.Services.Contracts
{
    public interface IRegistrationService
    {
        IEnumerable<ApplicationRole> GetAllUserRoles();

        void CreateRegularUser(string userId);

        void CreateHotelManager(string hotelManagerId);

		void CreateAdmin(string adminId);
	}
}
