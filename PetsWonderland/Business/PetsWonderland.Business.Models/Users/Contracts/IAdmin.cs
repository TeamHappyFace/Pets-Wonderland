using System.Collections.Generic;
using PetsWonderland.Business.Models.Requests;

namespace PetsWonderland.Business.Models.Users.Contracts
{
    public interface IAdmin
    {
		string Id { get; set; }

		ICollection<UserHotelRegistrationRequest> UserHotelRegistrationRequests { get; set; }

        bool IsDeleted { get; set; }
    }
}